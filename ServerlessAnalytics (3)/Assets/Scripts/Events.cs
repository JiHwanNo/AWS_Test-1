using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{

    // General Values
    private static string platform = "UnityEditor";
    private static string currency = "USD";
    private static string country = "UNITED STATES";

    // Creates a UUID
    static string GetUUID()
    {
        return System.Guid.NewGuid().ToString();
    }

    // General 
    public static void Call_App_Load()
    {
        Debug.Log("App Loaded");

        EventsManager.Create_App_Load_Event(platform);
    }

    public static void Call_Login()
    {
        Debug.Log("User logged in");

        // Log 기록을 남기는 용도
        // 잠시 주석 처리
        /*EventsManager.Create_Login_Event(platform);*/
    }

    public static void Call_Signup()
    {
        Debug.Log("User signedup in");

        EventsManager.Create_Signup_Event(country, platform);
    }

    // In App Purchase Gem Coin Packs
    public static void Buy_Small_Gem_Pack()
    {
        Debug.Log("Small Coin Pack Purchased");

        int item_id = 1;
        string item_name = "Small Coin Pack";
        int item_amount = 50;
        double real_value = 0.99;
        int virtual_value = 0;
        string receipt = GetUUID();

        EventsManager.Create_Transaction_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Medium_Gem_Pack()
    {
        Debug.Log("Medium Coin Pack Purchased");

        int item_id = 2;
        string item_name = "Medium Coin Pack";
        int item_amount = 500;
        double real_value = 2.99;
        int virtual_value = 0;
        string receipt = GetUUID();

        EventsManager.Create_Transaction_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Large_Gem_Pack()
    {
        Debug.Log("Large Coin Pack Purchased");

        int item_id = 3;
        string item_name = "Large Coin Pack";
        int item_amount = 2500;
        double real_value = 9.99;
        int virtual_value = 0;
        string receipt = GetUUID();

        EventsManager.Create_Transaction_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Premium_Gem_Pack()
    {
        Debug.Log("Premium Coin Pack Purchased");

        int item_id = 4;
        string item_name = "Premium Coin Pack";
        int item_amount = 10000;
        double real_value = 29.99;
        int virtual_value = 0;
        string receipt = GetUUID();

        EventsManager.Create_Transaction_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    // Virtual Goods
    public static void Buy_Rainbow_Hat()
    {
        Debug.Log("Rainbow Hat Purchased");

        int item_id = 5;
        string item_name = "Rainbow Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 2000;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Unicorn_Hat()
    {
        Debug.Log("Unicorn Hat Purchased");

        int item_id = 6;
        string item_name = "Unicorn Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 2000;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Frost_Hat()
    {
        Debug.Log("Frost Hat Purchased");

        int item_id = 7;
        string item_name = "Frost Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 2000;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Love_Hat()
    {
        Debug.Log("Love Hat Purchased");

        int item_id = 8;
        string item_name = "Love Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 1250;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Poo_Hat()
    {
        Debug.Log("Poo Hat Purchased");

        int item_id = 9;
        string item_name = "Poo Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 1250;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Glass_Hat()
    {
        Debug.Log("Glass Hat Purchased");

        int item_id = 10;
        string item_name = "Glass Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 1250;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Lava_Hat()
    {
        Debug.Log("Lava Hat Purchased");

        int item_id = 11;
        string item_name = "Lava Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 850;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Starry_Hat()
    {
        Debug.Log("Starry Hat Purchased");

        int item_id = 12;
        string item_name = "Starry Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 850;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Student_Hat()
    {
        Debug.Log("Student Hat Purchased");

        int item_id = 13;
        string item_name = "Student Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 850;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Garnet_Hat()
    {
        Debug.Log("Garnet Hat Purchased");

        int item_id = 14;
        string item_name = "Garnet Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 500;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Lime_Hat()
    {
        Debug.Log("Lime Hat Purchased");

        int item_id = 15;
        string item_name = "Lime Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 500;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

    public static void Buy_Lavender_Hat()
    {
        Debug.Log("Lavender Hat Purchased");

        int item_id = 16;
        string item_name = "Lavender Hat";
        int item_amount = 1;
        double real_value = 0.00;
        int virtual_value = 500;
        string receipt = GetUUID();

        EventsManager.Create_Virtual_Goods_Event(item_id, item_name, item_amount, real_value, virtual_value, currency, country, platform, receipt);
    }

}
