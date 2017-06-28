using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataNewsComment
/// </summary>
public class DataNewsComment : DataAbstract
{

    #region method DataNewsComment
    public DataNewsComment()
    {
        keyTable = "Id";
        nameTable = "tblNewsComment";
    }
    #endregion

    #region setData Atribute
    protected override SqlDbType? GetTypeAtribute(string name)
    {
        switch (name)
        {
            case "Id":
            case "NSTATUS":
            case "NewsId":
                return SqlDbType.Int;
            case "Name":
            case "Email":
            case "Phone":
            case "Subject":
                return SqlDbType.NVarChar;
            case "Content":
                return SqlDbType.NText;
            case "DayPost":
                return SqlDbType.DateTime;
        }

        return null;
    }
    #endregion

    #region Method getDataCount
    public int getDataCount(int newsid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TOP 1 COUNT(*) FROM tblNewsComment AS P WHERE P.NSTATUS != 2";
            
            if (newsid != 0)
            {
                Cmd.CommandText += " AND P.NewsId = @ID";
                Cmd.Parameters.Add("ID", SqlDbType.Int).Value = newsid;
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
    public DataTable getDataTop(int newsid = 0,int limit = 0, int page = 1, String sapXep = "DESC")
    {
        try
        {
            String top = "";

            SqlCommand Cmd = this.getSQLConnect();
            if (page < 1) page = 1;
            if (page > 1)
            {
                Cmd.CommandText = "SELECT * FROM (";

                page = (page - 1) * limit;
                limit += page;
            }

            if (limit != 0)
            {
                top = " TOP " + limit + " ";
            }

            Cmd.CommandText += "SELECT " + top + " P.Id,P.NewsId,P.Subject,P.[Content],P.DayPost,(ROW_NUMBER() OVER(ORDER BY DayPost " + sapXep + ")) AS RowNum FROM tblNewsComment AS P";
            Cmd.CommandText += " WHERE P.NSTATUS != 2";

            if (newsid != 0)
            {
                Cmd.CommandText += " AND P.NewsId = @ID";
                Cmd.Parameters.Add("ID", SqlDbType.Int).Value = newsid;
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


    #region method delData
    public void delData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE FROM tblNewsComment WHERE Id = @ID";
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


    #region method getList
    public DataTable getList(int group = 0,int status = -1, String seach = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.Id,P.Subject,P.Name,P.Email,P.Phone,P.NSTATUS FROM tblNewsComment AS P WHERE 1=1";

            if (status != -1)
            {
                Cmd.CommandText += " AND P.NSTATUS = @NSTATUS";
                Cmd.Parameters.Add("NSTATUS", SqlDbType.Int).Value = status;
            }

            if (group != 0)
            {
                Cmd.CommandText += " AND P.NewsId = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if (seach != null && seach != "")
            {
                Cmd.CommandText += " AND ( UPPER(RTRIM(LTRIM(P.Subject))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.CommandText += " OR UPPER(RTRIM(LTRIM(P.Name))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.CommandText += " OR P.Phone = RTRIM(LTRIM(@Seach))";
                Cmd.CommandText += " OR P.Email = RTRIM(LTRIM(@Seach))";
                Cmd.CommandText += " )";
                Cmd.Parameters.Add("Seach", SqlDbType.NVarChar).Value = seach;
            }

            Cmd.CommandText += " ORDER BY P.DayPost DESC";

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