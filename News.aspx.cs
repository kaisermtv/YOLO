using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();

    public int itemId = 0;
    public String groupname = "";
    public String sapXep = "DESC";

    public int numItem = 10;
    public int maxitem = 0;
    public int page = 1;
    public int maxPage = 1;

    public DataRow topData;

    public ArrayList pager = new ArrayList();
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(getParam("id"));
        }
        catch { }

        danhMuc.itemId = itemId;

        DataNewsGroup objGroup = new DataNewsGroup();
        if (itemId != 0)
        {
            groupname = objGroup.getNameById(itemId);
        }
        else
        {
            groupname = "Tin Tức";
        }

        Context.Items["strTitle"] = groupname;

        SystemClass.setMenuActive("news", itemId.ToString());

        try
        {
            this.sapXep = (getParam("sapxep") != "1") ? "DESC" : "ASC";
        }
        catch { }

        try
        {
            this.page = int.Parse(Request["page"].ToString());
        }
        catch { }



        if (!Page.IsPostBack)
        {

            #region phan trang
            maxitem = objNews.getDataCount(itemId);
            maxPage = maxitem / numItem;
            if (maxitem % numItem > 0 || maxPage == 0) maxPage++;
            if (page > maxPage) page = maxPage;
            if (page < 1) page = 1;

            pageId.MaxPage = maxPage;
            pageId.iPage = page;

            
            #endregion

            DataTable objData = objNews.getDataTop(numItem, itemId, page, false, "", sapXep);
            if (objData.Rows.Count > 0)
            {
                //DataRow drNew = objData.Rows[0].ItemArray;

                DataTable Destination = objData.Clone();
                Destination.ImportRow(objData.Rows[0]);

                dtlTop.DataSource = Destination.DefaultView;
                dtlTop.DataBind();

                //topData = Destination.Rows[0];

                objData.Rows.Remove(objData.Rows[0]);
            }

            dtlNews.DataSource = objData.DefaultView;
            dtlNews.DataBind();
        }

    }
    #endregion



    #region Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        //DataTable objData1 = objNews.getDataTop(1, itemId, 1, false, "", sapXep);

        //dtlTop.DataSource = objData1.DefaultView;
        //dtlTop.DataBind();
    }
    #endregion

    #region Method getLink
    public string getLink(int type = 0)
    {
        string url = "";

        if (itemId != 0)
        {
            url = "?id=" + itemId; 
        }
        if (type != 0)
        {
            if (url != "") url += "&";
            else url += "?";
            url += "sapxep=1";
        }

        return Request.Path + url;
    }
    #endregion


    #region Method getParam
    private String getParam(String key)
    {
        try
        {
            if (RouteData.Values[key] != null) return RouteData.Values[key].ToString();
            if (Request[key] != null) return Request[key].ToString();
        }
        catch { }

        return null;
    }
    #endregion
}