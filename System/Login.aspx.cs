using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Login : System.Web.UI.Page
{
    #region declare value
    public String Message = "";
    public String Account = "";
    public String Password = "";
    public bool Remember = false;

    public SystemClass objSytem = new SystemClass();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (objSytem.isLogin(1)) Response.Redirect("/system/");

        if (Request.RequestType == "POST")
        {
            Account = Request.Form["account"];
            Password = Request.Form["password"];

            if (Request.Form["remember"] != null) Remember = true;

            if (objSytem.Login(Account, Password, Remember, 1)) Response.Redirect("/system/");

            Message = objSytem.Message;

            
        }
    }
}