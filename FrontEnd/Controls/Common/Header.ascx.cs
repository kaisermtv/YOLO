using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemClass objSystemClass = new SystemClass();
        if(objSystemClass.isLogin())
        {
            DataRow objData = objSystemClass.getAccount();
            if (objData == null) objSystemClass.Logout();
            else
            {
                userName.InnerText = objData["ACCT_NAME"].ToString();
                logout.InnerHtml = "<a href=\"/Logout\" class='dadangnhap'>Logout</a>";
            }
        }
    }
}