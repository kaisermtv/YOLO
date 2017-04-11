﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for FacebookApi
/// </summary>
public class FacebookApi : DataClass
{
    /*
        Khai báo các Token , Api Secret key
     */

    
    private static String fields = "full_picture,picture,link,message,created_time";
    private static String limit = "5";
    private static String access_token = @"EAACEdEose0cBAMCEH1rNEACuo5rCj1ZAwhAlLopJDUCqhHJUPa3YkBosZBCteA8mxk4IJKBtAQMsQWlp7PXaZC2IBzI4zey8Wh4GRrglAwvDZBDZCWbH4iVeMTTO24UcWOBQJJG78qBsLc6uYt89QU8XPT8ZBrlFEnx0ot8DHzBfZBPH5lW749yRNwnAwVEmIsZD";
    private static string site_id = "ngheansunshine";
    private string url = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limit + "&access_token=" +access_token + "";
    private string url2 = @"https://graph.facebook.com/ngheansunshine/posts?fields=full_picture,picture,link,message,created_time&limit=5&access_token=https://graph.facebook.com/ngheansunshine/posts?fields=full_picture,picture,link,message,created_time&limit=5&access_token=EAAbazmfYd8gBAEeLHQuUZC61YRka9XEOU4eUOtuSmFaZAVF1i6vDuUQk752xfZANGpZCJjOtqm0ZBR91ZCH6zR64QvNsfYxcyRJaQTIXrF1C6Fnfxe4gfLmxMTmzmtsSLJyfZBPPcHx6o9wSxgyeOTdWF2EramU6S4ZD";
    /*
        Thực hiện lấy dử liệu và đưa vào database
        Cho phép load lại dử liệu / bài viết đả xóa ở fb
     
     * * */
    

	public FacebookApi()
	{

	}
    public void refress()
    {
        // refresh database here !
    }

    #region saveAllToDb                        || Save getJson -> Parse Object -> saveto SqlServer || run in first time
    public int saveAllToDb()
    {
        string json = getJsonString(30);
        if (json == "") return 0;
        FbPosts post = null;
        try { 
         post = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            }
        catch
        {
            // sự cố , lấy mới token bằng đệ trình token củ còn hợp lệ
           try{
             string url_try = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limit + "&access_token=" +getNewAccessToken() + "";
             json = getJsonString(30,url_try);
             post = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
           }
           catch
           {
               Debug.WriteLine("[ERROR ] - CANNOT parse URL , TOKEN Maybe not valin");
               return -1;
           }
         }
        string value = "";
        foreach (var item in post.data)
        {
         //   FbPosts p = new FbPosts(item.id, item.message, item.full_picture, item.picture, item.link, item.created_time);
            value += @"( " + item.id.Split('_')[1].ToString() + ", N' " + item.message + " ' , " + item.full_picture + " , " + item.picture + " , " + item.link + " , " + item.created_time + ") ,";
        }
        value = value.Substring(0,value.Length - 1);        // xóa bớt ký tự cuối cùng
        if (insertMultiValue(value) != 1) return -1;
       return 1;
    }
    #endregion

    #region refresh                        || Save getJson -> Parse Object -> update for SqlServer || run in first time
    public int refresh()
    {
        string json = getJsonString(5); // lấy 5 bài mới nhất thôi
        FbPosts post = null;
        try
        {
            // json = null
            post = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            if (post.data.Count < 1) return 0;
        }
        catch
        {
            // sự cố , lấy mới token bằng đệ trình token củ còn hợp lệ
            try
            {
                string url_try = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limit + "&access_token=" + getNewAccessToken() + "";
                json = getJsonString(10, url_try);      // lấy 10 bài mới nhất
                post = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            }
            catch
            {
                Debug.WriteLine("[ERROR ] - CANNOT parse URL , TOKEN Maybe not valin");
                return -1;
            }
        }
       
        foreach (var item in post.data)
        {
         //   FbPosts p = new FbPosts(item.id, item.message, item.full_picture, item.picture, item.link, item.created_time);
            insertValueWithCheckExist(item.id.Split('_')[1].ToString(), item.message, item.full_picture, item.picture, item.link, item.created_time);   
        }
    
        return 1;
    }
    #endregion
    // facebook auto change token by time
    #region getNewAccessToken()                 || try to get new token when not valin
    public string getNewAccessToken()
    {

        string urlGetToken = @"https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=1929429900621768&client_secret=f772af8c938d9b284ee22022b791c78b&fb_exchange_token=EAAbazmfYd8gBAMx3rezhTwBkSviDkZAzIXS4SZCt8kRBExskhu5rnp2HAlxoD9V0ZAOMA7JQUHytypegPDanjQ07ZCwh7ZBMnn3uaAAzbJB7NCknGkLUSgC0Kg3LV7U1b39fsKJNqUzZButRnbEbldrN2CpsdstRZBT8tZC8UTBVFMa7JnRwZBaeCHJZCjmnQxwCAZD";

        var objTmp = Newtonsoft.Json.Linq.JObject.Parse(getJsonString(0,urlGetToken));
        var token =(string) objTmp["access_token"];
        return token;
    }
    #endregion

