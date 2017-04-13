using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FbPosts
/// </summary>
public class FbPosts:DataClass
{
    public string id { get; set; }                       // id bài viết
    public string message { get; set; }              // tên fanPage
    public string full_picture { get; set; }        // link ảnh lớn
    public string picture { get; set; }             // link ảnh nhỏ
    public string link { get; set; }              // link bài viết để embed
    public string created_time { get; set; }         // Ngày viết bài 
    public string access_token { get; set; }
    public List<likes> likes { get; set; }
    public List<comments> comments { get; set; }
    public List<FbPosts> data { get; set; }
	public FbPosts()
	{
      
	}

    public FbPosts(string _id,string _message, string _full_picture,string _picture, string _link , string _create_time , List<comments> lc , List<likes> ll)
	{
        this.id = _id;
        this.message = _message;
        this.full_picture = _full_picture;
        this.picture = _picture;
        this.link = _link;
        this.created_time = _create_time;
        this.likes = ll;
        this.comments = lc;
        Debug.WriteLine("=[SUCCESS] CREATE NEW OBJECT FBPost  ");
    }
    public DataTable getData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = " SELECT TOP 100 tblFacebookPost.PostId,tblFacebookPost.id,tblFacebookPost.message,tblFacebookPost.full_picture,tblFacebookPost.picture,tblFacebookPost.link,tblFacebookPost.create_time,tblFacebookPost.comments,tblFacebookPost.likes FROM tblFacebookPost  order by tblFacebookPost.id DESC  ";
            DataTable ret = this.findAll(Cmd);
            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET FB POST DATA TABLE : " );
            return ret;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET FB POST DATATABLE : " + e.GetBaseException());
            return new DataTable();
        }


    }

    public int countComments()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "   SELECT [comments] FROM [tblFacebookPost] ";
            DataTable ret = this.findAll(Cmd);

            int x = 0;
            foreach(DataRow row in ret.Rows)
            {
                x += Int32.Parse(row[0].ToString());
            }

            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET FB POST DATA comments : " + x) ;
            return x;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET FB POST comments : " + e.GetBaseException());
            return 0;
        }
    }
    public int countLikes()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "   SELECT [likes]  FROM [tblFacebookPost] ";

            DataTable ret = this.findAll(Cmd);

            int x = 0;
            foreach (DataRow row in ret.Rows)
            {
                x += Int32.Parse(row[0].ToString());
            }
            

            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET FB POST DATA likes : " + x);
            return x;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET FB POST likes : " + e.GetBaseException());
            return 0;
        }
    }



    #region method delAllData
    public void delAllData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE * FROM tblFacebookPost ";
            Cmd.ExecuteNonQuery();
            Debug.WriteLine(" ===[SUCCESS] DELETE ALL DATA NOT  : ");
            this.SQLClose();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(" ===[ERROR] DELETE ALL DATA NOT SUCCESS : " + ex.GetBaseException());
        }
    }
    #endregion


}