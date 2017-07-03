using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    #region declare
    private DataSetting objSetting = new DataSetting();

    public String msg = "";
    //public String 

    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemClass.setMenuActive("contact");

        if (Request.RequestType == "POST")
        {
            try
            {
                if (Request.Form["name"] == "")
                {
                    msg = "Bạn cần nhập tên đầy đủ";
                    return;
                }

                if (Request.Form["title"] == "")
                {
                    msg = "Bạn cần nhập tiêu đề";
                    return;
                }

                if (Request.Form["noidung"] == "")
                {
                    msg = "Bạn cần nhập nội dung";
                    return;
                }
                //SystemClass objSystem = new SystemClass();
                DataContact objContact = new DataContact();
                if (objContact.addData(Request.Form["name"], Request.Form["email"], Request.Form["title"], Request.Form["noidung"]) != 0)
                {
                    Response.Redirect("/");
                }
                else
                {
                    msg = "Có lỗi xảy ra! Xin thử lại.";
                }
            }
            catch { }

        }

        this.Title = "LIÊN HỆ - YOLO, DÁM CHIA SẺ";
    }
    #endregion

    #region Method  getValue
    public String getValue(String key)
    {
        return objSetting.getValue(key);
    }
    #endregion
}