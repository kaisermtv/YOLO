using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Menu : System.Web.UI.Page
{
    #region declare
    private DataMenu objMenu = new DataMenu();

    public int index = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!Page.IsPostBack)
        {

            getData();
        }


    }
    #endregion

    #region method getData()
    private void getData()
    {
        DataTable objData = objMenu.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {

    }
    #endregion
}