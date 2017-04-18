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
    public string picture { get; set; }             // link ảnh nhỏ
    public string link { get; set; }              // link bài viết để embed
    public string create_time { get; set; }
    public List<likes> likes { get; set; }
    public List<comments> comments { get; set; }
    public List<FbPhotoAlbum> data { get; set; }
    public FbPhotoAlbum()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public FbPhotoAlbum(string _id, string _name, string _picture, string _link, string _create_time, List<comments> lc, List<likes> ll)
    {
        this.id = _id;
        this.name = _name;
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
            Cmd.CommandText = " SELECT TOP " + top + " tblFacebookPhotoPost.PostPhotoId,tblFacebookPhotoPost.id,tblFacebookPhotoPost.name,tblFacebookPhotoPost.picture,tblFacebookPhotoPost.link,tblFacebookPhotoPost.comments,tblFacebookPhotoPost.likes,tblFacebookPhotoPost.create_time FROM tblFacebookPhotoPost  order by tblFacebookPhotoPost.id DESC  ";
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