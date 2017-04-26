using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_News_DanhMuc : System.Web.UI.UserControl
{
    private DataNewsGroup objNewsGroup = new DataNewsGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    private void getData()
    {
        DataTable objData = objNewsGroup.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();
    }
}