using System;
using UnityEngine;
using Amazon;
using Amazon.CognitoIdentity;


public class CredentialsManager
{

    // Region - A game may need multiple region endpoints if services
    // are in multiple regions or different per service
    public static RegionEndpoint region = RegionEndpoint.APNortheast2; //change this if you are in a different region

    // Cognito Credentials Variables
    public const string identityPool = "ap-northeast-2:573780d0-093f-473a-a585-08a0ee06dcb2";
    public static string userPoolId = "ap-northeast-2_WOzzlihNh";
    public static string appClientId = "575is8oia1241f0njck1ni303p";

    // Initialize the Amazon Cognito credentials provider
    public static CognitoAWSCredentials credentials = new CognitoAWSCredentials(
        identityPool, region
    );

    // User's Cognito ID once logged in becomes set here
    public static string userid = "";

}
