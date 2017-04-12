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

    public List<FbPosts> data { get; set; }
	public FbPosts()
	{
      
	}
    public FbPosts(string _id,string _message, string _full_picture,string _picture, string _link , string _create_time)
	{
        this.id = _id;
        this.message = _message;
        this.full_picture = _full_picture;
        this.picture = _picture;
        this.link = _link;
        this.created_time = _create_time;
    }

    public DataTable getData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = " SELECT TOP 100 tblFacebookPost.PostId,tblFacebookPost.id,tblFacebookPost.message,tblFacebookPost.full_picture,tblFacebookPost.picture,tblFacebookPost.link,tblFacebookPost.create_time FROM tblFacebookPost";
            DataTable ret = this.findAll(Cmd);
            this.SQLClose();
            return ret;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET FB POST DATATABLE : " + e.GetBaseException());
            return new DataTable();
        }


    }

    #region method delAllData
    public void delAllData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE * FROM tblAccountInfo ";
            Cmd.ExecuteNonQuery();   
            this.SQLClose();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(" ===[ERROR] DELETE ALL DATA NOT SUCCESS : " + ex.GetBaseException());
        }
    }
    #endregion


}