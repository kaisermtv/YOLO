using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Master_Site : System.Web.UI.MasterPage
{
    #region declare
    private DataSetting objSetting = new DataSetting();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemClass objSystemClass = new SystemClass();
        objSystemClass.isLogin();
        
    }

    #region Method  getValue
    public String getValue(String key)
    {
        return objSetting.getValue(key);
    }
    #endregion
}
