using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_System : System.Web.UI.MasterPage
{
    #region declare
    public String style = "";
    public String account = "";

    public ArrayList message = new ArrayList();
    public SystemClass objSystemClass = new SystemClass();
    #endregion

    #region method Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        SystemClass objSystemClass = new SystemClass();

        if(!objSystemClass.isLogin(1))
        {
            Response.Redirect("/system/login.aspx");
        }

        DataRow objData = objSystemClass.getAccount();

        account = objData["ACCT_NAME"].ToString();

    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetting objSetting = new DataSetting();

        style = objSetting.getValue("Domain");
        if (style != null) style = style.ToUpper();

        if (style != null && style != "") style += " - ";

        if (Context.Items["strTitle"] != null) {
            style += Context.Items["strTitle"].ToString(); 
        } else { 
            style += "QUẢN TRỊ HỆ THỐNG"; 
        }

        
    }
    #endregion
}
