using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin;

public partial class FrontEnd_Ajax_PhotoContest_LoadList : System.Web.UI.Page
{

    protected int PageSize = 12;
    private const int ThumbWidth = 268;
    private const int ThumbHeight = 178;
    protected int ZoneId = 0;
    protected string Keyword = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        var pageindex = QueryString.PageIndex;
        PageSize = QueryString.PageSize;
        ZoneId = QueryString.CategoryID;
        Keyword = QueryString.KeyWords;
        var type = QueryString.Type ?? "moi-nhat";
        
        DataTable FbTable = new DataTable();
        FacebookApi FbApi = new FacebookApi();
        FbPhotoAlbum FbPhotoAlbum = new FbPhotoAlbum();
        FbTable = FbPhotoAlbum.getData(20);

        if (FbTable != null && FbTable.Rows.Count > 0)
        {
            List.BindData(FbTable);
        }
    }
}