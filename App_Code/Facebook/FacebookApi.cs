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

public class FacebookApi : DataClass
{

    private static String fields = "full_picture,picture,link,message,likes{name,id},comments,created_time";
    private static string fields_album = "photos{images,name,link,likes.limit(0).summary(true), comments.limit(0).summary(true),  created_time}";          // chú ý không dùng created_time trong comments
    private static string site_id = "ngheansunshine";  
    private static string album_id = "790172047808833";
    private static string key_db = "Facebook_Token";
    private static string album_key_id = "yolodamchiase";
    
	public FacebookApi()
	{
	}
    public int refressPhotoPost(int limits = 10)   // lấy 30 bài mới nhất  "refresh"
    {
        string json = getJsonString(2, 25,"");              // kiểu số 2          
        if (json == null || json.Trim() == "") return 0;
        FbPhotoAlbum lPpost = new FbPhotoAlbum("", "", "", "","","","","", new comments(), new likes());
        try
        {
            lPpost.data = parseJsonToPhotoPostsMini(json);                // lấy bài viết thông thường
            foreach (var item in lPpost.data)
            {
                insertPhotoPostValueWithCheckExist(item.id, item.name, item.user_name, item.user_birthday, item.user_address, item.picture, item.link, item.comments.summary, item.likes.summary, item.create_time);
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
                    FbPhotoAlbum lphoto_post = new FbPhotoAlbum("", "", "", "","","","","", new comments(), new likes());
                    lphoto_post.data = parseJsonToPhotoPosts(json);

                    foreach (var item in lphoto_post.data)
                    {
                        insertPhotoPostValueWithCheckExist(item.id, item.name, item.user_name, item.user_birthday, item.user_address, item.picture, item.link, item.comments.summary, item.likes.summary, item.create_time);
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
        FbPhotoAlbum lphoto_post = new FbPhotoAlbum("", "", "", "", "","","","", new comments(), new likes());
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
                    string[] tmpHoten = new string[3] { "", "", "" };
                    if (element["name"] != null) { tmpHoten = convertName(element["name"].ToString()); }
                    lphoto_post.data.Add(
                      new FbPhotoAlbum(
                      element["id"] == null ? " " : element["id"].ToString(),             // PHOTO ID
                      element["name"] == null ? " " : (convertDescription(element["name"].ToString())),         // MIÊU TẢ ẢNH
                                tmpHoten[0],
                                tmpHoten[1],
                                tmpHoten[2],
                      element["images"] == null ? " " : element["images"][0]["source"].ToString() ==null ? "" : element["images"][0]["source"].ToString(), // ẢNH LỚN NHẤT
                      element["link"] == null ? " " : element["link"].ToString(),
                        element["create_time"] == null ? "" : element["create_time"].ToString(),
                        lc == null ? new comments() : lc,
                        ll == null ? new likes() : ll
                       ));
                }
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

    #region parseJsonToPhotoPostsMini     // 1 bài viết chỉ có 1 ảnh / cuộc thi
    public List<FbPhotoAlbum> parseJsonToPhotoPostsMini(string json)
    {
        
        FbPhotoAlbum lphoto_post = new FbPhotoAlbum("", "", "", "", "", "", "", "", new comments(), new likes());
        lphoto_post.data = new List<FbPhotoAlbum>();
        try
        {
            //  lpost = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FbPosts>(json);
            dynamic struff = JsonConvert.DeserializeObject(json);
            JArray data = struff.photos.data;                //  gốc cây nhị phân có tên là photos 
            var next_data = struff.photos.paging;
         

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
                string[] tmpHoten = new string[3] { "", "", "" };
                if (element["name"] != null) { tmpHoten = convertName(element["name"].ToString()); }
                lphoto_post.data.Add(
                  new FbPhotoAlbum(
                  element["id"] == null ? " " : element["id"].ToString(),             // PHOTO ID
                  element["name"] == null ? " " : (convertDescription(element["name"].ToString())),         // MIÊU TẢ ẢNH
                            tmpHoten[0],
                            tmpHoten[1],
                            tmpHoten[2],
                  element["images"] == null ? " " : element["images"][0]["source"].ToString() == null ? "" : element["images"][0]["source"].ToString(), // ẢNH LỚN NHẤT
                  element["link"] == null ? " " : element["link"].ToString(),
                    element["create_time"] == null ? "" : element["create_time"].ToString(),
                    lc == null ? new comments() : lc,
                    ll == null ? new likes() : ll
                   ));
            }
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

    #region parseJsonToPhotoPostsComments     // 1 bài viết chỉ có 1 ảnh / cuộc thi
    public List<comments> parseJsonToPhotoPostsComments(string json)
    {
        string[] json_arr = new string[10];
        comments lcomment = new comments();
        lcomment.data = new List<comments>();
        try
        {
            dynamic struff = JsonConvert.DeserializeObject(json);
            JArray data = struff.comments.data;                //  gốc cây nhị phân có tên là photos 
            foreach (JObject element in data)
            {
                comments c = new comments();
                if (element["id"] != null)
                {
                    Debug.WriteLine(element["id"].ToString());
                  c.id = element["id"].ToString().Trim();
                }
                if (element["message"] != null)
                {
                   Debug.WriteLine(element["message"].ToString());
                   c.message = element["message"].ToString().Trim();
                }
                lcomment.data.Add(c);
            }
            if (lcomment.data.Count < 1) return new List<comments>();
        }
        catch (Exception e)
        {
            Debug.WriteLine("[ERROR ] - load  comment of photo Posts " + e.GetBaseException());
            return new List<comments>();
        }
        return lcomment.data;        // danh sách bài viết ảnh
    }
    #endregion

    public string getNewAccessToken()
    {
        return "";
    }

    public int setNewAccessToken(string token)
    {
        try
        {
            new DataSetting().setValue(key_db, token);
        }
        catch
        {
            return 0;
        }

        return 1;
    }

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
    public int refreshPost(int limits=10)
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
    public int insertPhotoPostValueWithCheckExist(string id, string name, string user_name, string user_birthday, string user_address, string picture, string link, string lc_count, string ll_count, string create_time)        // chưa cần đến comment và like nên hiện tại đếm số lượng chúng đã
    {
        if (id == null) return 0;
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = @" 
                            IF NOT EXISTS (SELECT tblFacebookPhotoPost.id FROM tblFacebookPhotoPost WHERE tblFacebookPhotoPost.id = @id )
                            BEGIN
                INSERT INTO tblFacebookPhotoPost (id,name,user_name,user_birthday,user_address,picture,link,comments,likes,create_time) VALUES 
                        (  @id  , @name,@user_name,@user_birthday,@user_address , @picture , @link , @comments , @likes ,@create_time)
                            END
                        ELSE 
                    BEGIN 
                UPDATE  tblFacebookPhotoPost SET name = @name,user_name=@user_name,user_address=@user_address,user_birthday=@user_birthday, picture=@picture,comments=@comments,likes = @likes
                        WHERE tblFacebookPhotoPost.id = @id
                    END
                           ";
            Cmd.Parameters.Add("id", SqlDbType.Char).Value = (id);
            Cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = (name == null ? " " : name.Trim());

            Cmd.Parameters.Add("user_name", SqlDbType.NVarChar).Value = (user_name == null ? " " : user_name.Trim());
            Cmd.Parameters.Add("user_birthday", SqlDbType.NVarChar).Value = (user_birthday == null ? " " : user_birthday.Trim());
            Cmd.Parameters.Add("user_address", SqlDbType.NVarChar).Value = (user_address == null ? " " : user_address.Trim());
           
            Cmd.Parameters.Add("picture", SqlDbType.Char).Value = (picture == null ? " " : picture.Trim());
            Cmd.Parameters.Add("link", SqlDbType.Char).Value = (link == null ? " " : link);
            Cmd.Parameters.Add("comments", SqlDbType.NVarChar).Value = (lc_count == null ? "0" : lc_count.Trim());
            Cmd.Parameters.Add("likes", SqlDbType.Char).Value = (ll_count == null ? "0" : ll_count.Trim());
            Cmd.Parameters.Add("create_time", SqlDbType.Char).Value = (create_time == null ? " " : create_time.Trim());
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
                    url = @"https://graph.facebook.com/" + new DataSetting().getValue("PAGE_ID") + "/posts?fields=" + fields + "&limit=" + limits + "&access_token=" + access_token + "";  // mặc định là lấy bài viết // normarl
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
    public string [] convertName(string str)
    {
        string[] tmpHoten = str.ToString().Split('\n');
        string [] result = new string[3]{"","",""};
        for (int i = 0; i < tmpHoten.Length && i<3; i++)
        {
           if(tmpHoten[i].ToUpper().IndexOf("TÊN") > 0)
           {
               try { 
               result[0] = tmpHoten[i].Split(':')[1] == null ? "" : tmpHoten[i].Split(':')[1].Trim();
                }
               catch
               {
                   result[0] = "";
               }
               }
           if (tmpHoten[i].ToLower().IndexOf("sinh") > 0||tmpHoten[i].ToLower().IndexOf("ngày") > 0)
           {    
               try
               {
                   result[1] = tmpHoten[i].Split(':')[1] == null ? "" : tmpHoten[i].Split(':')[1].Trim().Substring(0, tmpHoten[i].Split(':')[1].Trim().Length > 100 ? 100 : tmpHoten[i].Split(':')[1].Trim().Length);
                }
               catch
               { result[1] = ""; }
               }
           if (tmpHoten[i].ToUpper().IndexOf("TỪ") > 0)
           {
               try
               {
                   result[2] = tmpHoten[i].Split(':')[1] == null ? "" : tmpHoten[i].Split(':')[1].Trim().Substring(0, tmpHoten[i].Split(':')[1].Trim().Length > 100 ? 100 : tmpHoten[i].Split(':')[1].Trim().Length);
               }
               catch { result[2] = ""; }
           }
        }
        Debug.WriteLine(result.ToArray());
        
          return result;
    }
    #endregion

    #region convert  convertDescription
    public string convertDescription(string str)
    {
        try { 
        string[] tmpDes = str.ToString().Split('\n');
        string[] tmp = new string[tmpDes.Length-2];
        for (int i = 3; i < tmpDes.Length && i >= 3; i++)
        {
            tmp[i - 2] = tmpDes[i];
        }
        return string.Join("\n", tmp);
            }
        catch
        {
            return " ";
        }
      
    }
    #endregion

    #region method getDataById
    public DataRow getDataById(String id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblFacebookPhotoPost WHERE id = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = id;

            DataRow ret = this.findFirst(Cmd);

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    #endregion
}