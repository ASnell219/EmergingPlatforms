using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayTrack : MonoBehaviour
{
    [SerializeField] Spotify _manager;

    public string q;
    public string[] type;

    public void ClickPlay()
    {
        StartCoroutine(PlayTrackTest());
    }

    IEnumerator PlayTrackTest()
    {
        string url = "https://accounts.spotify.com/v1/search?q=";
        url += q;

        for(int i = 0; i < type.Length; i++)
        {
            if(i == (type.Length - 1))
            {
                url += type[i];
            }
            else
            {
                url = url + type[i] + "%2C";
            }
        }
        
        using (UnityWebRequest uwr = UnityWebRequest.Get(url))
        {
            uwr.SetRequestHeader("Accept", "application/json");
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.SetRequestHeader("Authorization", _manager.TokenObject.TokenBearer.ToString() + " " + _manager.TokenObject.AccessToken.ToString());

            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                print(uwr.error);
            }
            else
            {
                print("track");
            }
        }
    }
}
