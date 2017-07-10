using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;
//using Facebook;
using System.IO;
using System.Data;
using System.Dynamic;

/// <summary>
/// Summary description for FakebookAPI
/// </summary>
public class FacebookAPI
{
    #region static declare 
    private static string fields = "id,type,name,full_picture,picture,link,permalink_url,message,shares,created_time,comments.summary(true).limit(0),likes.limit(0).summary(true)";
    private static string Infofields = "id,name,picture,cover";
    private static string fields_album = "photos{images,name,link,likes.limit(0).summary(true), comments.limit(0).summary(true),  created_time}";          // chú ý không dùng created_time trong comments
    private static string token = "1972725952949362|91b3fca08e2a493e72610dad124d1beb";
    private static string PageName = "yolomobifone";
    private static string PageID = "262884504159437";

    //private static string PageName = "Học-Hợp-Ngữ-Assembly-570235299813675";
    //private static string PageID = "570235299813675";

    private static string ApiUrl = @"https://graph.facebook.com/v2.9/";


    public static string App_id = "1972725952949362";
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
    public dynamic getTopPostPage(int limit = 1,string after = "")
    {
        string url = ApiUrl + PageID + "/posts?fields=" + fields; 

        if(limit > 0)
        {
            url += "&limit=" + limit.ToString();
        }

        url += "&access_token=" + token;

        if (after != "") url += "&pretty=0&after=" + after;

        dynamic ret = getUrlJson(url);
        if (ret == null)
        {
            nextPost = null;
            return null;
        }

        try
        {
            nextPost = ret.paging.next;
        } catch {

        }


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
            //client.
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

    #region postUrlJson
    public dynamic postUrlJson(string url, dynamic param)
    {
        try
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");


            string txt = client.UploadString(url, JsonConvert.SerializeObject(param));


            //string txt = client.DownloadString(url);
            //client.
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

    #region Method getInfoPage
    public dynamic getInfoPage()
    {
        string url = ApiUrl + PageName + "?fields=" + Infofields;


        url += "&access_token=" + token;

        dynamic ret = getUrlJson(url);

        return ret;
    }
    #endregion

    #region method getCountLikesById
    public string getCountLikesById(string post_id)
    {
        try
        {
            string url = ApiUrl + post_id + "/likes?summary=true&limit=0";

            url += "&access_token=" + token;

            dynamic ret = getUrlJson(url);

            return ret.summary.total_count;
        }
        catch
        {
            return "0";
        }
    } 
    #endregion

    #region method getCountSharesById
    public string getCountSharesById(string post_id)
    {
        try
        {
            //string url = ApiUrl + post_id + "/share";

            //url += "&access_token=" + token;

            //dynamic ret = getUrlJson(url);

            //return ret.summary.total_count;

            //FacebookClient fb = new FacebookClient(token);
            //var like = fb.Get(post_id + "/share");
            //dynamic objData = JsonConvert.DeserializeObject(like.ToString());
            //return objData.summary.total_count;

            return "0";
        }
        catch
        {
            return "0";
        }
    }
    #endregion

    #region method getCountCommentsById
    public string getCountCommentsById(string post_id)
    {
        try
        {
            string url = ApiUrl + post_id + "/comments?summary=true&limit=0";

            url += "&access_token=" + token;

            dynamic ret = getUrlJson(url);

            return ret.summary.total_count;

            //FacebookClient fb = new FacebookClient(token);
            //var like = fb.Get(post_id + "/comments?summary=true");
            //dynamic objData = JsonConvert.DeserializeObject(like.ToString());
            //return objData.summary.total_count;
        }
        catch
        {
            return "0";
        }
    }
    #endregion

    #region Method 
    public dynamic Share(string name, string mesage, string link, string picture, string caption = "", string description = "")
    {
        //string url = ApiUrl + "me" + "/feed?access_token=EAACEdEose0cBAJyYMIcZAhlvZAWdvps3imqczEzH7P8vKGHZAcbxVT0UXzlsveNOvv54z1HBPcGMsmza4GbsRhK88WpPzEoSuK6R6Oy88X64je2lokvVE88ZBB7SyMh2lPsI8m9bm9ZAKXVxfiTTKTdpVk8wZC9uWlYYEe18E6qZAdRymzy353HMzEn4JMNsIQZD";// +token;

        string url = ApiUrl + PageID + "/feed?access_token=" +token;

        dynamic parameters = new ExpandoObject();
        parameters.message = mesage;
        parameters.link = link;
        parameters.picture = picture;
        parameters.name = name;
        if (caption != "") parameters.caption = caption;
        if (description != "") parameters.description = description;

        dynamic result = postUrlJson(url, parameters);

        return result;
    }
    #endregion
}