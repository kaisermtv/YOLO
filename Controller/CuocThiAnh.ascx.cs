using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_CuocThiAnh : System.Web.UI.UserControl
{
    public string title = "";
    public string content = "";
    public string link = "";
    public string img = "";

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        FacebookAPI objFacebook = new FacebookAPI();
        int i = 0;

        try
        {
            dynamic objData = objFacebook.getTopPostPage();

            string type = objData.data[0].type;
            //if (type == "link") i++;

            while (i < 1)
            {
                if (objData == null || objData.error != null) return;


                objData = objFacebook.getNextPostPage();
                type = objData.data[0].type;

                i++;
            }

            title = objData.data[0].name;
            content = objData.data[0].message;
            link = objData.data[0].link;
            img = objData.data[0].full_picture;
        }
        catch { }
    }
    #endregion
}