using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_SliderOne : System.Web.UI.UserControl
{
    #region declare
    public int lengSlider = 0;
    public int index = 1;

    private DataSlider objSlider = new DataSlider();
    public Random rnd = new Random();
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
            DataTable objData = objSlider.getSlider(1);
            if (objData.Rows.Count > 0)
            {
                lengSlider = objData.Rows.Count;

                dtlSliderOne.DataSource = objData.DefaultView;
                dtlSliderOne.DataBind();
                index = 1;
            }
        }
    }
    #endregion


}