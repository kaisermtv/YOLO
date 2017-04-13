using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Menu : System.Web.UI.UserControl
{
    #region declare
    private DataMenu objMenu = new DataMenu();

    public int index = 1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    #region method getData()
    private void getData()
    {
        DataTable objData = objMenu.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();

        index = 1;
    }
    #endregion
}