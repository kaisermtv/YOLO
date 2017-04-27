using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Paging : System.Web.UI.UserControl
{

    public ArrayList pager = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        //PageIndex = QueryString.PageIndex;
        //Id = QueryString.Id;
        //OrderBy = QueryString.OrderBy;
        //Keyword = QueryString.KeyWords;


        //if (page != maxPage) pager.Add(new PageData(maxPage.ToString(), "?page=" + maxPage + link));
        //if (page + 1 <= maxPage) pager.Add(new PageData("Sau", "?page=" + (page + 1) + link));

        //DataTable dt = objNews.getDataTop(PageSize, Id, PageIndex, false, Keyword, OrderBy);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    Pager.DataSource = dt;
        //    Pager.DataBind();
        //}
    }
}