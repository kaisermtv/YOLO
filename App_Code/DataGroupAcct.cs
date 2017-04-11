using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataGroupAcct
/// </summary>
public class DataGroupAcct : DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblAcctGroup WHERE ID = @ID";
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
    public DataTable getList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.ID,P.NAME,P.[DESCRIBE],PL.NAME AS STATUS FROM tblAcctGroup AS P LEFT JOIN tblStatus AS PL ON P.NSTATUS = PL.ID";

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

    #region Method getDataToCombobox
    public DataTable getDataToCombobox(String kcstr = "Không chọn")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID,NAME FROM tblAcctGroup WHERE NSTATUS != 2";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            if (kcstr != null && kcstr != ""){ ret.Rows.Add(0,kcstr);}

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

    #region method setGroupAcct
    public int setGroupAcct(int id, String Name, String Describe)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAcctGroup WHERE ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblAcctGroup(NAME,DESCRIBE,EDITUSER,EDITTIME) OUTPUT INSERTED.ID VALUES (@NAME,@DESCRIBE,@EDITUSER,GETDATE()) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblAcctGroup SET NAME = @NAME, DESCRIBE = @DESCRIBE,EDITUSER = @EDITUSER ,EDITTIME = GETDATE() OUTPUT INSERTED.ID WHERE ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("NAME", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NVarChar).Value = Describe;

            SystemClass objSystemClass = new SystemClass();
            Cmd.Parameters.Add("EDITUSER", SqlDbType.Int).Value = objSystemClass.getIDAccount();

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
            Cmd.CommandText = "DELETE FROM tblAcctGroup WHERE ID = @ID";
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