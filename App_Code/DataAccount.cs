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
                Cmd.CommandText += " AND ACCT_STATUS != 2";
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
                Cmd.CommandText += " AND ACCT_STATUS != 2";
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
            Cmd.CommandText = "SELECT p.ACCT_ID,p.ACCT_NAME,p.ACCT_GROUP,g.NAME AS GROUPNAME,pl.FULLNAME,pl.AGE,pl.SEX,pl.EMAIL FROM tblAccount AS p";
            Cmd.CommandText += " LEFT JOIN tblAcctGroup AS g ON p.ACCT_GROUP = g.ID";
            Cmd.CommandText += " LEFT JOIN tblAccountInfo AS pl ON p.ACCT_ID = pl.ACCT_ID";
            Cmd.CommandText += " WHERE p.ACCT_ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if (delacct)
            {
                Cmd.CommandText += " AND p.ACCT_STATUS != 2";
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
    public DataTable getList(int group = -1, String seach = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.ACCT_ID,P.ACCT_NAME,G.NAME AS GROUPNAME,PL.NAME AS STATUS FROM tblAccount AS P LEFT JOIN tblAcctGroup AS G ON P.ACCT_GROUP = G.ID LEFT JOIN tblStatus AS PL ON P.NSTATUS = PL.ID";
            Cmd.CommandText += " WHERE 1=1";

            if (group != -1)
            {
                Cmd.CommandText += " AND P.ACCT_GROUP = @GROUP";
                Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;
            }

            if (seach != null && seach != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(P.ACCT_NAME))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Seach)))+'%'";
                Cmd.Parameters.Add("Seach", SqlDbType.NVarChar).Value = seach;
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

    #region method addAccount
    public int addAccount(String Acct, String pass,int group = 3)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO tblAccount(ACCT_NAME,ACCT_PASS,ACCT_GROUP) OUTPUT INSERTED.ACCT_ID VALUES (@ACCOUNT,@PASSWORD,@GROUP);";

            Cmd.Parameters.Add("ACCOUNT", SqlDbType.NVarChar).Value = Acct;
            Cmd.Parameters.Add("PASSWORD", SqlDbType.NVarChar).Value = pass;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;

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

    #region method setAccountInfo
    public void setAccountInfo(int id, String email, String Phone)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAccountInfo WHERE ACCT_ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblAccountInfo(ACCT_ID,PHONE,EMAIL) VALUES (@ID,@PHONE,@EMAIL) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblAccountInfo SET PHONE = @PHONE, EMAIL = @EMAIL WHERE ACCT_ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = email;
            Cmd.Parameters.Add("PHONE", SqlDbType.NVarChar).Value = Phone;

            Cmd.ExecuteNonQuery();

            this.SQLClose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
        }
    }

    public void setAccountInfo(int id,String email, String fullname, DateTime ngaysinh,int gioitinh)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAccountInfo WHERE ACCT_ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblAccountInfo(ACCT_ID,FULLNAME,AGE,SEX,EMAIL) VALUES (@ID,@FULLNAME,@AGE,@SEX,@EMAIL) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblAccountInfo SET FULLNAME = @FULLNAME, AGE = @AGE, SEX = @SEX, EMAIL = @EMAIL WHERE ACCT_ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("FULLNAME", SqlDbType.NVarChar).Value = fullname;
            Cmd.Parameters.Add("AGE", SqlDbType.DateTime).Value = ngaysinh;
            Cmd.Parameters.Add("SEX", SqlDbType.Bit).Value = gioitinh;
            Cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = email;

            Cmd.ExecuteNonQuery();

            this.SQLClose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
        }
    }

    public void setAccountInfo(int id, String email, String fullname, DateTime ngaysinh, int gioitinh, int group)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblAccount SET ACCT_GROUP = @GROUP WHERE ACCT_ID = @ID";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("GROUP", SqlDbType.Int).Value = group;

            Cmd.ExecuteNonQuery();

            Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAccountInfo WHERE ACCT_ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblAccountInfo(ACCT_ID,FULLNAME,AGE,SEX,EMAIL) VALUES (@ID,@FULLNAME,@AGE,@SEX,@EMAIL) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblAccountInfo SET FULLNAME = @FULLNAME, AGE = @AGE, SEX = @SEX, EMAIL = @EMAIL WHERE ACCT_ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("FULLNAME", SqlDbType.NVarChar).Value = fullname;
            Cmd.Parameters.Add("AGE", SqlDbType.DateTime).Value = ngaysinh;
            Cmd.Parameters.Add("SEX", SqlDbType.Bit).Value = gioitinh;
            Cmd.Parameters.Add("EMAIL", SqlDbType.NVarChar).Value = email;

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

    #region method delAccount
    public void delAccount(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE FROM tblAccountInfo WHERE ACCT_ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            Cmd.ExecuteNonQuery();

            Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE FROM tblAccount WHERE ACCT_ID = @ID";
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

    #region method changPass
    public bool changPass(int id,String pass)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblAccount SET ACCT_PASS = @PASS OUTPUT INSERTED.ACCT_ID WHERE ACCT_ID = @ID";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("PASS", SqlDbType.NVarChar).Value = pass;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();

            if (ret > 0)
            {
                return true;
            }
            else
            {
                this.Message = "Không tìm thấy tài khoản";
                this.ErrorCode = -1;
                return false;
            }
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;

            return false;
        }
    }
    #endregion

    #region method getCountAccout
    public int getCountAccout()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT COUNT(*) FROM tblAccount WHERE NSTATUS != 2 ";


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