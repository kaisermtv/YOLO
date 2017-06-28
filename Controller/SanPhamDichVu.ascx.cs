using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_SanPhamDichVu : System.Web.UI.UserControl
{
    #region declare
    private DataSlider objSlider = new DataSlider();
    public int lengNews = 0;
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable objData = objSlider.getSlider(3);
            if (objData.Rows.Count > 0)
            {
                lengNews = objData.Rows.Count;

                dtlData.DataSource = objData.DefaultView;
                dtlData.DataBind();

            }
        }
    }
    #endregion
}