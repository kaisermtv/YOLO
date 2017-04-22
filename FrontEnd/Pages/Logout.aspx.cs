using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemClass objSystemClass = new SystemClass();
        objSystemClass.Logout();
        Response.Redirect("/dang-nhap");
    }
}