using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataFakebookPost
/// </summary>
public class DataFakebookPost :DataAbstract
{
	#region method DataFakebookPost
    public DataFakebookPost()
    {
        identity = false;
        keyTable = "id";
        nameTable = "tblFakebookPost";
    }
    #endregion

    #region setData Atribute
    protected override SqlDbType? GetTypeAtribute(string name)
    {
        switch (name)
        {
            case "id":
            case "itype":
            case "name":
            case "full_picture":
            case "picture":
            case "link":
                return SqlDbType.NVarChar;
            case "message":
                return SqlDbType.NText;
            case "created_time":
                return SqlDbType.DateTime;
        }

        return null;
    }
    #endregion

    #region Method UpdateData
    public void UpdateDataToSqlData()
    {
        //getTopPostPage();

    }
    #endregion
}