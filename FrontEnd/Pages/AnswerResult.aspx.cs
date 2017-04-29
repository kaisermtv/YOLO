using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_AnswerResult : System.Web.UI.Page
{
    #region declare
    private SystemClass objSystem = new SystemClass();
    private DataAnswer objAnswer = new DataAnswer();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.RequestType != "POST") Response.Redirect("/");

        string url = Request.Form["redirect"];
        if (url == null || url == "") url = "/";

        if (!objSystem.isLogin()) Response.Redirect(url);

        int QuestionID = 0;
        try
        {
            QuestionID = int.Parse(Request.Form["QuestionID"]);
        } catch {}

        if (QuestionID == 0) Response.Redirect(url);

        int Answer = 0;
        try
        {
            Answer = int.Parse(Request.Form["AnswerResul"]);
        }
        catch { }
        if (Answer == 0) Response.Redirect(url);

        objAnswer.setUserResult(QuestionID, Answer);

        Response.Redirect(url);
    }
}