using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class GPGS_Manager : MonoBehaviour
{
    public static GPGS_Manager instance = null;
    public Cognito m_Cognito;

    public static GPGS_Manager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            return null;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public Text u_Log;
    public Text u_LoginId;

    public CredentialsManager m_CredentialsManager;

    public static string _token = "";

    void Start()
    {
        Init();
    }

    public void Init()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration
            .Builder()
            .RequestIdToken()
            .RequestServerAuthCode(false)
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(GoogleLoginCallback);
    }

    void GoogleLoginCallback(bool success, string message)
    {
        if (success)
        {
            string token = PlayGamesPlatform.Instance.GetIdToken();
            string serverAuth = PlayGamesPlatform.Instance.GetServerAuthCode();

            if(token == null || token == "")
            {
                u_Log.text = "wtf?"; 
            }
            else
            {
                u_Log.text = "hi?" + token; // text 
                _token = token;
            }
            
            u_LoginId.text = Social.localUser.id;
            Debug.Log(token);
            Debug.Log(serverAuth);
        }
        else
        {
            u_Log.text = message; // text  
            Debug.LogError("Google Login failed. If you are runnig in an actual Android/ IOS device, this is expected");
        }
    }

    public void AddLogin()
    {
        m_Cognito.Login(_token);
    }

}
