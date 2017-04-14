using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_QuestionList : System.Web.UI.Page
{
    #region declare
    private DataQuestion objQuestion = new DataQuestion();

    public int index = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH CÂU HỎI THĂM DÒ";

    }
    #endregion

    #region Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objQuestion.getList();

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpData.MaxPages = 1000;
        cpData.PageSize = 15;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int id;
        try
        {
            id = int.Parse(idDel.Value);
        }
        catch
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        if (id != 0)
        {
            objQuestion.delData(id);

            //getData();
        }
        else
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }
    }
    #endregion
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {

    }
}