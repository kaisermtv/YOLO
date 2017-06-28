using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataMenu
/// </summary>
public class DataMenu : DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblMenu WHERE ID = @ID";
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

    #region method addData
    public int addData(int pid, String Name, String Describe, String link, int type = 0,int menuid = 1)
    {
        try
        {
            if (menuid == 0) menuid = 1;

            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO tblMenu(" + ((pid != 0) ? "PID," : "") + "NAME,DESCRIBE,LINK,NTYPE,MenuID) OUTPUT INSERTED.ID VALUES (" + ((pid != 0) ? "@PID," : "") + "@NAME,@DESCRIBE,@LINK,@NTYPE,@MenuID)";

            if (pid != 0)
            {
                Cmd.Parameters.Add("PID", SqlDbType.Int).Value = pid;
            }

            Cmd.Parameters.Add("NAME", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NVarChar).Value = Describe;
            Cmd.Parameters.Add("LINK", SqlDbType.NVarChar).Value = link;
            Cmd.Parameters.Add("NTYPE", SqlDbType.Int).Value = type;
            Cmd.Parameters.Add("MenuID", SqlDbType.Int).Value = menuid;
            int ret = (int)Cmd.ExecuteScalar();

            Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblMenu SET IORDER = @ID WHERE ID = @ID AND IORDER IS NULL";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = ret;
            Cmd.ExecuteNonQuery();

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

    #region method UpdateData
    public int UpdateData(int Id, int pid, String Name, String Describe, String link, int type = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblMenu SET " + ((pid != 0) ? "PID = @PID," : "PID = null,") + "NAME = @NAME, DESCRIBE = @DESCRIBE,LINK = @LINK, NTYPE = @NTYPE OUTPUT INSERTED.ID WHERE ID = @ID";

            if (pid != 0)
            {
                Cmd.Parameters.Add("PID", SqlDbType.Int).Value = pid;
            }
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("NAME", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NVarChar).Value = Describe;
            Cmd.Parameters.Add("LINK", SqlDbType.NVarChar).Value = link;
            Cmd.Parameters.Add("NTYPE", SqlDbType.Int).Value = type;
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

    #region method MenuMove
    public bool MenuMove(int Id, int vtid)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID FROM tblMenu WHERE ID != @ID ORDER BY IORDER ASC";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = Id;
            DataTable ret = this.findAll(Cmd);

            ArrayList arr = new ArrayList();

            int i = 1;
            foreach (DataRow item in ret.Rows)
            {
                if (i++ == vtid)
                {
                    arr.Add(Id);
                }
                arr.Add(int.Parse(item["ID"].ToString()));
            }
            if (i <= vtid)
            {
                arr.Add(Id);
            }

            i = 1;
            foreach (int a in arr)
            {
                Cmd = this.getSQLConnect();
                Cmd.CommandText = "UPDATE tblMenu SET IORDER = @IORDER WHERE ID = @ID";
                Cmd.Parameters.Add("ID", SqlDbType.Int).Value = a;
                Cmd.Parameters.Add("IORDER", SqlDbType.Int).Value = i++;
                Cmd.ExecuteNonQuery();
            }

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

    #region method getList
    public DataTable getList(int id = 0,int type = 1)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID,NAME,LINK,IORDER FROM tblMenu WHERE 1=1 ";

            if (id == 0)
            {
                Cmd.CommandText += " AND PID IS NULL";
            }
            else
            {
                Cmd.CommandText += " AND PID = @PID";
                Cmd.Parameters.Add("PID", SqlDbType.Int).Value = id;
            }

            if (type != 0 && id == 0)
            {
                Cmd.CommandText += " AND MenuID = @MenuID";
                Cmd.Parameters.Add("MenuID", SqlDbType.Int).Value = type;
            }

            Cmd.CommandText += " ORDER BY IORDER ASC";

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
            Cmd.CommandText = "DELETE FROM tblMenu WHERE Id = @ID";
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

    #region Method getDataToCombobox
    public DataTable getDataToCombobox(String kcstr = "Không chọn", int group = 0,int menuid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID,NAME FROM tblMenu WHERE 1=1";

            if (group != 0)
            {
                Cmd.CommandText += " AND PID = @PID";
                Cmd.Parameters.Add("PID", SqlDbType.Int).Value = group;
            }

            if (menuid != 0)
            {
                Cmd.CommandText += " AND MenuID = @MenuID";
                Cmd.Parameters.Add("MenuID", SqlDbType.Int).Value = menuid;
            }

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            if (kcstr != null && kcstr != "") { ret.Rows.Add(0, kcstr); }

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