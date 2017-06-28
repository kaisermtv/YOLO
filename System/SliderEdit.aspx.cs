using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class System_SliderEdit : System.Web.UI.Page
{
    #region declare
    private DataSlider objSlider = new DataSlider();
    private SystemClass objSystemClass = new SystemClass();

    public int itemId = 0;
    public int sliderid = 1;
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
            this.sliderid = int.Parse(Request["type"].ToString());
        }
        catch { }
        if (sliderid == 0) sliderid = 1;

        if (!Page.IsPostBack && this.itemId != 0)
        {
            DataRow objData = objSlider.getData(this.itemId);
            if (objData == null)
            {
                objSystemClass.addMessage("Bạn cần chọn slider cần sửa.");
                Response.Redirect("SliderList.aspx");
                return;
            }

            txtTitle.Text = objData["TITLE"].ToString();
            txtDescribe.Text = objData["DESCRIBE"].ToString();
            txtLink.Text = objData["LINK"].ToString();

            sliderid = (int)objData["NTYPE"];

            htxtimg1.Value = objData["IMG"].ToString();
            htxtimg.Value = objData["IMG"].ToString();
        }

        if (!Page.IsPostBack)
        {
            group.Value = sliderid.ToString();
        }


    }
    #endregion

    #region Method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        //if (this.txtTitle.Text.Trim() == "")
        //{
        //    objSystemClass.addMessage("Bạn chưa nhập tiêu đề.");
        //    this.txtTitle.Focus();
        //    return;
        //}
        int ret = 0;
        try
        {
            if (itemId != 0) objSlider["ID"] = itemId;
            objSlider["TITLE"] = txtTitle.Text;
            objSlider["DESCRIBE"] = txtDescribe.Text;
            objSlider["LINK"] = txtLink.Text;
            objSlider["IMG"] = saveImage(FileUpload, htxtimg, htxtimg1);
            if (itemId == 0) objSlider["NTYPE"] = sliderid;

            ret = (int)objSlider.setData();
        }
        catch
        {
            objSystemClass.addMessage("Có lỗi xảy ra!");
        }

        if (ret != 0)
        {
            if (itemId != 0)
            {
                objSystemClass.addMessage("Cập nhật thành công");
            }
            else
            {
                objSystemClass.addMessage("Tạo mới thành công");
            }

            Response.Redirect("SliderEdit.aspx?id=" + ret);
        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra!");
        }

        //int ret = objSlider.setData(itemId, txtTitle.Text, txtDescribe.Text, txtLink.Text, saveImage(FileUpload, htxtimg, htxtimg1), sliderid);

        //if (ret == 0)
        //{
        //    objSystemClass.addMessage("Có lỗi xảy ra! (" + objSlider.Message + ")");
        //}
        //else
        //{
        //    if (itemId != 0)
        //    {
        //        objSystemClass.addMessage("Cập nhật thành công");
        //    }
        //    else
        //    {
        //        objSystemClass.addMessage("Tạo mới thành công");
        //    }
            
        //    Response.Redirect("SliderEdit.aspx?id=" + ret);
        //}
    }
    #endregion

    #region method saveImage
    private String saveImage(FileUpload fileupload, HtmlInputHidden inputc, HtmlInputHidden inputc1)
    {
        string img = SystemClass.saveImage(fileupload.PostedFile, "SLIDERIMAGE", inputc.Value);

        if (inputc1.Value != "" && img != inputc1.Value) SystemClass.DeleteFile(inputc1.Value);

        inputc.Value = img;
        inputc1.Value = img;

        return img;
    }
    #endregion
}