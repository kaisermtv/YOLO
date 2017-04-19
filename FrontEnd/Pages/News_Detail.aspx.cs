using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_News_Detail : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();

    public DataRow objData;
    public int itemId = 0;

    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(getParam("id"));
        }
        catch { }

        if (itemId == 0) Response.Redirect("tin-tuc");

        objData = objNews.getData(itemId);

        if (objData == null) Response.Redirect("tin-tuc");


    }
    #endregion

    #region Method getParam
    private String getParam(String key)
    {
        try
        {
            if (RouteData.Values[key] != null) return RouteData.Values[key].ToString();
            if (Request[key] != null) return Request[key].ToString();
        }
        catch { }

        return null;
    }
    #endregion
}