using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAnswer
/// </summary>
public class DataAnswer :DataClass
{
    #region method getData
    public DataRow getData(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblAnswer WHERE ID = @ID";
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

    #region Method getUserResult
    public DataRow getUserResult(int QuestionID,int userId = 0)
    {
        try
        {
            if(userId == 0)
            {
                SystemClass objSystem = new SystemClass();
                userId = objSystem.getIDAccount();
            }

            if(userId == 0)
            {
                return null;
            }


            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblAnswerResult AS P WHERE P.QuestionID = @QuestionID AND USERID = @USERID";
            Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;
            Cmd.Parameters.Add("USERID", SqlDbType.Int).Value = userId;

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

    #region Method isResult
    public bool isResult(int QuestionID = 0,int userId = 0)
    {
        try
        {
            if (userId == 0)
            {
                SystemClass objSystem = new SystemClass();
                userId = objSystem.getIDAccount();
            }

            if (userId == 0)
            {
                return false;
            }


            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID FROM tblAnswerResult AS P WHERE P.QuestionID = @QuestionID AND USERID = @USERID";
            Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;
            Cmd.Parameters.Add("USERID", SqlDbType.Int).Value = userId;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();

            if (ret != 0) return true;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
        }
        return false;
    }

    #endregion

    #region Method setUserResult
    public int setUserResult(int QuestionId, int AnswerResult, int userId = 0)
    {
        if(QuestionId == 0 || AnswerResult == 0) return 0; 

        try
        {
            if (userId == 0)
            {
                SystemClass objSystem = new SystemClass();
                userId = objSystem.getIDAccount();
            }

            if (userId == 0)
            {
                return 0;
            }

            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT COUNT(*) FROM tblAnswer AS P WHERE P.ID = @AnswerResult AND P.QuestionID = @QuestionID";
            Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionId;
            Cmd.Parameters.Add("AnswerResult", SqlDbType.Int).Value = AnswerResult;

            int ret = (int)Cmd.ExecuteScalar();

            if(ret == QuestionId)
            {
                Cmd = this.getSQLConnect();
                Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAnswerResult WHERE QuestionID = @QuestionID AND USERID = @USERID)";
                Cmd.CommandText += " BEGIN INSERT INTO tblAnswerResult(QuestionID,AnswerID,USERID) OUTPUT INSERTED.ID VALUES (@QuestionID,@AnswerID,@USERID) END";
                Cmd.CommandText += " ELSE BEGIN UPDATE tblAnswerResult SET AnswerID = @AnswerID OUTPUT INSERTED.ID WHERE QuestionID = @QuestionID AND USERID = @USERID END";

                Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionId;
                Cmd.Parameters.Add("AnswerID", SqlDbType.Int).Value = AnswerResult;
                Cmd.Parameters.Add("USERID", SqlDbType.Int).Value = userId;

                ret = (int)Cmd.ExecuteScalar();
            }
            else
            {
                ret = 0;
            }

            
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

    #region Method getCountAnswerResult
    public int getCountAnswerResult(int QuestionID = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT COUNT(*) FROM tblAnswerResult AS P ";
            if (QuestionID != 0)
            {
                Cmd.CommandText += " WHERE P.QuestionID = @QuestionID";
                Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;
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

    #region method getList
    public DataTable getList(int QuestionID = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.ID,P.[Content],(SELECT COUNT(*) FROM tblAnswerResult AS Pl WHERE Pl.AnswerID = P.ID ) AS Num FROM tblAnswer AS P";
            if (QuestionID != 0)
            {
                Cmd.CommandText += " WHERE P.QuestionID = @QuestionID";
                Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;
            }

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

    #region method DataMove
    public bool DataMove(int Id, int vtid, int QuestionID)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT ID FROM tblAnswer WHERE ID != @ID AND QuestionID = @QuestionID ORDER BY IORDER ASC";
            Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;
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
                Cmd.CommandText = "UPDATE tblAnswer SET IORDER = @IORDER WHERE ID = @ID";
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
    public int setData(int id, int QuestionID, String Answer)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblAnswer WHERE ID = @ID)";
            Cmd.CommandText += " BEGIN INSERT INTO tblAnswer(QuestionID,Content) OUTPUT INSERTED.ID VALUES (@QuestionID,@Answer) END";
            Cmd.CommandText += " ELSE BEGIN UPDATE tblAnswer SET QuestionID = @QuestionID, Content = @Answer OUTPUT INSERTED.ID WHERE ID = @ID END";

            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("Answer", SqlDbType.NVarChar).Value = Answer;
            Cmd.Parameters.Add("QuestionID", SqlDbType.Int).Value = QuestionID;

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
}