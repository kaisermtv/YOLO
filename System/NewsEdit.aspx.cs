using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class System_NewsEdit : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;
    public int group = 0;

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

        try
        {
            group = int.Parse(Request["group"].ToString());
        }
        catch { }

        if (!Page.IsPostBack)
        {
            DataNewsGroup objGroup = new DataNewsGroup();
            ddlGroup.DataSource = objGroup.getDataToCombobox("");
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            if(group != 0)
            {
                ddlGroup.SelectedValue = group.ToString();
            }
            
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

            htxtimg1.Value = objData["ImgUrl"].ToString();
            htxtimg.Value = objData["ImgUrl"].ToString();
           
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

        //if (this.txtContent.Text.Trim() == "")
        //{
        //    objSystemClass.addMessage("Bạn chưa nhập nội dung của bài viết.");
        //    this.txtContent.Focus();
        //    return;
        //}

        if(itemId == 0)
        {
            string linkImage = saveImage(FileUpload, htxtimg, htxtimg1);



            itemId = this.objNews.addData(this.txtTitle.Text, int.Parse(this.ddlGroup.SelectedValue.ToString()), this.txtShortContent.Text, this.txtContent.Text.Trim(), linkImage, this.txtAuthor.Text, ckbNoiBat.Checked, txtTag.Text);
            if (itemId != 0)
            {
                objSystemClass.addMessage("Đăng bài viết thành công.");

                if (chkShareFb.Checked)
                {
                    try
                    {
                        FacebookAPI objFb = new FacebookAPI();

                        dynamic retdata = objFb.Share("", "", "http://113.164.227.242:4083/" + SystemClass.convertToUnSign2(this.txtTitle.Text) + "-v" + itemId, "http://113.164.227.242:4083" + linkImage, this.txtTitle.Text, this.txtShortContent.Text);

                        string idfb = retdata.id;

                        if(idfb != "")
                        {
                            objNews["Id"] = itemId;
                            objNews["FacebookId"] = idfb;
                            objNews.setData();
                        }
                    }
                    catch
                    {
                        objSystemClass.addMessage("Không thể đăng len facebook");
                    }
                }


            }
        } else {
            itemId = this.objNews.UpdateData(itemId, this.txtTitle.Text, int.Parse(this.ddlGroup.SelectedValue.ToString()), this.txtShortContent.Text, this.txtContent.Text.Trim(), saveImage(FileUpload, htxtimg, htxtimg1), this.txtAuthor.Text, ckbNoiBat.Checked, txtTag.Text);
            if (itemId != 0) objSystemClass.addMessage("Cập nhật bài viết thành công.");
        }

        if (itemId == 0)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objNews.Message + ")");
        }
        else
        {
            if (this.group.ToString() == this.ddlGroup.SelectedValue)
            {
                Response.Redirect("NewsEdit.aspx?id=" + itemId+"&Group="+group);
            }
            else
            {
                Response.Redirect("NewsEdit.aspx?id=" + itemId);
            }
            
        }
    }
    #endregion

    #region method saveImage
    private String saveImage(FileUpload fileupload, HtmlInputHidden inputc, HtmlInputHidden inputc1)
    {
        string img = SystemClass.saveImage(fileupload.PostedFile, "NEWSIMAGE", inputc.Value);

        if (inputc1.Value != "" && img != inputc1.Value) SystemClass.DeleteFile(inputc1.Value);

        inputc.Value = img;
        inputc1.Value = img;

        return img;
    }
    #endregion
}