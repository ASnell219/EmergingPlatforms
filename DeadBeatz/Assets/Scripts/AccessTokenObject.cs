using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccessTokenObject
{
    public string access_token;
    public string token_bearer;
    public int expires_in;

    public string AccessToken 
    { 
        get { return access_token; }
    }

    public string TokenBearer 
    { 
        get { return token_bearer; }
    }

    public int Expiration 
    { 
        get { return expires_in; }
    }

}
