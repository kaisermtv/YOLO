using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_SliderEdit : System.Web.UI.Page
{
    #region declare
    private DataSlider objSlider = new DataSlider();
    private SystemClass objSystemClass = new SystemClass();

    public int itemId = 0;
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

            if (objData["IMG"] != null && objData["IMG"].ToString() != "") htxtimg.Value = "/Images/Slider/" + objData["IMG"].ToString();
        }
    }
    #endregion

    #region Method btnSaver_Click
    protected void btnSaver_Click(object sender, EventArgs e)
    {
        if (this.txtTitle.Text.Trim() == "")
        {
            objSystemClass.addMessage("Bạn chưa nhập tiêu đề.");
            this.txtTitle.Focus();
            return;
        }

        int ret = objSlider.setData(itemId, txtTitle.Text, txtDescribe.Text, txtLink.Text, saveImage(FileUpload, htxtimg));

        if (ret == 0)
        {
            objSystemClass.addMessage("Có lỗi xảy ra! (" + objSlider.Message + ")");
        }
        else
        {
            Response.Redirect("SliderEdit.aspx?id=" + ret);
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
                string strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["SLIDERIMAGE"].ToString());

                string sFileName = "0-" + DateTime.Now.ToString("dd-MM-yyy hh-mm-ss-fffffff-");
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