using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListAccount : System.Web.UI.Page
{
    #region declare
    public int index = 0;

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH TÀI KHOẢN";

        if (!Page.IsPostBack)
        {
            DataAccount objAccount = new DataAccount();
            DataTable objData = objAccount.getList();

            //dtlAccount.DataSource = objData.DefaultView;
            //dtlAccount.DataBind();

            cpAccount.MaxPages = 1000;
            cpAccount.PageSize = 15;
            cpAccount.DataSource = objData.DefaultView;
            cpAccount.BindToControl = dtlAccount;
            dtlAccount.DataSource = cpAccount.DataSourcePaged;
            dtlAccount.DataBind();
        }
    }
    #endregion
}