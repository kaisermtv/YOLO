using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_SliderList : System.Web.UI.Page
{
    #region declare
    private DataSlider objSlider = new DataSlider();

    public int index = 0;
    #endregion


    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH SLIDER";

        if (!Page.IsPostBack)
        {
            getData();
        }
    }
    #endregion

    #region method getData()
    private void getData()
    {
        DataTable objData = objSlider.getList();

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpData.MaxPages = 1000;
        cpData.PageSize = 15;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
        index = 1;
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int id;
        try
        {
            id = int.Parse(idDel.Value);
        }
        catch
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        if (id != 0)
        {
            objSlider.delData(id);

            getData();
        }
        else
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }
    }
    #endregion
}