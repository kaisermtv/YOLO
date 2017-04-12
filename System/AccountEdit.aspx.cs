using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AccountEdit : System.Web.UI.Page
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
        catch{}

        if(!Page.IsPostBack)
        {
            DataGroupAcct objGroupAcct = new DataGroupAcct();
            ddlGroup.DataSource = objGroupAcct.getDataToCombobox();
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            DataRow objData = objAccount.getAccountInfo(this.itemId);
            if (objData == null) Response.Redirect("ListAccount.aspx");

            txtUserName.Text = objData["ACCT_NAME"].ToString();
            ddlGroup.SelectedValue = objData["ACCT_GROUP"].ToString();
            txtFullName.Text = objData["FULLNAME"].ToString();
            txtEmail.Text = objData["EMAIL"].ToString();
            txtNgaySinh.Value = objData["AGE"].ToString();
            ddlGioiTinh.SelectedValue = objData["SEX"].ToString();
        }
    }
    #endregion 

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        int group = 0;
        try
        {
            group = int.Parse(ddlGroup.SelectedValue);
        }
        catch { }

        DateTime age;
        try
        {
            age = DateTime.Parse(txtNgaySinh.Value);
        }
        catch
        {
            objSystemClass.addMessage("Định dạng ngày sinh không đúng!");
            txtNgaySinh.Focus();
            return;
        }

        int sex = 0;
        try
        {
            sex = int.Parse(ddlGioiTinh.Text);
        }
        catch
        {
            objSystemClass.addMessage("Bạn cần chọn giới tính");
            ddlGioiTinh.Focus();
            return;
        }

        if (sex < 0 && sex > 1)
        {
            objSystemClass.addMessage("Bạn cần chọn giới tính");
            ddlGioiTinh.Focus();
            return;
        }
        
        objAccount.setAccountInfo(itemId, txtEmail.Text.Trim(), txtFullName.Text, age, sex, group);

        if (objAccount.Message != "")
        {
            objSystemClass.addMessage(objAccount.Message);
        }
        else
        {
            objSystemClass.addMessage("Cập nhật thành công.");
            Response.Redirect("AccountEdit.aspx?id=" + itemId);
        }


    }
    #endregion
}