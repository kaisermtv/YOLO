﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for FakebookAPI
/// </summary>
public class FacebookAPI
{
    #region static declare 
    private static string fields = "id,type,name,full_picture,picture,link,message,created_time";
    private static string fields_album = "photos{images,name,link,likes.limit(0).summary(true), comments.limit(0).summary(true),  created_time}";          // chú ý không dùng created_time trong comments
    private static string token = "1972725952949362|91b3fca08e2a493e72610dad124d1beb";

    private static string PageName = "yolomobifone";
    private static string PageID = "262884504159437";
    private static string ApiUrl = @"https://graph.facebook.com/v2.9/";
    #endregion

    #region Even FacebookAPI
    public FacebookAPI()
    {
        //DataSetting objSetting = new DataSetting();
        //token = objSetting.getValue("Facebook_Token");
    }
    #endregion

    #region declare
    private string nextPost = null;

    #endregion

    #region Method getTopPostPage
    public dynamic getTopPostPage(int limit = 1)
    {
        string url = ApiUrl + PageID + "/posts?fields=" + fields; 

        if(limit > 0)
        {
            url += "&limit=" + limit.ToString();
        }

        url += "&access_token=" + token;


        dynamic ret = getUrlJson(url);
        if (ret == null)
        {
            nextPost = null;
            return null;
        }

        nextPost = ret.paging.next;


        return ret;
    }
    #endregion

    #region getNextPostPage
    public dynamic getNextPostPage()
    {
        if (nextPost == null || nextPost == "") return null;

        dynamic ret = getUrlJson(nextPost);
        if (ret == null)
        {
            nextPost = null;
            return null;
        }

        nextPost = ret.paging.next;

        return ret;
    }
    #endregion

    #region getUrlJson
    public dynamic getUrlJson(string url)
    {
        try
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string txt = client.DownloadString(url);


            Debug.WriteLine(txt);

            //Debug.WriteLine("====== GET JSON STRING  " + json);
            return JsonConvert.DeserializeObject(txt);
        }
        catch (Exception e)
        {
            //Debug.WriteLine("[Error] Cannot download json : " + e.GetBaseException());

            //throw e;
            return null;
        }
    }
    #endregion

    

}