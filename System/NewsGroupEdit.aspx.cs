using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_NewsGroupEdit : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;

    private DataNewsGroup objNewsGroup = new DataNewsGroup();
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

        if (!Page.IsPostBack && this.itemId == 0)
        {
            ddlTrangThai.SelectedValue = "1";
        }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            DataRow objData = objNewsGroup.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn nhóm để sửa.");
                Response.Redirect("NewsGroupList.aspx");
                return;
            }

            txtName.Text = objData["NAME"].ToString();
            txtDescribe.Text = objData["DESCRIBE"].ToString();
            ddlTrangThai.SelectedValue = objData["NSTATUS"].ToString();
        }
    }
    #endregion

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            objSystemClass.addMessage("Không được để trông tên nhóm");
            return;
        }


        int ret = objNewsGroup.setData(this.itemId, txtName.Text, txtDescribe.Text, int.Parse(ddlTrangThai.SelectedValue));

        if (ret != 0)
        {
            objSystemClass.addMessage("Cập nhật thành công");
            Response.Redirect("NewsGroupEdit.aspx?id=" + ret);
        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objNewsGroup.Message + ")");
        }

    }
    #endregion
}