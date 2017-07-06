using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_LoadMoreFacebook : System.Web.UI.Page
{
    #region declare
    private FacebookAPI objFacebook = new FacebookAPI();
    //public Facebook.FacebookClient objFacebookClient = new Facebook.FacebookClient();
    public string nextUrl = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            nextUrl = Request["after"].ToString();
        }
        catch { }
    } 
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        if (nextUrl != "")
        {
            try
            {
                dynamic objData = objFacebook.getTopPostPage(10, nextUrl);

                dtlData.DataSource = objData.data;
                dtlData.DataBind();

                nextUrl = objData.paging.cursors.after;
            }
            catch { }
        }
        

    }
    #endregion
}