using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AnswerEdit : System.Web.UI.Page
{
    #region declare
    private DataQuestion objQuestion = new DataQuestion();
    private DataAnswer objAnswer = new DataAnswer();

    public int index = 1;
    public int itemId = 0;
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        if (itemId == 0) Response.Redirect("QuestionList.aspx");

        DataTable objdata = objAnswer.getList(itemId);

        dtlData.DataSource = objdata.DefaultView;
        dtlData.DataBind();
    }
    #endregion

    #region Method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {

    }
    #endregion
}