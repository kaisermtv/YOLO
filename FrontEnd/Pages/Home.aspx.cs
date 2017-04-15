using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Home : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DataTable objData = objNews.getDataTop(4);

            dtlNews.DataSource = objData.DefaultView;
            dtlNews.DataBind();

            DataTable objData1 = objNews.getDataTop(3);
            dtlData1.DataSource = objData.DefaultView;
            dtlData1.DataBind();

            DataTable objData2 = objNews.getDataTop(3);
            dtlData2.DataSource = objData.DefaultView;
            dtlData2.DataBind();

            DataTable objData3 = objNews.getDataTop(3);
            dtlData3.DataSource = objData.DefaultView;
            dtlData3.DataBind();

            DataTable objData4 = objNews.getDataTop(3);
            dtlData4.DataSource = objData.DefaultView;
            dtlData4.DataBind();
        }
    }
}