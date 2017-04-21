using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_News_Detail : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();

    public DataRow objData;
    public int itemId = 0;

    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(getParam("id"));
        }
        catch { }

        if (itemId == 0) Response.Redirect("tin-tuc");

        objData = objNews.getData(itemId);

        if (objData == null) Response.Redirect("tin-tuc");


        DataTable tinMoi = objNews.tinLienQuan(itemId, (DateTime)objData["DayPost"], true, 5);
        dtlTinMoi.DataSource = tinMoi.DefaultView;
        dtlTinMoi.DataBind();

        DataTable tinCu = objNews.tinLienQuan(itemId, (DateTime)objData["DayPost"], false, 5);
        dtlTinCu.DataSource = tinCu.DefaultView;
        dtlTinCu.DataBind();

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
 


    public void CreateDocument(bool active = false)
    {
        if (active == false) return;

        string fileName = Server.MapPath("/docs/document" + this.itemId + ".docx");
     //   var doc = DocX.Create(fileName);
        string headlineText = objData["ShortContent"].ToString() + " ";
        string paraOne = "" +
            objData["Content"].ToString() + " "
            ;
        // Format tiêu đề 
        var headLineFormat = new Formatting();
        headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
        headLineFormat.Size = 18D;
        headLineFormat.Position = 12;

        // Format nội dung text
        var paraFormat = new Formatting();
        paraFormat.FontFamily = new System.Drawing.FontFamily("Time new roman");
        paraFormat.Size = 10D;

        // Tạo tệp tin 
        var doc = DocX.Create(fileName);

        // Đưa nội dung vào file
        doc.InsertParagraph(headlineText, false, headLineFormat);
        doc.InsertParagraph(paraOne, false, paraFormat);

        // Save
        doc.Save();

        // Mở file
        Process.Start("WINWORD.EXE", fileName);
    }
    protected void btnDownload_Click(object sender, ImageClickEventArgs e)
    {
        CreateDocument(true);
    }
}