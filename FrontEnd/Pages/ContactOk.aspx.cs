using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_ContactOk : System.Web.UI.Page
{
    #region declare
    private DataSetting objSetting = new DataSetting();

    public String msg = "";
    //public String 

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Method  getValue
    public String getValue(String key)
    {
        return objSetting.getValue(key);
    }
    #endregion
}