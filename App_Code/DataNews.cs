﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataNews
/// </summary>
public class DataNews : DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblNews WHERE Id = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

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

    #region method getList
    public DataTable getList(int group = 0,String seach = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.Id,P.Title,G.NAME AS GroupName,PL.NAME AS STATUS FROM tblNews AS P";
            Cmd.CommandText += " LEFT JOIN tblStatus AS PL ON P.NSTATUS = PL.ID";
            Cmd.CommandText += " LEFT JOIN tblNewsGroup AS G ON P.CatId = G.ID";
            Cmd.CommandText += " WHERE 1=1";

            if(group != 0)
            {
                Cmd.CommandText += " AND P.CatId = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if (seach != null && seach != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(P.Title))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.Parameters.Add("Seach", SqlDbType.NVarChar).Value = seach;
            }

            Cmd.CommandText += " ORDER BY DayPost DESC";

            DataTable ret = this.findAll(Cmd);

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

    #region Method addData
    public int addData(String title,int catid,String shortcontent,String content,String img,String author)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO [tblNews]([Title],[CatId],[ShortContent],[Content],[ImgUrl],[Author],UserPost) OUTPUT INSERTED.ID";
            Cmd.CommandText += " VALUES (@TITLE,@GROUP,@SHORTCONTENT,@CONTENT,@IMG,@AUTHOR,@USERPOST)";

            Cmd.Parameters.Add("TITLE", SqlDbType.NVarChar).Value = title;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = catid;
            Cmd.Parameters.Add("SHORTCONTENT", SqlDbType.NVarChar).Value = shortcontent;
            Cmd.Parameters.Add("CONTENT", SqlDbType.NText).Value = content;
            Cmd.Parameters.Add("IMG", SqlDbType.NVarChar).Value = img;
            Cmd.Parameters.Add("AUTHOR", SqlDbType.NVarChar).Value = author;


            SystemClass objSystemClass = new SystemClass();
            Cmd.Parameters.Add("USERPOST", SqlDbType.Int).Value = objSystemClass.getIDAccount();

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion

    #region Method addData
    public int UpdateData(int id,String title, int catid, String shortcontent, String content, String img, String author)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblNewsGroup SET Title = @TITLE, CatId = @GROUP,ShortContent = @SHORTCONTENT ,Content = @CONTENT,[UserEdit] = @USEREDIT, [DayEdit] = GETDATE() OUTPUT INSERTED.Id WHERE Id = @ID";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("TITLE", SqlDbType.NVarChar).Value = title;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = catid;
            Cmd.Parameters.Add("SHORTCONTENT", SqlDbType.NVarChar).Value = shortcontent;
            Cmd.Parameters.Add("CONTENT", SqlDbType.NText).Value = content;
            Cmd.Parameters.Add("IMG", SqlDbType.NVarChar).Value = img;
            Cmd.Parameters.Add("AUTHOR", SqlDbType.NVarChar).Value = author;

            SystemClass objSystemClass = new SystemClass();
            Cmd.Parameters.Add("USEREDIT", SqlDbType.Int).Value = objSystemClass.getIDAccount();

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion

    #region method delData
    public void delData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE FROM tblNews WHERE Id = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            Cmd.ExecuteNonQuery();

            this.SQLClose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
        }
    }
    #endregion
}