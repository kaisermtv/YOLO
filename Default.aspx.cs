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

    public int i = 0;
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


        try
        {
            dynamic objData = objFacebook.getTopPostPage(5);

            dtlNewsFacebook.DataSource = objData.data;
            dtlNewsFacebook.DataBind();

        }
        catch { }
    }
    #endregion

    #region Method getTitle
    public string getTitle(dynamic objItem)
    {
        string name = "";

        try
        {
            name = objItem.name;
        }
        catch{}

        try
        {
            if (name == null || name == "" || name == "Timeline Photos")
            {
                string[] content = ((string)objItem.message).Split((char) 10);

                name = content[0];
            }

        }
        catch { }

        return name;
    }
    #endregion
}