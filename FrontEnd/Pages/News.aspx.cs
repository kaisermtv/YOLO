using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_News : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();

    public int itemId = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        if (!Page.IsPostBack)
        {
            DataTable objData = objNews.getDataTop(10, itemId);

            dtlNews.DataSource = objData.DefaultView;
            dtlNews.DataBind();

        }
    }
}