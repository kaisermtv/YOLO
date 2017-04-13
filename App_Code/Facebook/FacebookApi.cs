using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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


    private static String fields = "full_picture,picture,link,message,likes{name,id},comments,created_time";
    private static String limit = "5";
    private static String access_token = @"EAAbazmfYd8gBAEeLHQuUZC61YRka9XEOU4eUOtuSmFaZAVF1i6vDuUQk752xfZANGpZCJjOtqm0ZBR91ZCH6zR64QvNsfYxcyRJaQTIXrF1C6Fnfxe4gfLmxMTmzmtsSLJyfZBPPcHx6o9wSxgyeOTdWF2EramU6S4ZD";
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
      //  string json = getJsonString(5); // lấy 5 bài mới nhất thôi
        FbPosts lpost = new FbPosts("", "", "", "", "", "", new List<comments>(), new List<likes>());
        lpost.data = new List<FbPosts>();
        try
        {
            //  lpost = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            dynamic struff = JsonConvert.DeserializeObject(json);

            JArray data = struff.data;

            foreach (JObject element in data)
            {
                List<comments> lc = new List<comments>();
                List<likes> ll = new List<likes>();
                if (element["comments"] != null)
                {
                    Debug.WriteLine(element["comments"].ToString());
                    string comments = element["comments"].ToString();
                    dynamic struff_comment = JsonConvert.DeserializeObject(comments);
                    lc = new List<comments>();
                    foreach (JObject element2 in struff_comment.data)
                    {
                        lc.Add(new comments(element2["message"].ToString(), element2["id"].ToString(), element2["from"].ToString(), element2["created_time"].ToString()));
                        Debug.WriteLine(element2["message"].ToString());
                    }
                }
                if (element["likes"] != null)
                {
                    string likes = element["likes"].ToString();
                    dynamic struff_likes = JsonConvert.DeserializeObject(likes);
                    foreach (JObject element3 in struff_likes.data)
                    {
                        ll.Add(new likes(element3["id"].ToString(), element3["name"].ToString()));
                        Debug.WriteLine(element3["name"].ToString());
                    }
                }
                lpost.data.Add(new FbPosts(
                    element["id"] == null ? " " : element["id"].ToString(),
                    element["message"] == null ? " " : element["message"].ToString(),
                    element["full_picture"] == null ? " " : element["full_picture"].ToString(),
                    element["picture"] == null ? " " : element["picture"].ToString(),
                    element["link"] == null ? " " : element["link"].ToString(),
                    element["created_time"] == null ? " " : element["created_time"].ToString(),
                      lc == null ? new List<comments>() : lc,
                      ll == null ? new List<likes>() : ll
                    ));
            }
            if (lpost.data.Count < 1) return 0;
        }
        catch(Exception e)
        {
            Debug.WriteLine("[ERROR]" + e.GetBaseException() );
        }
      //  string value = "";
        foreach (var item in lpost.data)
        {
         //   value += @"( " + item.id.Split('_')[1].ToString() + ", N' " + item.message + " ' , " + item.full_picture + " , " + item.picture + " , " + item.link + " , " + item.created_time + "," + item.comments.Count.ToString() + "," + item.likes.Count.ToString() + "),";
            insertValueWithCheckExist(item.id.Split('_')[1].ToString(), item.message, item.full_picture, item.picture, item.link, item.created_time, item.comments.Count.ToString(), item.likes.Count.ToString());   
        }
        // value = value.Substring(0,value.Length - 1);        // xóa bớt ký tự cuối cùng
        //if (insertMultiValue(value) != 1) return -1;
       return 1;
    }
    #endregion

    #region refresh                        || Save getJson -> Parse Object -> update for SqlServer || run in first time
    public int refresh()
    {
        string json = getJsonString(5); // lấy 5 bài mới nhất thôi
        FbPosts lpost =  new FbPosts("","","","","","",new List<comments>() ,new List<likes>());
        lpost.data = new List<FbPosts>();
        try
        {
          //  lpost = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            dynamic struff = JsonConvert.DeserializeObject(json);
            JArray data = struff.data;
            foreach (JObject element in data)
           {
               List<comments> lc = new List<comments>();
               List<likes> ll = new List<likes>();
               if (element["comments"]!=null)
               {
              Debug.WriteLine(element["comments"].ToString());
              string comments = element["comments"].ToString();
              dynamic struff_comment = JsonConvert.DeserializeObject(comments);
              lc = new List<comments>();
              foreach (JObject element2 in struff_comment.data)
              {
                  lc.Add( new comments(element2["message"].ToString(), element2["id"].ToString(), element2["from"].ToString(), element2["created_time"].ToString()));
                  Debug.WriteLine(element2["message"].ToString());  
              }
              }
               if (element["likes"] != null)
               {
                   string likes = element["likes"].ToString();
                   dynamic struff_likes = JsonConvert.DeserializeObject(likes);
                   foreach (JObject element3 in struff_likes.data)
                   {
                       ll.Add(new likes(element3["id"].ToString(), element3["name"].ToString()));
                       Debug.WriteLine(element3["name"].ToString());
                   }
               }
                lpost.data.Add(new FbPosts(
                    element["id"] == null ? " " : element["id"].ToString(),
                    element["message"] == null ? " " : element["message"].ToString(),
                    element["full_picture"] == null ? " " : element["full_picture"].ToString(),
                    element["picture"]== null ? " " : element["picture"].ToString(),
                    element["link"]== null ? " " : element["link"].ToString(),
                    element["created_time"]== null ? " " : element["created_time"].ToString(),
                      lc == null ? new List<comments>() : lc,
                      ll == null ? new List<likes>() : ll
                    )); 
           }
        if (lpost.data.Count < 1) return 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine("[ERROR ] - ADD OBJECT " + e.GetBaseException());
            // sự cố , lấy mới token bằng đệ trình token củ còn hợp lệ
            try
            {
                string url_try = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limit + "&access_token=" + getNewAccessToken() + "";
                json = getJsonString(10, url_try);      // lấy 10 bài mới nhất
                lpost = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            }
            catch
            {
                Debug.WriteLine("[ERROR ] - CANNOT parse URL , TOKEN Maybe not valin");
                return -1;
            }
        }
        foreach (var item in lpost.data)
        {
         //   FbPosts p = new FbPosts(item.id, item.message, item.full_picture, item.picture, item.link, item.created_time);

            insertValueWithCheckExist(item.id.Split('_')[1].ToString(), item.message, item.full_picture, item.picture, item.link, item.created_time, item.comments.Count.ToString(), item.likes.Count.ToString());   
        }
        return 1;
    }
    #endregion
    // facebook auto change token by time
    #region getNewAccessToken()                 || try to get new token when not valin
    public string getNewAccessToken()
    {
        // hoặc nhờ người quản trị nhập vào ... 
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
                                                           INSERT INTO tblFacebookPost (id,message,full_picture,picture,link,created_time,comments,likes) VALUES         
                                                           (
                                                            " + value + @"
                                                            )   ;  
                                            END 
                                        ELSE BEGIN    
                                            CREATE  TABLE tblFacebookPost (PostId int identity(1,1)  not null primary key,id char(30) ,message nvarchar(max) ,full_picture char(450) ,picture char(450) ,link char(500),created_time char(30) ,comments nvarchar(10),likes nvarchar(10), time_sync datetime default getdate()  )   ;                           
                                             
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
    public int insertValueWithCheckExist(string id, string message, string full_picure, string picture, string link, string create_time, string lc_count ,string ll_count)
    {
        if (id == null) return 0;
        try
        {
            SqlCommand Cmd = this.getSQLConnect(); 
            Cmd.CommandText = @" 
                            IF NOT EXISTS (SELECT tblFacebookPost.id FROM tblFacebookPost WHERE tblFacebookPost.id = @id )
                            BEGIN
                INSERT INTO tblFacebookPost (id,message,full_picture,picture,link,create_time,comments,likes) VALUES 
                        (  @id , @message , @full_picture , @picture , @link , @create_time, @comments , @likes )
                            END
                        ELSE 
                    BEGIN 
                UPDATE  tblFacebookPost SET message = @message,full_picture=@full_picture,picture=@picture,comments=@comments,likes = @likes 
                        WHERE tblFacebookPost.id = @id
                    END
                           ";
            Cmd.Parameters.Add("id", SqlDbType.Char).Value = (id);
            Cmd.Parameters.Add("message", SqlDbType.NVarChar).Value = (message == null ? " " : message  );
            Cmd.Parameters.Add("full_picture", SqlDbType.Char).Value = ( full_picure == null ? " ": full_picure );
            Cmd.Parameters.Add("picture", SqlDbType.Char).Value = ( picture == null ? " ": picture );
            Cmd.Parameters.Add("link", SqlDbType.Char).Value = ( link == null ? " " : link) ;
            Cmd.Parameters.Add("create_time", SqlDbType.Char).Value = create_time;
            Cmd.Parameters.Add("comments", SqlDbType.NVarChar).Value = (lc_count == null ? "0" : lc_count);
            Cmd.Parameters.Add("likes", SqlDbType.Char).Value =( ll_count == null ? "0" : ll_count) ;
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
            
            Debug.WriteLine("====== GET JSON STRING  " + json);
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