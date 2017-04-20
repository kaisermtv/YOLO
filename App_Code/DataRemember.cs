using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataRemember
/// </summary>
public class DataRemember :DataClass
{
    #region getData(String key)
    public DataRow getData(String key)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT [USERID],[PASS],[LGROUP] FROM tblRemember WHERE RMKEY = @RMKEY";
            Cmd.Parameters.Add("RMKEY", SqlDbType.NVarChar).Value = key;

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

    #region addLogin(int userd,String pass,int group = 0)
    public String addLogin(int userd, String pass, int group = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO tblRemember(RMKEY,USERID,PASS,LGROUP) OUTPUT Inserted.RMKEY VALUES(NEWID(),@USERID,@PASS,@LGROUP) ";
            Cmd.Parameters.Add("USERID", SqlDbType.Int).Value = userd;
            Cmd.Parameters.Add("PASS", SqlDbType.NVarChar).Value = pass;
            Cmd.Parameters.Add("LGROUP", SqlDbType.Int).Value = group;

            String ret = Cmd.ExecuteScalar().ToString();

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return "";
        }

    }
    #endregion

    #region setLogin(String key, int userd,String pass,int group = 0)
    public bool setLogin(String key, int userd,String pass,int group = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblRemember WHERE RMKEY = @RMKEY)";
            Cmd.CommandText += "BEGIN INSERT INTO tblRemember(RMKEY,USERID,PASS,LGROUP) VALUES(@RMKEY,@USERID,@PASS,@LGROUP) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblRemember SET [USERID] = @USERID, [PASS] = @PASS, [LGROUP] = @LGROUP WHERE RMKEY = @RMKEY END";
            Cmd.Parameters.Add("RMKEY", SqlDbType.NVarChar).Value = key;
            Cmd.Parameters.Add("USERID", SqlDbType.Int).Value = userd;
            Cmd.Parameters.Add("PASS", SqlDbType.NVarChar).Value = pass;
            Cmd.Parameters.Add("LGROUP", SqlDbType.Int).Value = group;

            Cmd.ExecuteNonQuery();

            this.SQLClose();

            return true;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return false;
        }

    }
    #endregion

    #region updateOnline(String key)
    public bool updateOnline(String key)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblRemember SET [ONLINEDATE] = getdate() WHERE RMKEY = @RMKEY";
            Cmd.Parameters.Add("RMKEY", SqlDbType.NVarChar).Value = key;

            Cmd.ExecuteNonQuery();

            this.SQLClose();

            return true;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return false;
        }
    }
    #endregion

    #region method delData
    public bool delData(String key)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE tblRemember WHERE RMKEY = @RMKEY";
            Cmd.Parameters.Add("RMKEY", SqlDbType.NVarChar).Value = key;

            Cmd.ExecuteNonQuery();

            this.SQLClose();

            return true;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return false;
        }
    }
    #endregion

    #region Method getCountOnline()
    public int getCountOnline(int minute = 5)
    {
        try
        {
            //DateTime minu = new DateTime(0);
            //minu.AddMinutes()

            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT COUNT(*) FROM (SELECT COUNT(USERID) AS num FROM tblRemember WHERE GETDATE() - ONLINEDATE < '00:05:00' GROUP BY USERID  ) AS TEMP1";
            //Cmd.CommandText = "SELECT COUNT(*) FROM tblRemember WHERE GETDATE() - ONLINEDATE < '" + minu.ToString("hh:mm:ss") + "'";
            //Cmd.Parameters.Add("Minute", SqlDbType.NVarChar).Value = minu.ToString("hh:mm:ss");

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
}