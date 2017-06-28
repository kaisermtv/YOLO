using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AccountNew : System.Web.UI.Page
{
    #region declare
    private SystemClass objSystemClass = new SystemClass();
    private DataAccount objAccount = new DataAccount();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DataGroupAcct objGroupAcct = new DataGroupAcct();
            ddlGroup.DataSource = objGroupAcct.getDataToCombobox();
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();
        }


    }
    #endregion

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {

        String Acct = txtUserName.Text.Trim();
        if(Acct == "")
        {
            objSystemClass.addMessage("Tài khoản không được để trống");
            txtUserName.Focus();
            return;
        }

        if(objAccount.getAccount(Acct) != null )
        {
            objSystemClass.addMessage("Tài khoản đã tồn tài");
            txtUserName.Focus();
            return;
        }

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

        int group = 0;
        try
        {
            group = int.Parse(ddlGroup.SelectedValue);
        } catch {}

        DateTime age;
        try
        {
            age = DateTime.Parse(txtNgaySinh.Value);
        } catch
        {
            objSystemClass.addMessage("Định dạng ngày sinh không đúng!");
            txtNgaySinh.Focus();
            return;
        }

        int sex = 0;
        try{
            sex = int.Parse(ddlGioiTinh.Text);
        }
        catch {
            objSystemClass.addMessage("Bạn cần chọn giới tính");
            ddlGioiTinh.Focus();
            return;
        }

        if(sex < 0 && sex > 1)
        {
            objSystemClass.addMessage("Bạn cần chọn giới tính");
            ddlGioiTinh.Focus();
            return;
        }


        int ret = objAccount.addAccount(Acct, pass, group);
        if(ret == 0)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objAccount.Message + ")");
            return;
        }

        objAccount.setAccountInfo(ret, txtEmail.Text.Trim(), txtFullName.Text, age, sex);

        objSystemClass.addMessage("Tạo tài khoản thành công.");

        Response.Redirect("AccountEdit.aspx?id=" + ret);

    }
    #endregion
}