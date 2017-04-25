using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Login : System.Web.UI.Page
{
    #region declare value
    public String Message = "";
    public String Account = "";
    public String Password = "";

    public SystemClass objSytem = new SystemClass();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "Đăng nhập";

        if (objSytem.isLogin()) Response.Redirect("/");

        if (Request.RequestType == "POST")
        {
            Account = Request.Form["account"];
            Password = Request.Form["password"];

            //if (Request.Form["remember"] != null) Remember = true;

            if (objSytem.Login(Account, Password, true, 0))
            {
                if (Request.Form["rederict"] != null && Request.Form["rederict"] != "") Response.Redirect(Request.Form["rederict"]);
                
                Response.Redirect("/");
            }

            Message = objSytem.Message;


        }
    }
}