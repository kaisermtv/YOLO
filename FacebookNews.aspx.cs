using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class FacebookNews : System.Web.UI.Page
{
    #region declare
    public string pic_cover = "";
    public string nextUrl = "";
    public FacebookAPI objFacebook = new FacebookAPI();
    //public Facebook.FacebookClient objFacebookClient = new Facebook.FacebookClient();
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //string tmp = "";
        //tmp = objFacebook.getCountLikes("262884504159437_320963415018212");
        //int a = 0;
    }
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        
        try
        {
            dynamic objDataCover = objFacebook.getInfoPage();

            pic_cover = objDataCover.cover.source;
        }
        catch { }

        try
        {
            dynamic objData = objFacebook.getTopPostPage(10);

            dtlData.DataSource = objData.data;
            dtlData.DataBind();

            nextUrl = objData.paging.cursors.after;
        }
        catch { }

    }
    #endregion
}