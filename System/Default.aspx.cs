using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Default : System.Web.UI.Page
{
    public SystemClass objSytem = new SystemClass();
    public String loginCookie = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "Dashboard";

        loginCookie = objSytem.SessionKey;
    }
}