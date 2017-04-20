using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Seach : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();

    public String seach = "";

    public int numItem = 10;
    public int maxitem = 0;
    public int page = 1;
    public int maxPage = 1;

    public ArrayList pager = new ArrayList();
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.page = int.Parse(Request["page"].ToString());
        }
        catch { }

        try
        {
            seach = Request["Seach"].ToString();
        }
        catch { }

        if (seach != "")
        {
            #region phan trang
            maxitem = objNews.getDataCount(0, false, seach);
            maxPage = maxitem / numItem;
            if (maxitem % numItem > 0 || maxPage == 0) maxPage++;
            if (page > maxPage) page = maxPage;
            if (page < 1) page = 1;

            String link = "";
            if (seach != "") link = "&Seach=" + seach;

            if (page - 1 >= 1) pager.Add(new PageData("Trước", "?page=" + (page - 1) + link));
            if (page != 1) pager.Add(new PageData("1", "?page=1" + link));

            int a = page - 5;
            if (a < 2) a = 2;
            for (int i = a; i < page; i++)
            {
                pager.Add(new PageData(i.ToString(), "?page=" + i + link));
            }

            pager.Add(new PageData(page.ToString(), "#", true));

            a = page + 5;
            if (a > maxPage) a = maxPage;
            for (int i = page + 1; i < a; i++)
            {
                pager.Add(new PageData(i.ToString(), "?page=" + i + link));
            }

            if (page != maxPage) pager.Add(new PageData(maxPage.ToString(), "?page=" + maxPage + link));
            if (page + 1 <= maxPage) pager.Add(new PageData("Sau", "?page=" + (page + 1) + link));
            #endregion
            ddlpager.DataSource = pager;
            ddlpager.DataBind();

            DataTable objData = objNews.getDataTop(numItem, 0, page, false, seach);

            dtlNews.DataSource = objData.DefaultView;
            dtlNews.DataBind();
        }
    }
    #endregion


    #region Method getParam
    private String getParam(String key)
    {
        try
        {
            if (RouteData.Values[key] != null) return RouteData.Values[key].ToString();
            if(Request[key] != null) return Request[key].ToString();
        }
        catch {  }

        return null;
    }
    #endregion
    
}