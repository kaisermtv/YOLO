using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_GroupAcctEdit : System.Web.UI.Page
{
    #region declare
    public int itemId = -1;

    private DataGroupAcct objGroupAcct = new DataGroupAcct();
    private SystemClass objSystemClass = new SystemClass();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch {
            this.itemId = -1;
        }

        if (!Page.IsPostBack && this.itemId != -1)
        {
            DataRow objData = objGroupAcct.getData(this.itemId);
            if(objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn nhóm để sửa.");
                Response.Redirect("GroupAcctList.aspx");
                return;
            }

            txtName.Text = objData["NAME"].ToString();
            txtDescribe.Text = objData["DESCRIBE"].ToString();
        }
    }
    #endregion

    #region method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        if(txtName.Text.Trim() == "")
        {
            objSystemClass.addMessage("Không được để trông tên nhóm");
            return;
        }

        try
        {
            if (this.itemId != -1)
            {
                objGroupAcct["ID"] = itemId;
            }

            objGroupAcct["NAME"] = txtName.Text.Trim();
            objGroupAcct["DESCRIBE"] = txtDescribe.Text.Trim();

            int ret = (int)objGroupAcct.setData();
            if (this.itemId == -1)
            {
                objSystemClass.addMessage("Thêm mới thành công!");
            }
            else
            {
                objSystemClass.addMessage("Cập nhật thành công!");
            }

            Response.Redirect("GroupAcctEdit.aspx?id=" + ret,false);
        }
        catch(Exception ex)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + ex.Message + ")");
        }

        
    }
    #endregion
}