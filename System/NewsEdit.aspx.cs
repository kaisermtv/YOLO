using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_NewsEdit : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;

    private DataNews objNews = new DataNews();
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

        if (!Page.IsPostBack)
        {
            DataNewsGroup objGroup = new DataNewsGroup();
            ddlGroup.DataSource = objGroup.getDataToCombobox("");
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();
        }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            DataRow objData = objNews.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn nhóm để sửa.");
                Response.Redirect("NewsList.aspx");
                return;
            }

            txtTitle.Text = objData["Title"].ToString();
            ddlGroup.SelectedValue = objData["CatId"].ToString();
            txtShortContent.Text = objData["ShortContent"].ToString();
            txtContent.Text = objData["Content"].ToString();
            txtAuthor.Text = objData["Author"].ToString();
            ckbNoiBat.Checked = (bool)objData["NoiBat"];
            txtTag.Text = objData["tag"].ToString();
                
            if (objData["ImgUrl"] != null && objData["ImgUrl"].ToString() != "") htxtimg.Value = "/Images/News/" + objData["ImgUrl"].ToString();
            
        }

        
    }
    #endregion 

    #region Method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtTitle.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập tiêu đề của bài viết.");
            this.txtTitle.Focus();
            return;
        }

        int group = int.Parse(this.ddlGroup.SelectedValue.ToString());
        if (group == 0)
        {
            objSystemClass.addMessage("Bạn cần chọn nhóm tin tức.");
            this.ddlGroup.Focus();
            return;
        }


        if (this.txtShortContent.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập nội dung văn tắt của bài viết.");
            this.txtShortContent.Focus();
            return;
        }

        if (this.txtContent.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập nội dung của bài viết.");
            this.txtContent.Focus();
            return;
        }

        if(itemId == 0)
        {
            itemId = this.objNews.addData(this.txtTitle.Text, int.Parse(this.ddlGroup.SelectedValue.ToString()), this.txtShortContent.Text, this.txtContent.Text.Trim(), saveImage(FileUpload, htxtimg), this.txtAuthor.Text,ckbNoiBat.Checked,txtTag.Text);
            if (itemId != 0) objSystemClass.addMessage("Đăng bài viết thành công.");
        } else {
            itemId = this.objNews.UpdateData(itemId, this.txtTitle.Text, int.Parse(this.ddlGroup.SelectedValue.ToString()), this.txtShortContent.Text, this.txtContent.Text.Trim(), saveImage(FileUpload, htxtimg), this.txtAuthor.Text, ckbNoiBat.Checked, txtTag.Text);
            if (itemId != 0) objSystemClass.addMessage("Cập nhật bài viết thành công.");
        }

        if (itemId == 0)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objNews.Message + ")");
        }
        else
        {
            Response.Redirect("NewsEdit.aspx?id=" + itemId);
        }
    }
    #endregion

    #region method saveImage
    private String saveImage(FileUpload fileupload, System.Web.UI.HtmlControls.HtmlInputHidden inputc)
    {
        try
        {

            if (fileupload.PostedFile.ContentLength > 5048576 || fileupload.PostedFile.ContentLength == 0)
            {
                if (inputc.Value != "")
                {
                    return inputc.Value.Substring(13);
                }

                return "";
            }
            else
            {
                string strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["NEWSIMAGE"].ToString());

                string sFileName = "0-" + DateTime.Now.ToString("dd-MM-yyy--hh-mm-ss-fffffff-");
                string strEx = System.IO.Path.GetFileName(fileupload.PostedFile.FileName);
                //strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                fileupload.PostedFile.SaveAs(strBaseLoactionImg);

                inputc.Value = "/Images/News/" + sFileName + strEx;
                return sFileName + strEx;
            }
        }
        catch //(Exception ex)
        {
            //this.lblMsg.Text = ex.Message; //HttpContext.Current.Response.Write(ex.Message);
            return "";
        }
    }
    #endregion
}