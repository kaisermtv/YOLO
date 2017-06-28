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
    public int type = 1;
    #endregion


    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH SLIDER";

        try
        {
            this.type = int.Parse(Request["type"].ToString());
        }
        catch { }
        if (type == 0) type = 1;

        if (Request.RequestType == "POST")
        {
            SystemClass objSystemClass = new SystemClass();
            try
            {
                int idDel = int.Parse(Request.Form["idDel"]);

                objSlider.delData(idDel);

                objSystemClass.addMessage("Xóa slider thành công!");
            }
            catch
            {
                objSystemClass.addMessage("Có lỗi xảy ra!");
            }
        }

        getData();
    }
    #endregion

    #region method getData()
    private void getData()
    {
        DataTable objData = objSlider.getList(type);

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

}