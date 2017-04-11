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
}