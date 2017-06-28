using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_QuestionEdit : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;

    private DataQuestion objQuestion = new DataQuestion();
    private SystemClass objSystemClass = new SystemClass();
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            DataRow objData = objQuestion.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn câu hỏi để sửa.");
                Response.Redirect("NewsList.aspx");
                return;
            }

            txtTitle.Text = objData["Question"].ToString();
            txtContent.Text = objData["DESCRIBE"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtTitle.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập câu hỏi.");
            this.txtTitle.Focus();
            return;
        }

        itemId = this.objQuestion.setData(itemId,this.txtTitle.Text, this.txtContent.Text);

        if (itemId == 0)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objQuestion.Message + ")");
        }
        else
        {
            objSystemClass.addMessage("Cập nhật câu hỏi thành công.");
            Response.Redirect("QuestionEdit.aspx?id=" + itemId);
        }
    }
    #endregion
}