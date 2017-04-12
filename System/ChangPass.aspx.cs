using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ChangPass : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;

    private DataAccount objAccount = new DataAccount();
    private SystemClass objSystemClass = new SystemClass();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        if (!Page.IsPostBack)
        {
            DataRow objData = objAccount.getAccountInfo(this.itemId);
            if (objData == null) Response.Redirect("ListAccount.aspx");

            txtUserName.Text = objData["ACCT_NAME"].ToString();
        }
    }
    #endregion 

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        String pass = txtPassword.Text;
        if (pass == "")
        {
            objSystemClass.addMessage("Mật khẩu không được để trống");
            txtPassword.Focus();
            return;
        }

        if (pass != txtPassword2.Text)
        {
            objSystemClass.addMessage("Mật khẩu 2 không khớp");
            txtPassword2.Focus();
            return;
        }

        if (objAccount.changPass(itemId, pass))
        {
            objSystemClass.addMessage("Đổi mật khẩu thành công");

            Response.Redirect("ChangPass.aspx?id=" + itemId);
        } else {
            objSystemClass.addMessage("Đổi mật khẩu không thành công! (" + objAccount.Message + ")");
        }
    }
    #endregion
}