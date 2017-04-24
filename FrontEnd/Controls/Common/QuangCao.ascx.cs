using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_QuangCao : System.Web.UI.UserControl
{
    #region declare 
    private DataSlider objSlider = new DataSlider();
    #endregion 

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DataTable objData = objSlider.getList(1);
            dtlData.DataSource = objData.DefaultView;
            dtlData.DataBind();
        }
    }
    #endregion
}