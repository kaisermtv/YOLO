using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_GroupAcctList : System.Web.UI.Page
{
    #region declare
    private DataGroupAcct objGroupAcct = new DataGroupAcct();

    public int index = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH NHÓM TÀI KHOẢN";

        //if (!Page.IsPostBack)
        //{
            DataTable objData = objGroupAcct.getList();

            //dtlAccount.DataSource = objData.DefaultView;
            //dtlAccount.DataBind();

            cpData.MaxPages = 1000;
            cpData.PageSize = 15;
            cpData.DataSource = objData.DefaultView;
            cpData.BindToControl = dtlData;
            dtlData.DataSource = cpData.DataSourcePaged;
            dtlData.DataBind();
            index = 1;
        //}
    }
}