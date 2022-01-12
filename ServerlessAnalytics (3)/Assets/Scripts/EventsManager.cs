using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Collections;

public class EventsManager
{
    // Session Info
    public static string client_id = GetUUID();
    public static string session_id = GetUUID();

    // The number of records collected before a batch is sent to Amazon Kinesis Streams
    // In production this should be much higher, but for this demo script it is set to 4
    static int batchSize = 4;

    // A list that holds our records to batch them
    static List<object> raw_records = new List<object>();

    // Kinesis Stream Details
    private static string streamName = "enter-KDS-stream-name-here"; // Kinesis Stream Name
    private static AmazonKinesisClient kinesisClient =
        new AmazonKinesisClient(CredentialsManager.credentials, CredentialsManager.region);

    // Creates a App Load Event
    public static void Create_App_Load_Event(string platform)
    {
        string event_name = "app_load";

        Dictionary<string, object> event_data = new Dictionary<string, object>()
        {
             { "platform", platform }
         };

        Create_Record(event_data, event_name);
    }

    // Creates a Login Event
    public static void Create_Login_Event(string platform)
    {
        string event_name = "login";

        Int64 current_time =
        (Int64)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        Dictionary<string, object> event_data = new Dictionary<string, object>()
        {
             { "platform", platform },
             { "last_login_time", current_time }
         };

        Create_Record(event_data, event_name);
    }

    // Creates a Login Event
    public static void Create_Signup_Event(string country, string platform)
    {
        string event_name = "user_registration";

        Dictionary<string, object> event_data = new Dictionary<string, object>()
        {
             { "country_id", country },
             { "platform", platform }
         };

        Create_Record(event_data, event_name);
    }

    // Create an IAP Transaction Event
    public static void Create_Transaction_Event(int item_id, string item_name, int item_amount,
        double real_value, int virtual_value, string currency, string country, string platform, string receipt)
    {
        string event_name = "iap_transaction";

        Dictionary<string, object> event_data = new Dictionary<string, object>()
        {
            { "item_id", item_id },
            { "item_name", item_name },
            { "item_amount", item_amount },
            { "real_value", real_value },
            { "virtual_value", virtual_value },
            { "currency_type", currency },
            { "country_id", country },
            { "platform", platform },
            { "transaction_receipt", receipt }
        };

        Create_Record(event_data, event_name);
    }

    // Create an Virtual Goods Transaction Event
    public static void Create_Virtual_Goods_Event(int item_id, string item_name, int item_amount,
        double real_value, int virtual_value, string currency, string country, string platform, string receipt)
    {
        string event_name = "virtual_goods_transaction";

        Dictionary<string, object> event_data = new Dictionary<string, object>()
        {
            { "item_id", item_id },
            { "item_name", item_name },
            { "item_amount", item_amount },
            { "real_value", real_value },
            { "virtual_value", virtual_value },
            { "currency_type", currency },
            { "country_id", country },
            { "platform", platform },
            { "transaction_receipt", receipt }
        };

        Create_Record(event_data, event_name);
    }

    // Creates a UUID
    static string GetUUID()
    {
        return System.Guid.NewGuid().ToString();
    }

    // Create Record enriches event data with additional parameters and converts to JSON
    private static void Create_Record(Dictionary<string, object> event_data,
        string event_name)
    {
        string event_id = GetUUID();
        string partitionKey = event_id;

        Int64 current_time =
            (Int64)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        Dictionary<string, object> record = new Dictionary<string, object>()
        {
            { "event_id", event_id },
            { "event_type", event_name },
            { "event_name", event_name },
            { "event_timestamp", current_time },
            { "event_version", "1.1.0" },
            { "app_version", "1.1.0" },
            { "event_data", event_data }
         };

        //Add to the Batch of Records
        Generate_Batch(record, partitionKey);

    }

    // Generate Batch
    private static void Generate_Batch(Dictionary<string, object> record,
        string partitionKey)
    {
        string application_id = CredentialsManager.appClientId; // Application ID from the Solution

        // Append Raw Records with new Record
        raw_records.Add(new Dictionary<string, object>()
            {
                { "event", record },
                { "application_id", application_id }           
            });

        Debug.Log("Added record to list" + raw_records.Count);

        if (/*raw_records.Count >= batchSize*/ raw_records.Count != 0)
        {
            //Call Put Record
            Put_Records(raw_records, partitionKey);
        }
    }

    // Put Records
    private static async void Put_Records(List<object> raw_records,
        string partitionKey)
    {
        Debug.Log("Put Records Called");

        List<PutRecordsRequestEntry> formatted_records =
            new List<PutRecordsRequestEntry>();

        foreach (object rec in raw_records)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))

            {
                //Convert to Json using Newtonsoft
                string jsonData = JsonConvert.SerializeObject(rec,
                    Formatting.Indented);

                Debug.Log("Record To be Sent:" + jsonData);

                streamWriter.Write(jsonData);
                streamWriter.Flush();

                Debug.Log(System.Text.Encoding.UTF8.GetString(memoryStream.ToArray()));

                formatted_records.Add(new PutRecordsRequestEntry
                {
                    Data = memoryStream,
                    PartitionKey = partitionKey
                });
                
            }
        }

        Debug.Log("Record Formatted");

        Task<PutRecordsResponse> responseTask =
            kinesisClient.PutRecordsAsync(new PutRecordsRequest
        {
            Records = formatted_records,
            StreamName = streamName
        });

        PutRecordsResponse responseObject = await responseTask;

        Debug.Log("Event Sent" + "\n" + "Successful Records Sent:" +
            responseObject.Records.Count + "\n"
            + "Failed Records:" + responseObject.FailedRecordCount);

        //Clears raw records after they are sent for demo.
        //In production, change to only clear on successful response.
        raw_records.Clear();
    }


}