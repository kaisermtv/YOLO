using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ContactEdit : System.Web.UI.Page
{
    #region declare
    private DataContact objContact = new DataContact();
    private SystemClass objSystemClass = new SystemClass();

    public int index = 0;
    public int itemId = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            objSystemClass.addMessage("Bạn cần chọn liện hệ");

            Response.Redirect("ContactList.aspx");
            return;
        }
        if (!Page.IsPostBack)
        {
            DataRow objData = this.objContact.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Không tìm thấy liên hệ");

                Response.Redirect("ContactList.aspx");
                return;
            }

            this.txtFullName.Text = objData["FullName"].ToString();
            this.txtEmail.Text = objData["Email"].ToString();
            this.txtTitle.Text = objData["Title"].ToString();
            this.txtQuestion.Text = objData["Question"].ToString();
            this.txtContent.Text = objData["Answer"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtContent.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập nội dung trả lời.");
            this.txtContent.Focus();
            return;
        }

        //this.objContact.setData(this.itemId, this.txtContent.Text, this.ckbState.Checked, DateTime.Now, 0);

        //Response.Redirect("ContactList.aspx");
    }
}