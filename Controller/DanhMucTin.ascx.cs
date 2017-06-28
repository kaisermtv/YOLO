using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_DanhMucTin : System.Web.UI.UserControl
{
    #region declare
    public int itemId = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataNewsGroup objNewsGroup = new DataNewsGroup();

        DataTable objData = objNewsGroup.getList(1);

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();
    }
    #endregion
}