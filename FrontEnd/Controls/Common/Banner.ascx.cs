using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Banner : System.Web.UI.UserControl
{
    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataNews objNews = new DataNews();
        DataTable objData = objNews.getDataTop(5,0,1,true);

        dtlNews.DataSource = objData.DefaultView;
        dtlNews.DataBind();
    }
    #endregion
}