using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsView : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objGroup = new DataNewsGroup();

    public DataRow objData;
    public int itemId = 0;
    public int group = 0;
    public String groupname = "";
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

        group = (int)objData["CatId"];
        danhMuc.itemId = group;

        if (group != 0)
        {
            groupname = objGroup.getNameById(group);
        }
        else
        {
            groupname = "Tin Tức";
        }

        SystemClass.setMenuActive("news", group.ToString());

        Context.Items["strTitle"] = objData["Title"].ToString();


        DataTable tinMoi = objNews.tinLienQuan(itemId, (DateTime)objData["DayPost"], true, 5, group);
        if (tinMoi.Rows.Count > 0)
        {
            dtlTinMoi.DataSource = tinMoi.DefaultView;
            dtlTinMoi.DataBind();
        }

        DataTable tinCu = objNews.tinLienQuan(itemId, (DateTime)objData["DayPost"], false, 5, group);
        if (tinCu.Rows.Count > 0)
        {
            dtlTinCu.DataSource = tinCu.DefaultView;
            dtlTinCu.DataBind();
        }

        this.Title = Context.Items["strTitle"] + " - YOLO, DÁM CHIA SẺ";
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

    #region Method CreateDocument
    public void CreateDocument(bool active = false)
    {
        if (active == false) return;

        string fileName = (@"D:\\" + this.itemId + ".docx");
        //   var doc = DocX.Create(fileName);
        string headlineText = objData["ShortContent"].ToString() + " ";
        string paraOne = "" + ((DateTime)objData["DayPost"]).ToString("dd/MM/yyyy h:mm:ss tt") + "\n" + "\n" +
           StripHTML(objData["Content"].ToString(), true) + " "
            ;
        // Format tiêu đề 
        var headLineFormat = new Formatting();
        headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial");
        headLineFormat.Size = 18D;
        headLineFormat.Position = 12;

        // Format nội dung text
        var paraFormat = new Formatting();
        paraFormat.FontFamily = new System.Drawing.FontFamily("Arial");
        paraFormat.Size = 10;
        paraFormat.Spacing = 1;

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
    #endregion

    #region Method StripHTML
    public static string StripHTML(string HTMLText, bool decode = true)
    {
        Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
        var stripped = reg.Replace(HTMLText, "");
        return decode ? HttpUtility.HtmlDecode(stripped) : stripped;
    }
    #endregion

    #region Method btnDownload_Click
    protected void btnDownload_Click(object sender, ImageClickEventArgs e)
    {
        CreateDocument(true);
    }
    #endregion
}