using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataQuestion
/// </summary>
public class DataQuestion : DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblQuestion WHERE ID = @ID";
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
            Cmd.CommandText = "SELECT P.ID,P.Question,PL.NAME AS STATUS FROM tblQuestion AS P";
            Cmd.CommandText += " LEFT JOIN tblStatus AS PL ON P.NSTATUS = PL.ID";
            Cmd.CommandText += " ORDER BY P.IORDER ASC";

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
            Cmd.CommandText = "SELECT ID,Question FROM tblQuestion WHERE NSTATUS != 2";

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

    #region method DataMove
    public bool DataMove(int Id, int vtid)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID FROM tblQuestion WHERE ID != @ID ORDER BY IORDER ASC";
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
                Cmd.CommandText = "UPDATE tblQuestion SET IORDER = @IORDER WHERE ID = @ID";
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

    #region method setData
    public int setData(int id, String Question, String Describe)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblQuestion WHERE ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblQuestion(Question,DESCRIBE,CREATEUSER) OUTPUT INSERTED.ID VALUES (@Question,@DESCRIBE,@CREATEUSER) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblQuestion SET Question = @Question, DESCRIBE = @DESCRIBE,EDITUSER = @CREATEUSER ,EDITTIME = GETDATE() OUTPUT INSERTED.ID WHERE ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("Question", SqlDbType.NVarChar).Value = Question;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NText).Value = Describe;

            SystemClass objSystemClass = new SystemClass();
            Cmd.Parameters.Add("CREATEUSER", SqlDbType.Int).Value = objSystemClass.getIDAccount();

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
            Cmd.CommandText = "DELETE FROM tblQuestion WHERE ID = @ID";
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

    #region getPublic
    public DataRow getPublic()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TOP 1 * FROM tblQuestion";

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
}