using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccount
/// </summary>
public class DataAccount : DataClass
{
    #region method getAccount
    public DataRow getAccount(int id, bool delacct = false)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE ACCT_ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if (delacct)
            {
                Cmd.CommandText += " AND ACCT_STATUS != @delacct";
                Cmd.Parameters.Add("delacct", SqlDbType.NVarChar).Value = "delete";
            }

            DataRow ret = this.findFirst(Cmd);
            
            this.SQLClose();
            return ret;
        }
        catch(Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }

    public DataRow getAccount(String acct,bool delacct = false)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            //Console.WriteLine("Connect");
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE ACCT_NAME = @ACCT";
            Cmd.Parameters.Add("ACCT", SqlDbType.NVarChar).Value = acct;

            if (delacct)
            {
                Cmd.CommandText += " AND ACCT_STATUS != @delacct";
                Cmd.Parameters.Add("delacct", SqlDbType.NVarChar).Value = "delete";
            }

            //Console.Out("Create sql");

            DataRow ret = this.findFirst(Cmd);

            //Console.WriteLine("return");
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

    #region getAccountInfo
    public DataRow getAccountInfo(int id, bool delacct = false)
    {

        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT p.ACCT_ID,pl.FULLNAME,pl.AGE,pl.SEX,pl.EMAIL FROM tblAccount AS p LEFT JOIN tblAccountInfo AS pl ON p.ACCT_ID = pl.ACCT_ID WHERE p.ACCT_ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if (delacct)
            {
                Cmd.CommandText += " AND p.ACCT_STATUS != @delacct";
                Cmd.Parameters.Add("delacct", SqlDbType.NVarChar).Value = "delete";
            }

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
    public DataTable getList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblAccount";

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