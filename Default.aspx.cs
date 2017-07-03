using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    #region declare
    public string pic_cover = "";

    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    #endregion


    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        FacebookAPI objFacebook = new FacebookAPI();
        try
        {
            dynamic objData = objFacebook.getInfoPage();

            pic_cover = objData.cover.source;
        }
        catch { }
    }
    #endregion
}