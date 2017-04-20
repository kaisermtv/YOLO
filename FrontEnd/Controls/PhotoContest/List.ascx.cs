using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_PhotoContest_List : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindData(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            ListContest.DataSource = dt;
            ListContest.DataBind();
        }
        else this.Visible = false;

    }
}