    #region insertMutiLineValue()           ||Cấu hình bảng || Đưa vào cơ sở dử liệu
    public int insertMultiValue(string value)
    {
        try {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConnect"].ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @" IF (OBJECT_ID('tblFacebookPost') is not null )
                                            BEGIN  
                                                           INSERT INTO tblFacebookPost (id,message,full_picture,picture,link,created_time) VALUES         
                                                           (
                                                            "+value + @"
                                                            )   ;  
                                            END 
                                        ELSE BEGIN    
                                            CREATE  TABLE tblFacebookPost (PostId int identity(1,1)  not null primary key,id char(30) ,message nvarchar(max) ,full_picture char(450) ,picture char(450) ,link char(500),created_time char(30) , time_sync datetime default getdate()  )   ;                           
                                             
                                              END   
                                                    ";
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            return 1;
        }
        catch(Exception e)
        {
            Debug.WriteLine("[ERROR] : " + e.GetBaseException());
            return -1;
        }

    }
#endregion

    #region insertValueWithCheckExist()           | Đưa vào cơ sở dử liệu , kiểm tra xem bài viết tồn tại chưa
    public int insertValueWithCheckExist(string id,string message,string full_picure,string picture, string link , string create_time)
    {
        if (id == null) return 0;
        try
        {
            SqlCommand Cmd = this.getSQLConnect(); 
            Cmd.CommandText = @" 
                            IF NOT EXISTS (SELECT tblFacebookPost.id FROM tblFacebookPost WHERE tblFacebookPost.id = @id )
                            BEGIN
                INSERT INTO tblFacebookPost (id,message,full_picture,picture,link,create_time) VALUES 
                        (  @id , @message , @full_picture , @picture , @link , @create_time )
                            END
                           ";
            Cmd.Parameters.Add("id", SqlDbType.Char).Value = (id);
            Cmd.Parameters.Add("message", SqlDbType.NVarChar).Value = (message == null ? " " : message  );
            Cmd.Parameters.Add("full_picture", SqlDbType.Char).Value = ( full_picure == null ? " ": full_picure );
            Cmd.Parameters.Add("picture", SqlDbType.Char).Value = ( picture == null ? " ": picture );
            Cmd.Parameters.Add("link", SqlDbType.Char).Value = ( link == null ? " " : link) ;
            Cmd.Parameters.Add("create_time", SqlDbType.Char).Value = create_time;
            Cmd.ExecuteNonQuery();
            this.SQLClose();
            return 1;
        }
        catch (Exception e)
        {
            Debug.WriteLine("[ERROR] FB POST UPDATE TO DATABASE : " + e.GetBaseException());
            return -1;
        }

    }
    #endregion

    #region getJsonString                       
    public string getJsonString( int limits = 200 , string urls= "")
    {
        if(urls == "") url = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limits + "&access_token=" + access_token + "";
        else { url = urls; }
        try
        {
            var json = "";
             var client = new WebClient();
             client.Headers.Add("Content-Type", "application/json");
             json = client.DownloadString(url);
             Console.WriteLine("===" + json);
             return json;
        }
        catch(Exception e)
        {
            Debug.WriteLine("[Error] Cannot download json : " + e.GetBaseException());
            return "";
        }

    }
    #endregion

   

}