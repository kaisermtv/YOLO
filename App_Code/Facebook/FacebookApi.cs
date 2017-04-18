﻿using Newtonsoft.Json;
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

public class FacebookApi : DataClass
{

    private static String fields = "full_picture,picture,link,message,likes{name,id},comments,created_time";
    private static string fields_album = "photos{images,name,link,likes.limit(0).summary(true), comments.limit(0).summary(true),created_time}";          // chú ý không dùng created_time trong comments
   // private static String access_token = @"EAAbazmfYd8gBAEeLHQuUZC61YRka9XEOU4eUOtuSmFaZAVF1i6vDuUQk752xfZANGpZCJjOtqm0ZBR91ZCH6zR64QvNsfYxcyRJaQTIXrF1C6Fnfxe4gfLmxMTmzmtsSLJyfZBPPcHx6o9wSxgyeOTdWF2EramU6S4ZD";
    private static string site_id = "ngheansunshine";
    private static string album_id = "790172047808833";
    //  private string url = @"https://graph.facebook.com/"+site_id+"/posts?fields=" + fields + "&limit=" + limit + "&access_token=" +access_token + "";
    //   private string url_album = @"https://graph.facebook.com/" + album_id + "?fields=" + fields_album + "&limit=" + 30 + "&access_token=" + access_token + "";
    private static string key_db = "Facebook_Token";
    private static string album_key_id = "yolodamchiase";
    //  private string url2 = @"https://graph.facebook.com/790172047808833?fields=photos{link,likes{id,username},name,picture,comments{message,from},page_story_id}&limit=5&access_token=https://graph.facebook.com/ngheansunshine/posts?fields=full_picture,picture,link,message,created_time&limit=5&access_token=EAAbazmfYd8gBAEeLHQuUZC61YRka9XEOU4eUOtuSmFaZAVF1i6vDuUQk752xfZANGpZCJjOtqm0ZBR91ZCH6zR64QvNsfYxcyRJaQTIXrF1C6Fnfxe4gfLmxMTmzmtsSLJyfZBPPcHx6o9wSxgyeOTdWF2EramU6S4ZD";
    /*
        Thực hiện lấy dử liệu và đưa vào database
        Cho phép load lại dử liệu / bài viết đả xóa ở fb
     
     * * */
	public FacebookApi()
	{
	}
    public int refressPhotoPost(int limits = 30)   // lấy 30 bài mới nhất  "refresh"
    {
        string json = getJsonString(2, limits);              // kiểu số 2          
        if (json == null || json.Trim() == "") return 0;
        FbPhotoAlbum lPpost = new FbPhotoAlbum("", "", "", "","", new comments(), new likes());
        try
        {
            lPpost.data = parseJsonToPhotoPosts(json);                // lấy bài viết thông thường
            foreach (var item in lPpost.data)
            {
                insertPhotoPostValueWithCheckExist(item.id, item.name, item.picture, item.link,item.create_time, item.comments.summary, item.likes.summary);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine("=[EURROR] CANNOT REFRESH THE POST of Article FROM FB:  " + e.GetBaseException());
            return 0;
        }
       
        return 1;
    }

    #region saveAllPostToDb                        || Save getJson -> Parse Object -> saveto SqlServer || run in first time
    public int saveAllPostToDb(int type=1,int limits=30)
    {
        string json = getJsonString(type,limits);
        try { 
        switch(type)
        {
            case 1: {
                FbPosts lpost = new FbPosts("", "", "", "", "", "", new List<comments>(), new List<likes>());
                lpost.data = parseJsonToPosts(json);

                foreach (var item in lpost.data)
                {
                    insertValueWithCheckExist(item.id.Split('_')[1].ToString(), item.message, item.full_picture, item.picture, item.link, item.created_time, item.comments.Count.ToString(), item.likes.Count.ToString());
                }
                break;
            }          //mặc định là bài viết trên timeline feed
            case 2:
                {
                    FbPhotoAlbum lphoto_post = new FbPhotoAlbum("", "", "", "","", new comments(), new likes());
                    lphoto_post.data = parseJsonToPhotoPosts(json);

                    foreach (var item in lphoto_post.data)
                    {
                        insertPhotoPostValueWithCheckExist(item.id, item.name, item.picture, item.link, item.comments.summary, item.likes.summary,item.create_time);
                    }

                    break;
                }
            default: break;
        }
        }
        catch(Exception e)
        {
            Debug.WriteLine("[Error] KHÔNG THỂ CẬP NHẬT CÁC THÔNG TIN VÀO DATABASE" + e.GetBaseException());
            return 0;
        }
       return 1;
    }
    #endregion

    #region parseJsonToPhotoPosts     // 1 bài viết chỉ có 1 ảnh / cuộc thi  
    public List<FbPhotoAlbum> parseJsonToPhotoPosts(string json)
    {
        string [] json_arr = new string [10];
        
        FbPhotoAlbum lphoto_post = new FbPhotoAlbum("", "", "", "", "", new comments(), new likes());
        lphoto_post.data = new List<FbPhotoAlbum>();
        try
        {
            //  lpost = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            dynamic struff = JsonConvert.DeserializeObject(json);
            JArray data = struff.photos.data;                //  gốc cây nhị phân có tên là photos 
            var next_data = struff.photos.paging;
            int i = 0;

            while (next_data["next"] != null)
            {
                try { 
                json_arr[i] = getJsonString(3,25,next_data["next"].ToString());
                struff = JsonConvert.DeserializeObject(json_arr[i]);
               
                i++;
                Debug.WriteLine(i);
                next_data = struff.paging;
                }
                catch { break; }
            }

            foreach (string s in json_arr)
            {
                if(s!=null)
                {
                    try
                    {
                        dynamic struff2 = JsonConvert.DeserializeObject(s);
                        foreach(JObject j in struff2.data )
                        {
                            if(j!=null)
                            {
                                data.Add(j);
                                Debug.WriteLine(j);
                            }
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        
            foreach (JObject element in data)
            {
                    comments lc = new comments();
                    likes ll = new likes();
                    if (element["comments"] != null)
                    {
                        Debug.WriteLine(element["comments"].ToString());
                        string comments = element["comments"].ToString();
                        dynamic struff_comment = JsonConvert.DeserializeObject(comments);

                        lc.summary = struff_comment["summary"]["total_count"].ToString() == null ? " 0" : struff_comment["summary"]["total_count"].ToString();
                        Debug.WriteLine(ll.summary);
                    }
                    if (element["likes"] != null)
                    {
                        string likes = element["likes"].ToString();
                        dynamic struff_likes = JsonConvert.DeserializeObject(likes);
                        ll.summary = struff_likes["summary"]["total_count"].ToString() == null ? " 0" : struff_likes["summary"]["total_count"].ToString();
                            Debug.WriteLine(ll.summary);
                    }
                 
                    lphoto_post.data.Add(
                      new FbPhotoAlbum(
                      element["id"] == null ? " " : element["id"].ToString(),             // PHOTO ID
                      element["name"] == null ? " " : convertName( element["name"].ToString()),         // MIÊU TẢ ẢNH
                      element["images"] == null ? " " : element["images"][0]["source"].ToString() ==null ? "" : element["images"][0]["source"].ToString(), // ẢNH LỚN NHẤT
                      element["link"] == null ? " " : element["link"].ToString(),
                        element["create_time"] == null ? "" : element["create_time"].ToString(),
                        lc == null ? new comments() : lc,
                        ll == null ? new likes() : ll
                     
                       ));
                  
                }
           // }
            if (lphoto_post.data.Count < 1) return new List<FbPhotoAlbum>();
        }
        catch (Exception e)
        {
            Debug.WriteLine("[ERROR ] - ADD Photo Posts " + e.GetBaseException());
            return new List<FbPhotoAlbum>();
        }
        return lphoto_post.data;        // danh sách bài viết ảnh
    }
    #endregion

    #region parseJsonToPosts                // 1 bài viết thông thường   // có thể thiếu sót ảnh khi bài viết nhiều ảnh và tương đương nhau
    public List<FbPosts> parseJsonToPosts(string json)
    {
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
            if (lpost.data.Count < 1) return new List<FbPosts>();
        }
        catch (Exception e)
        {
            Debug.WriteLine("[ERROR ] - ADD Photo Posts " + e.GetBaseException());
            return new List<FbPosts>();
        }
        return lpost.data;        // danh sách bài viết ảnh
    }
    #endregion

    #region refreshPost                        || Save getJson -> Parse Object -> update for SqlServer || run in first time
    public int refreshPost(int limits=30)
    {
        string json = getJsonString(1, limits);                        // lấy 30 bài mới nhất thôi
        if (json == null || json.Trim() == "") return 0;
        FbPosts lpost =  new FbPosts("","","","","","",new List<comments>() ,new List<likes>());
        try { 
            lpost.data = parseJsonToPosts(json);                // lấy bài viết thông thường
            foreach (var item in lpost.data)
            {
                insertValueWithCheckExist(item.id.Split('_')[1].ToString(), item.message, item.full_picture, item.picture, item.link, item.created_time, item.comments.Count.ToString(), item.likes.Count.ToString());   
            }
        }
        catch(Exception e)
        {
            Debug.WriteLine("=[EURROR] CANNOT REFRESH THE POST of Article FROM FB:  " + e.GetBaseException());
            return 0;
        }
        return 1;
    }
    #endregion
    // facebook auto change token by time
    #region setNewAccessToken()                 || try to set new token when not valin
    public int setNewAccessToken(string new_token)
    {
        // hoặc nhờ người quản trị nhập vào ... 
        // lấy từ 1 dòng nào đó của cơ sở dữ liệu 
        // và do người dùng nhập vào
        DataSetting setting = new DataSetting();
        if (setting.setValue(key_db, new_token))
        {
            Debug.WriteLine("=[SUCCESS] UPDATE NEW TOKEN TO DATABASE IN SETTING SUCCESS " + new_token);
            return 1;
        }
        Debug.WriteLine("=[EURROR] CANNOT UPDATE TO SETTING FB TOKEN WITH KEY :  " + key_db );
        return 0;
    }
    #endregion

    #region getNewAccessToken()                 || try to get new token when not valin
    public string getNewAccessToken()
    {
        DataSetting setting = new DataSetting();
              string token = " ";
            token= setting.getValue(key_db);
        // lấy từ 1 dòng nào đó của cơ sở dữ liệu 
        // và do người dùng nhập vào
         if(token!= null || token.Trim() !=""){
            Debug.WriteLine("=[SUCCESS] GET ACCESS TOKEN FROM DATATABLE  " + token);
           }
            Debug.WriteLine("! [ERROR] GET ACCESS TOKEN FROM DATATABLE  IS NULL OR  " + token);
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

    #region insertPhotoPostValueWithCheckExist()           | Đưa vào cơ sở dử liệu , có kiểm tra xem ảnh tồn tại chưa sử dụng id của datatFb
    public int insertPhotoPostValueWithCheckExist(string id, string name, string picture, string link, string lc_count, string ll_count,string create_time)        // chưa cần đến comment và like nên hiện tại đếm số lượng chúng đã
    {
        if (id == null) return 0;
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = @" 
                            IF NOT EXISTS (SELECT tblFacebookPhotoPost.id FROM tblFacebookPhotoPost WHERE tblFacebookPhotoPost.id = @id )
                            BEGIN
                INSERT INTO tblFacebookPhotoPost (id,name,picture,link,comments,likes,create_time) VALUES 
                        (  @id  , @name , @picture , @link , @comments , @likes ,@create_time)
                            END
                        ELSE 
                    BEGIN 
                UPDATE  tblFacebookPhotoPost SET name = @name,picture=@picture,comments=@comments,likes = @likes
                        WHERE tblFacebookPhotoPost.id = @id
                    END
                           ";
            Cmd.Parameters.Add("id", SqlDbType.Char).Value = (id);
            Cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = (name == null ? " " : name);
            Cmd.Parameters.Add("picture", SqlDbType.Char).Value = (picture == null ? " " : picture);
            Cmd.Parameters.Add("link", SqlDbType.Char).Value = (link == null ? " " : link);
            Cmd.Parameters.Add("comments", SqlDbType.NVarChar).Value = (lc_count == null ? "0" : lc_count);
            Cmd.Parameters.Add("likes", SqlDbType.Char).Value = (ll_count == null ? "0" : ll_count);
            Cmd.Parameters.Add("create_time", SqlDbType.Char).Value = (create_time == null ? " " : create_time);
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
    public string getJsonString( int type ,int limits = 50,string urls= "" )
    {
       
        string url = "";
           string  access_token = new DataSetting().getValue(key_db).Trim();
        //có thể lấy album_id hoặc site_id tại csdl
        if (access_token == "") return null ;
        switch(type)
        {
            case 1:
                {
                    url = @"https://graph.facebook.com/" + site_id + "/posts?fields=" + fields + "&limit=" + limits + "&access_token=" + access_token + "";  // mặc định là lấy bài viết // normarl
                    break;
                }
            case 2:
                {
                album_id = new DataSetting().getValue(album_key_id);
                url = @"https://graph.facebook.com/" + album_id + "?limit= "+ limits+"&fields=" + fields_album + "&access_token=" + access_token + ""; // mặc định là lấy ảnh của album có id =  // speci
                break;
                }
            case 3 :
                {       // tự khai báo
                    url = urls;
                    break;
                }
        }       
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


    #region convert  Name  
    public string convertName(string str)
    {

        string[] tmpHoten = str.ToString().Split('\n');
        string result = "";
        for (int i = 0; i < tmpHoten.Length && i<3; i++)
        {
            result += tmpHoten[i].ToString() + "|";
        }
        Debug.WriteLine(result);
       

          return result;
    }
    #endregion

}