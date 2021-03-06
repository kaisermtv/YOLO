﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAbstract
/// </summary>
abstract public class DataAbstract
{
    #region
    private Hashtable DataCollections = new Hashtable();

    public object this[string index]
    {
        get
        {
            try
            {
                return DataCollections[index];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        set
        {
            SqlDbType? type = GetTypeAtribute(index);
            if (type == null)
            {
                throw new IndexOutOfRangeException("Trường '" + index + "' không tồn tại!");
            }

            DataCollections[index] = value;
        }
    }

    abstract protected SqlDbType? GetTypeAtribute(string name);

    protected string keyTable = "";
    protected string nameTable = "";
    protected bool identity = true;

    #region Method CreateUpdateCode
    private void CreateUpdateCode(SqlCommand Cmd)
    {
        string sql = "";
        foreach (DictionaryEntry s in DataCollections)
        {
            string key = s.Key.ToString();
            if (key == keyTable) continue;

            if (sql == "")
            {
                sql += "UPDATE " + nameTable + " SET " + key + " = @" + key;
            }
            else
            {
                sql += "," + key + " = @" + key;
            }

            Cmd.Parameters.Add(key, GetTypeAtribute(key)).Value = (s.Value != null) ? s.Value : DBNull.Value;
        }

        sql += " OUTPUT INSERTED." + keyTable + " WHERE " + keyTable + " = @" + keyTable;
        Cmd.Parameters.Add(keyTable, SqlDbType.Int).Value = DataCollections[keyTable];

        Cmd.CommandText = sql;
    }
    #endregion

    #region Method CreateInsertCode
    private void CreateInsertCode(SqlCommand Cmd)
    {string sql = "";
        string sqlvl = "";
        foreach (DictionaryEntry s in DataCollections)
        {
            string key = s.Key.ToString();
            if (key == keyTable) continue;

            if (sql == "")
            {
                sql += "INSERT INTO " + nameTable + "(" + key;
                sqlvl += ") OUTPUT INSERTED." + keyTable + " VALUES(@" + key;
            }
            else
            {
                sql += "," + key;
                sqlvl += ",@" + key;
            }

            Cmd.Parameters.Add(key, GetTypeAtribute(key)).Value = (s.Value != null) ? s.Value : DBNull.Value;
        }

        Cmd.CommandText = sql + sqlvl + ")";
        
    }
    #endregion

    #region Method CreateSetCode
    private void CreateSetCode(SqlCommand Cmd)
    {
        string sqlup = "";
        string sql = "";
        string sqlvl = "";
        foreach (DictionaryEntry s in DataCollections)
        {
            string key = s.Key.ToString();
            if (key == keyTable) continue;

            if (sql == "")
            {
                sql += "INSERT INTO " + nameTable + "(" + key;
                sqlvl += ") OUTPUT INSERTED." + keyTable + " VALUES(@" + key;

                sqlup += "UPDATE " + nameTable + " SET " + key + " = @" + key;
            }
            else
            {
                sql += "," + key;
                sqlvl += ",@" + key;

                sqlup += "," + key + " = @" + key;
            }

            Cmd.Parameters.Add(key, GetTypeAtribute(key)).Value = (s.Value != null) ? s.Value : DBNull.Value;
        }

        sql += sqlvl + ")";

        sqlup += " OUTPUT INSERTED." + keyTable + " WHERE " + keyTable + " = @" + keyTable;

        Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM " + nameTable + " WHERE " + keyTable + " = @" + keyTable + ")";
        Cmd.CommandText += " BEGIN " + sql + " END";
        Cmd.CommandText += " ELSE BEGIN " + sqlup + " END";

        Cmd.Parameters.Add(keyTable, SqlDbType.Int).Value = DataCollections[keyTable];
    }
    #endregion

    public object setData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            if (keyTable != "")
            {
                if (identity)
                {
                    if (DataCollections.ContainsKey(keyTable))
                    {
                        CreateUpdateCode(Cmd);
                    }
                    else
                    {
                        CreateInsertCode(Cmd);
                    }
                }
                else if (DataCollections.ContainsKey(keyTable))
                {
                    CreateSetCode(Cmd);
                }
                else
                {
                    throw new Exception("Cần điền giá trị id");
                }
            }
            else
            {
                CreateInsertCode(Cmd);
            }

            //this.Message = Cmd.CommandText;
            object ret = Cmd.ExecuteScalar();

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


    #region declare value
    protected SqlConnection sqlCon;

    public String Message = "";
    public int ErrorCode = 0;
    #endregion

    #region method SQLConnect

    #region method getSQLConnect
    protected SqlCommand getSQLConnect()
    {
        try
        {
            if (this.sqlCon == null)
            {
                this.sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConnect"].ConnectionString);
                sqlCon.Open();
            }
        }
        catch (Exception ex)
        {
            this.sqlCon = null;
            throw ex;
        }

        try
        {
            return this.sqlCon.CreateCommand();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region method SQLClose
    protected void SQLClose()
    {
        if (this.sqlCon != null)
        {
            try
            {
                this.sqlCon.Close();
                this.sqlCon.Dispose();
                this.sqlCon = null;
            }
            catch (Exception ex)
            {
                this.sqlCon.Dispose();
                this.sqlCon = null;
                throw ex;
            }

        }
    }
    #endregion

    #region method findFirst
    protected DataRow findFirst(SqlCommand Cmd)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0];
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region method findAll
    protected DataTable findAll(SqlCommand Cmd)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds.Tables[0];
    }
    #endregion

    #endregion

    #region destroy
    ~DataAbstract()
    {
        //this.SQLClose();
    }
    #endregion
}