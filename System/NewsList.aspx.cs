using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_NewsList : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();

    public int index = 1;
    public int itemId = 0;
    public string txtSearch = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH TIN TỨC, BÀI VIẾT";

        try
        {
            this.itemId = int.Parse(Request["Group"].ToString());
        }
        catch { }

        try
        {
            this.txtSearch = Request["Search"].ToString();
        }
        catch { }

        if (Request.RequestType == "POST")
        {
            SystemClass objSystemClass = new SystemClass();
            try
            {
                int idDel = int.Parse(Request.Form["idDel"]);

                objNews.delData(idDel);

                objSystemClass.addMessage("Xóa bài viết thành công!");
            }
            catch
            {
                objSystemClass.addMessage("Có lỗi xảy ra!");
            }
        }


        if (!Page.IsPostBack)
        {
            DataNewsGroup objGroup = new DataNewsGroup();
            ddlGroup.DataSource = objGroup.getDataToCombobox("Tất cả");
            ddlGroup.DataBind();
        }
        
    }
    #endregion

    #region Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objNews.getList(itemId, txtSearch);

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