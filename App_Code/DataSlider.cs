using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataSlider
/// </summary>
public class DataSlider : DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblSlider WHERE ID = @ID";
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
    public DataTable getList(int type = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID,TITLE,LINK,IMG,NTYPE FROM tblSlider ";

            if(type != 0)
            {
                Cmd.CommandText += " WHERE NTYPE = @NTYPE";
                Cmd.Parameters.Add("NTYPE", SqlDbType.Int).Value = type;
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
            Cmd.CommandText = "DELETE FROM tblSlider WHERE Id = @ID";
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

    #region Method setData
    public int setData(int id, String title, String Describe,String link,String img)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblSlider WHERE ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblSlider(TITLE,DESCRIBE,LINK,IMG,NTYPE) OUTPUT INSERTED.ID VALUES (@TITLE,@DESCRIBE,@LINK,@IMG,@NTYPE) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblSlider SET TITLE = @TITLE,DESCRIBE = @DESCRIBE,LINK = @LINK,IMG = @IMG,NTYPE = @NTYPE OUTPUT INSERTED.ID WHERE ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("TITLE", SqlDbType.NVarChar).Value = title;
            Cmd.Parameters.Add("DESCRIBE", SqlDbType.NVarChar).Value = Describe;
            Cmd.Parameters.Add("LINK", SqlDbType.NVarChar).Value = link;
            Cmd.Parameters.Add("IMG", SqlDbType.NVarChar).Value = img;
            Cmd.Parameters.Add("NTYPE", SqlDbType.Int).Value = 1;

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
    public bool SliderMove(int Id, int vtid)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID FROM tblSlider WHERE ID != @ID ORDER BY IORDER ASC";
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
                Cmd.CommandText = "UPDATE tblSlider SET IORDER = @IORDER WHERE ID = @ID";
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
}