using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Footer : System.Web.UI.UserControl
{
    #region declare
    public int userOnline = 0;
    public int userRegis = 0;

    private DataNewsGroup objNewsGroup = new DataNewsGroup();
    #endregion

    #region Method Page_PreRender
    protected void Page_PreRender(object sender, EventArgs e)
    {

        DataRemember objRemember = new DataRemember();
        userOnline = objRemember.getCountOnline();

        DataAccount objAccount = new DataAccount();
        userRegis = objAccount.getCountAccout();
    }
    #endregion

    #region getUrlMenuById
    public string getUrlMenuById(int id)
    {
        string ret = objNewsGroup.getLinkById(id);
        if(ret != null)
        {
            return ret;
        }
        return "/tin-tuc";
    }
    #endregion
}