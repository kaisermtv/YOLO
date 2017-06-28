using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_MenuNew : System.Web.UI.Page
{
    #region declare
    private DataMenu objMenu = new DataMenu();
    private SystemClass objSystemClass = new SystemClass();

    public int group = 0;

    public int menuid = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.group = int.Parse(Request["pid"].ToString());
        }
        catch { }

        try
        {
            this.menuid = int.Parse(Request["type"].ToString());
        }
        catch { }
        if (menuid == 0) menuid = 1;

        if (!Page.IsPostBack)
        {
            ddlGroup.DataSource = objMenu.getDataToCombobox("-- Thư mục gốc --");
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            ddlGroup.SelectedValue = group.ToString();
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

        int ret = 0;
        try
        {
            ret = objMenu.addData(int.Parse(ddlGroup.SelectedValue), txtName.Text, txtDescribe.Text, txtLink.Text,0,menuid);
        }
        catch (Exception ex)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + ex.Message + ")");
            return;
        }

        if (ret != 0)
        {
            objSystemClass.addMessage("Tạo menu thành công");
            Response.Redirect("MenuEdit.aspx?id=" + ret);
        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objMenu.Message + ")");
        }
        
        
    }
    #endregion
}