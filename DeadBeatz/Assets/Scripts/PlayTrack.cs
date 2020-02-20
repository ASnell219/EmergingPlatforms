using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayTrack : MonoBehaviour
{
    [SerializeField] Spotify _manager = null;

    public string query;
    public string[] type;

    public void ClickPlay()
    {
        StartCoroutine(PlayTrackTest());
    }

    IEnumerator PlayTrackTest()
    {
        string url = "https://api.spotify.com/v1/search?q=";
        //string url = "https://api.spotify.com/v1/tracks/11dFghVXANMlKmJXsNCbNl";

        url += query + "&";

        url += "type=";
        for (int i = 0; i < type.Length; i++)
        {
            if (i == (type.Length - 1))
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
            uwr.SetRequestHeader("Method", "GET");
            uwr.SetRequestHeader("Accept", "application/json");
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.SetRequestHeader("Authorization", (_manager.TokenObject.token_type + " " + _manager.TokenObject.access_token));

            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
            }
        }
    }
}
