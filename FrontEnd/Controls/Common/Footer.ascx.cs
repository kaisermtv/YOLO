using System;
using System.Collections.Generic;
using System.Data;
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
    private DataMenu objMenu = new DataMenu();
    #endregion

    #region Method Page_PreRender
    protected void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objMenu.getList(0, 2);
        if(objData.Rows.Count > 0)
        {
            dtlFooter.DataSource = objData.DefaultView;
            dtlFooter.DataBind();
        }


        //DataRemember objRemember = new DataRemember();
        //userOnline = objRemember.getCountOnline();

        DataAccount objAccount = new DataAccount();
        userRegis = objAccount.getCountAccout();
    }
    #endregion

    #region getItemMenu()
    public DataTable getItemMenu(int id)
    {
        DataTable objData = objMenu.getList(id,0);

        return objData;
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

    #region getNameCatById
    public string getNameCatById(int id)
    {
        return objNewsGroup.getNameById(id);
    }
    #endregion
}