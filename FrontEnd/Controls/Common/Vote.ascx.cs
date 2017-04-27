using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Vote : System.Web.UI.UserControl
{
    #region declare 
    private DataQuestion objQuestion = new DataQuestion();
    private DataAnswer objAnswer = new DataAnswer();
    private SystemClass objSystem = new SystemClass();

    public DataRow objData;
    public int countAnswerResult = 0;
    public bool post = true;
    public int result = 0;
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            objData = objQuestion.getPublic();
            if(objData == null) return;
            
            DataTable objDataAnswer = objAnswer.getList((int)objData["ID"]);
            if (objDataAnswer.Rows.Count == 0) return;

            countAnswerResult = objAnswer.getCountAnswerResult((int)objData["ID"]);

            if (!objSystem.isLogin())
            {
                post = false;
            }
            else
            {
                DataRow objResult = objAnswer.getUserResult((int)objData["ID"]);
                if(objResult == null)
                {
                    post = true;
                }
                else
                {
                    result = (int)objResult["AnswerID"];
                    post = false;
                }

            }


            dtlQuestion.DataSource = objDataAnswer.DefaultView;
            dtlQuestion.DataBind();

            
        }


    }
    #endregion
}