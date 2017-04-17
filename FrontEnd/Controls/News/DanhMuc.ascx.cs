using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_News_DanhMuc : System.Web.UI.UserControl
{
    private DataMenu objMenu = new DataMenu();
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    private void getData()
    {
        DataTable objData = objMenu.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();
    }
}