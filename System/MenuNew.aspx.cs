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

    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
       
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

        int ret = objMenu.addData(txtName.Text, txtDescribe.Text,txtLink.Text);

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