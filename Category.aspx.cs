using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
{
    #region declare 
    private DataNews objNews = new DataNews();
    private DataNewsGroup objGroup = new DataNewsGroup();

    public int groupNews = 9;
    public string title = "";
    public int page = 1;
    public int maxItem = 0;
    public int MaxPage = 1;

    public int maxPageItem = 12;
    #endregion 

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    groupNews = int.Parse(Request["id"].ToString());
        //}
        //catch
        //{
        //    groupNews = 0;
        //}

        try
        {
            page = int.Parse(Request["page"].ToString());
        }
        catch{}

        if(groupNews != 0)
        {
            title = objGroup.getNameById(groupNews);
            if (title == null) Response.Redirect("/");
        }
        else
        {
            title = "Tất cả";
        }

        title = "Trải nghiệm sản phẩm, dịch vụ";

        maxItem = objNews.getDataCount(groupNews,false,"",true);

        MaxPage = maxItem / 12;
        if (maxItem % 12 > 0) MaxPage += 1;
        if (maxItem < 1) maxItem = 1;

        pageId.iPage = page;
        pageId.MaxPage = MaxPage;

        DataTable objData = objNews.getDataTop(12, groupNews,page,false,"","DESC",true);
        if(objData != null)
        {
            dtlData.DataSource = objData.DefaultView;
            dtlData.DataBind();

        }

    }
    #endregion

    #region Method getItemData
    public DataTable getItemData(int id,int page = 1)
    {
        try
        {
            DataTable objData = objNews.getDataTop(maxPageItem, id, page, false, "", "DESC", true);


            return objData;
        }
        catch
        {
            return new DataTable();
        }
    }
    #endregion
}