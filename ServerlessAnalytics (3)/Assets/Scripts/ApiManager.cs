using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{
   private const string Api = "https://e8ss0gdtyc.execute-api.ap-northeast-2.amazonaws.com/deploy";
   private AuthenticationManager _authenticationManager;

   public void CallTest()
    {
        CallTestApi();
    }

   public async void CallTestApi()
   {
      UnityWebRequest webRequest = UnityWebRequest.Get(Api);

      // "Include the identity token in the Authorization header... "
      // Doesn't seem to need the 'Bearer' term in front of the token... IT'S A BEAR DAAAAAAAANCE!!!!
      // https://docs.aws.amazon.com/apigateway/latest/developerguide/apigateway-invoke-api-integrated-with-cognito-user-pool.html
      webRequest.SetRequestHeader("authorizer", /*_authenticationManager.GetIdToken()*/Cognito.access_Token);

      await webRequest.SendWebRequest();

      if (webRequest.result != UnityWebRequest.Result.Success)
      {
         Debug.Log("API call failed: " + webRequest.error + "\n" + webRequest.result + "\n" + webRequest.responseCode);
      }
      else
      {
         Debug.Log("Success, API call complete!");
         Debug.Log(webRequest.downloadHandler.text);
            Debug.Log("Data_" + webRequest.downloadHandler.data);


      }
      webRequest.Dispose();
   }

   void Awake()
   {
      _authenticationManager = FindObjectOfType<AuthenticationManager>();
   }
}
