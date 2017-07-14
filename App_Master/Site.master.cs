using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Site : System.Web.UI.MasterPage
{
    #region declare 
    private DataSetting objSetting = new DataSetting();

    private DataMenu objMenu = new DataMenu();
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Event Page_PreRender()
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objDataMenu = objMenu.getList(0,1,true);
        if (objDataMenu != null)
        {
            dtlMenu.DataSource = objDataMenu.DefaultView;
            dtlMenu.DataBind();
        }
    }
    #endregion

    #region Method GetSetting()
    public string GetSetting(string key)
    {
        return objSetting.getValue(key);
    }
    #endregion

    #region Method getSubMenu
    public DataTable getSubMenu(int id)
    {
        return objMenu.getList(id);
    }
    #endregion

}
