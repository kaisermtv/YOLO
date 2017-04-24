using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Novacode;

public partial class FrontEnd_Ajax_News_LoadList : System.Web.UI.Page
{
    private DataNews objNews = new DataNews();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();

    public int Id = 0;
    public String groupname = "";
    public String OrderBy = "DESC"  /* "DESC" : "ASC"*/;

    public int maxPage = 1;
    public int maxitem = 0;

    protected int PageSize = 10;
    protected int PageIndex = 1;
    protected int ZoneId = 0;
    protected string Keyword = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        PageIndex = QueryString.PageIndex;
        Id = QueryString.Id;
        OrderBy = QueryString.OrderBy;
        Keyword = QueryString.KeyWords;

        DataTable dt = objNews.getDataTop(PageSize, Id, PageIndex, false, Keyword, OrderBy);
        if (dt != null && dt.Rows.Count > 0)
        {
            DanhSachTin.BindData(dt);
        }
    }
}