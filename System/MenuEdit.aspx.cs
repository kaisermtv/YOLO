using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_MenuEdit : System.Web.UI.Page
{
    #region declare
    private DataMenu objMenu = new DataMenu();
    private SystemClass objSystemClass = new SystemClass();

    public int itemId = 0;
    public int menuid = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            

            DataRow objData = objMenu.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn menu để sửa.");
                Response.Redirect("Menu.aspx");
                return;
            }

            txtName.Text = objData["NAME"].ToString();
            txtDescribe.Text = objData["DESCRIBE"].ToString();
            txtLink.Text = objData["LINK"].ToString();

            menuid = (int)objData["MenuID"];

            ddlGroup.DataSource = objMenu.getDataToCombobox("-- Thư mục gốc --");
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            if (objData["PID"].ToString() != null && objData["PID"].ToString() != "")
            {
                ddlGroup.SelectedValue = objData["PID"].ToString();
            }
            else
            {
                ddlGroup.SelectedValue = "0";
            }

        }
    }
    #endregion

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            objSystemClass.addMessage("Không được để trông tên menu");
            return;
        }

        int ret = objMenu.UpdateData(itemId,int.Parse(ddlGroup.SelectedValue),txtName.Text, txtDescribe.Text, txtLink.Text);

        if (ret != 0)
        {
            objSystemClass.addMessage("Cập nhật menu thành công");
            Response.Redirect("MenuEdit.aspx?id=" + ret);
        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objMenu.Message + ")");
        }
    }
    #endregion
}