using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;

public class Spotify : MonoBehaviour
{
    private string ClientID = "cdab467846d14387a71ae93dde547fda";
    private string ClientSecret = "7600b7b0140c4168a8ac192a5085b9da";
    private AccessTokenObject accessTokenObject;

    public AccessTokenObject TokenObject { get { return accessTokenObject; } set { accessTokenObject = value; } }

    public void Start()
    {
        StartCoroutine(Request());
    }

    IEnumerator Request()
    {
        byte[] bytesToEncode = Encoding.UTF8.GetBytes(ClientID + ":" + ClientSecret);
        string encodedText = Convert.ToBase64String(bytesToEncode);

        WWWForm form = new WWWForm();
        
        form.AddField("grant_type", "client_credentials");
        
        using (UnityWebRequest uwr = UnityWebRequest.Post("https://accounts.spotify.com/api/token", form))
        {
            uwr.SetRequestHeader("Method", "POST");
            uwr.SetRequestHeader("Authorization", "Basic " + encodedText);

            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                print(uwr.error);
            }
            else
            {
                TokenObject = JsonUtility.FromJson<AccessTokenObject>(uwr.downloadHandler.text);
                Debug.Log(uwr.downloadHandler.text);
            }
        }
    }
}
