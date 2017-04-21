using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Contact : System.Web.UI.Page
{
    #region declare 
    private DataSetting objSetting = new DataSetting();

    public String msg = "";
    //public String 

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.RequestType == "POST")
        {
            try
            {
                if (Request.Form["name"] == "")
                {
                    msg = "Bạn cần nhập tên đầy đủ";
                    return;
                }

                //if (Request.Form["email"] == "")
                //{
                //    msg = "Bạn cần nhập tên đầy đủ";
                //    return;
                //}

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
                    Response.Redirect("/ContactOk");
                }
                else
                {
                    msg = "Có lỗi xảy ra! Xin thử lại.";
                }
            }
            catch { }
            



        }
    }

    #region Method  getValue
    public String getValue(String key)
    {
        return objSetting.getValue(key);
    }
    #endregion
}