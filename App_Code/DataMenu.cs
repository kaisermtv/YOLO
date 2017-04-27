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
    public int addData(String Name, String Describe,String link,int type = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "INSERT INTO tblMenu(NAME,DESCRIBE,LINK,NTYPE) OUTPUT INSERTED.ID VALUES (@NAME,@DESCRIBE,@LINK,@NTYPE)";

            Cmd.Parameters.Add("NAME", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NVarChar).Value = Describe;
            Cmd.Parameters.Add("LINK", SqlDbType.NVarChar).Value = link;
            Cmd.Parameters.Add("NTYPE", SqlDbType.Int).Value = type;
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
    public int UpdateData(int Id,String Name, String Describe, String link, int type = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "UPDATE tblMenu SET NAME = @NAME, DESCRIBE = @DESCRIBE,LINK = @LINK, NTYPE = @NTYPE OUTPUT INSERTED.ID WHERE ID = @ID";

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
    public bool MenuMove(int Id,int vtid)
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
    public DataTable getList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID,NAME,LINK,IORDER FROM tblMenu ORDER BY IORDER ASC";

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

    
}