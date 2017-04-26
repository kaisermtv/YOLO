using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AnswerMove : System.Web.UI.Page
{
    #region declare
    private DataAnswer objAnswer = new DataAnswer();
    //private SystemClass objSystemClass = new SystemClass();

    public int question = 0;
    public int itemId = 0;
    public int vtId = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        try
        {
            this.question = int.Parse(Request["question"].ToString());
        }
        catch { }

        try
        {
            this.vtId = int.Parse(Request["vt"].ToString());
        }
        catch { }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            objAnswer.DataMove(itemId, vtId,question);
        }

        Response.Redirect("AnswerEdit.aspx?id=" + question);
    }
}