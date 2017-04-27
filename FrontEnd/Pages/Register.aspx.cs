using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Register : System.Web.UI.Page
{
    #region declare value
    public String Message = "";
    public String Account = "";
    public String Password = "";
    public String Password2 = "";
    public String Email = "";
    public String Phone = "";

    private SystemClass objSytem = new SystemClass();
    private DataAccount objAccount = new DataAccount();
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "Đăng ký";

        if (objSytem.isLogin()) Response.Redirect("/");

        if (Request.RequestType == "POST")
        {
            Account = Request.Form["account"];
            Password = Request.Form["password"];
            Password2 = Request.Form["password2"];
            Email = Request.Form["email"];
            Phone = Request.Form["phone"];

            if (Account == "")
            {
                Message = "Bạn cần nhập tên tài khoản";
                return;
            }

            if (Email == "")
            {
                Message = "Bạn cần nhập địa chỉ hòm thư";
                return;
            }

            if (Password == "")
            {
                Message = "Bạn cần nhập mật khẩu";
                return;
            }

            if (Password != Password2)
            {
                Message = "Nhập lại mật khẩu không khớp";
                return;
            }

            int ret = objAccount.addAccount(Account, Password);

            if(ret != 0)
            {
                objAccount.setAccountInfo(ret, Email, Phone);

                objSytem.Login(Account, Password, true,0);
                Response.Redirect("/");
            }
            else
            {
                Message = "Có lỗi xảy ra! Xin thử lại.";// +objSytem.Message;
            }
        }
    }
    #endregion
}