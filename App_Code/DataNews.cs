using System;
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
    public int addData(String title, int catid, String shortcontent, String content, String img, String author, bool NoiBat = false,String tag = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO [tblNews]([Title],[CatId],[ShortContent],[Content],[ImgUrl],[Author],UserPost,NoiBat,tag) OUTPUT INSERTED.ID";
            Cmd.CommandText += " VALUES (@TITLE,@GROUP,@SHORTCONTENT,@CONTENT,@IMG,@AUTHOR,@USERPOST,@NoiBat,@tag)";

            Cmd.Parameters.Add("TITLE", SqlDbType.NVarChar).Value = title;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = catid;
            Cmd.Parameters.Add("SHORTCONTENT", SqlDbType.NVarChar).Value = shortcontent;
            Cmd.Parameters.Add("CONTENT", SqlDbType.NText).Value = content;
            Cmd.Parameters.Add("IMG", SqlDbType.NVarChar).Value = img;
            Cmd.Parameters.Add("AUTHOR", SqlDbType.NVarChar).Value = author;
            Cmd.Parameters.Add("NoiBat", SqlDbType.Bit).Value = NoiBat;
            Cmd.Parameters.Add("tag", SqlDbType.NVarChar).Value = tag;


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

    #region Method UpdateData
    public int UpdateData(int id, String title, int catid, String shortcontent, String content, String img, String author, bool NoiBat = false,String tag = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblNews SET Title = @TITLE, CatId = @GROUP,ShortContent = @SHORTCONTENT ,Content = @CONTENT, ImgUrl = @IMG,Author = @AUTHOR, [UserEdit] = @USEREDIT, [DayEdit] = GETDATE(),NoiBat = @NoiBat,tag = @tag OUTPUT INSERTED.Id WHERE Id = @ID";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("TITLE", SqlDbType.NVarChar).Value = title;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = catid;
            Cmd.Parameters.Add("SHORTCONTENT", SqlDbType.NVarChar).Value = shortcontent;
            Cmd.Parameters.Add("CONTENT", SqlDbType.NText).Value = content;
            Cmd.Parameters.Add("IMG", SqlDbType.NVarChar).Value = img;
            Cmd.Parameters.Add("AUTHOR", SqlDbType.NVarChar).Value = author;
            Cmd.Parameters.Add("NoiBat", SqlDbType.Bit).Value = NoiBat;
            Cmd.Parameters.Add("tag", SqlDbType.NVarChar).Value = tag;

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

    #region Method getDataCount
    public int getDataCount(int group = 0, bool NoiBat = false, String seach = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TOP 1 COUNT(*) FROM tblNews AS P WHERE P.NSTATUS != 2";

            if (group != 0)
            {
                Cmd.CommandText += " AND P.CatId = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if(NoiBat)
            {
                Cmd.CommandText += " AND P.NoiBat = 1";
            }

            if (seach != null && seach != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(P.Title))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.Parameters.Add("Seach", SqlDbType.NVarChar).Value = seach;
            }


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

    #region Method getDataTop()
    public DataTable getDataTop(int limit = 0, int group = 0, int page = 1, bool NoiBat = false, String seach = "",String sapXep = "DESC")
    {
        try
        {
            String top = "";

            SqlCommand Cmd = this.getSQLConnect();
            if (page < 1) page = 1;
            if (page > 1)
            {
                Cmd.CommandText = "SELECT * FROM (";

                page = (page-1) * limit;
                limit += page;
            }
            
            if (limit != 0)
            {
                top = " TOP " + limit + " ";
            }

            Cmd.CommandText += "SELECT " + top + " P.Id,P.Title,P.[ShortContent],P.ImgUrl,G.NAME AS GroupName,P.DayPost,(ROW_NUMBER() OVER(ORDER BY DayPost " + sapXep + ")) AS RowNum FROM tblNews AS P";
            Cmd.CommandText += " LEFT JOIN tblNewsGroup AS G ON P.CatId = G.ID";
            Cmd.CommandText += " WHERE P.NSTATUS != 2 AND G.NSTATUS = 1";

            if (group != 0)
            {
                Cmd.CommandText += " AND P.CatId = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if (NoiBat)
            {
                Cmd.CommandText += " AND P.NoiBat = 1";
            }

            if (seach != null && seach != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(P.Title))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.Parameters.Add("Seach", SqlDbType.NVarChar).Value = seach;
            }

            //Cmd.CommandText += " ORDER BY P.DayPost DESC";

            if (page > 1)
            {
                Cmd.CommandText += " ) AS MyDerivedTable WHERE RowNum > @Offset";
                Cmd.Parameters.Add("Offset", SqlDbType.Int).Value = page;
            }
            

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

    #region Method tinLienQuan()
    public DataTable tinLienQuan(int id ,DateTime tinHienTai,bool moiCu = false, int limit = 0, int group = 0, bool NoiBat = false)
    {
        try
        {
            String top = "";
            if (limit != 0)
            {
                top = " TOP " + limit + " ";
            }

            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText += "SELECT * FROM (SELECT " + top + " P.Id,P.Title,P.DayPost,P.ImgUrl FROM tblNews AS P";
            Cmd.CommandText += " WHERE P.NSTATUS != 2 AND P.Id != @ID";


            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if(moiCu)
            {
                Cmd.CommandText += " AND P.DayPost > @DayPost";
            }
            else
            {
                Cmd.CommandText += " AND P.DayPost < @DayPost";
            }

            Cmd.Parameters.Add("DayPost", SqlDbType.DateTime).Value = tinHienTai;

            if (group != 0)
            {
                Cmd.CommandText += " AND P.CatId = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if (NoiBat)
            {
                Cmd.CommandText += " AND P.NoiBat = 1";
            }

            
            if (moiCu)
            {
                Cmd.CommandText += " ORDER BY P.DayPost ASC";
            }
            else
            {
                Cmd.CommandText += " ORDER BY P.DayPost DESC";
            }
            Cmd.CommandText += ") AS Temp ORDER BY DayPost DESC";

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
}