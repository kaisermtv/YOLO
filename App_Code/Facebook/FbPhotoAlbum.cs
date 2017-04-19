using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FbPhotoAlbum
/// </summary>
public class FbPhotoAlbum : DataClass
{
    public string id { get; set; }                       // id bài viết
    public string name { get; set; }              // tên fanPage
    public string user_name { get; set; }              // tên người đăng ảnh
    public string user_address { get; set; }              // địa chỉ người đăng ảnh
    public string user_birthday { get; set; }              // ngày sinh người đăng ảnh
    public string picture { get; set; }             // link ảnh nhỏ
    public string link { get; set; }              // link bài viết để embed
    public string create_time { get; set; }
    public  likes likes { get; set; }   // Bỏ  List<likes>  vi dữ liệu lấy về quá lớn mà chưa dùng tới
    public comments comments { get; set; }   //List<comments> vì dữ liệu lấy về quá lớn mà chưa dùng tới
    public List<FbPhotoAlbum> data { get; set; }
    public FbPhotoAlbum()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public FbPhotoAlbum(string _id, string _name, string _user_name, string _user_birthday, string _user_address, string _picture, string _link, string _create_time, comments lc, likes ll)
	{

        this.id = _id;
        this.name = _name;
        this.user_name = _user_name;
        this.user_address = _user_address;
        this.user_birthday = _user_birthday;
        this.picture = _picture;
        this.link = _link;
        this.likes = ll;
        this.create_time = _create_time;
        this.comments = lc;
        Debug.WriteLine("=[SUCCESS] CREATE NEW OBJECT Facebook Photo Post  .");
    }

    public DataTable getData(int top = 100)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = " SELECT TOP " + top + " tblFacebookPhotoPost.PostPhotoId,tblFacebookPhotoPost.id,tblFacebookPhotoPost.name,tblFacebookPhotoPost.user_name ,tblFacebookPhotoPost.user_address,tblFacebookPhotoPost.user_birthday, tblFacebookPhotoPost.picture,tblFacebookPhotoPost.link,tblFacebookPhotoPost.comments,tblFacebookPhotoPost.likes,tblFacebookPhotoPost.create_time FROM tblFacebookPhotoPost  order by tblFacebookPhotoPost.id DESC  ";
            DataTable ret = this.findAll(Cmd);
            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET Facebook Photo Post DATA TABLE : ");
            return ret;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET Facebook Photo Post DATATABLE : " + e.GetBaseException());
            return new DataTable();
        }
    }

    public int countComments()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "   SELECT [comments] FROM [tblFacebookPhotoPost] ";
            DataTable ret = this.findAll(Cmd);

            int x = 0;
            foreach (DataRow row in ret.Rows)
            {
                x += Int32.Parse(row[0].ToString());
            }

            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET Facebook Photo Post DATA comments : " + x);
            return x;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET Facebook Photo Post comments : " + e.GetBaseException());
            return 0;
        }
    }
    public int countLikes()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "   SELECT [likes]  FROM [tblFacebookPhotoPost] ";

            DataTable ret = this.findAll(Cmd);

            int x = 0;
            foreach (DataRow row in ret.Rows)
            {
                x += Int32.Parse(row[0].ToString());
            }

            this.SQLClose();
            Debug.WriteLine("=[SUCCESS] GET Facebook Photo Post DATA likes : " + x);
            return x;
        }
        catch (Exception e)
        {
            Debug.WriteLine("===[ERROR] GET Facebook Photo Post likes : " + e.GetBaseException());
            return 0;
        }
    }



    #region method delAllData
    public void delAllData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = " DELETE  FROM tblFacebookPhotoPost ";
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