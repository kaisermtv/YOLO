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

public partial class CatView : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objGroup = new DataNewsGroup();
    private DataNewsComment objComment = new DataNewsComment();

    public DataRow objData;
    public int itemId = 0;
    public int group = 0;
    public String groupname = "";


    //public int page = 1;
    //public int maxItem = 0;
    //public int MaxPage = 1;

    public string message = "";
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(getParam("id"));
        }
        catch { }

        if (itemId == 0) Response.Redirect("Category.aspx");

        objData = objNews.getData(itemId);

        if (objData == null) Response.Redirect("Category.aspx");

        group = (int)objData["CatId"];
        //danhMuc.itemId = group;

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

        if(Request.RequestType == "POST")
        {
            if (Request.Form["name"].Trim() == "")
            {
                message = "Bạn cần điền tên!";
            }
            else if (Request.Form["subject"].Trim() == "")
            {
                message = "Bạn cần điền tiêu đề!";
            }
            else if (Request.Form["message"].Trim() == "")
            {
                message = "Bạn cần điền nội dung!";
            }
            else 
            {
                

                objComment["NewsId"] = itemId;
                objComment["Subject"] = Request.Form["subject"];
                objComment["Content"] = Request.Form["message"];
                objComment["Name"] = Request.Form["name"];
                objComment["Email"] = Request.Form["email"];
                objComment["Phone"] = Request.Form["mobile"];
                objComment["CityID"] = Request.Form["CityID"];
                
                objComment["NSTATUS"] = 0;

                int ret = (int)objComment.setData();
                if (ret == 0)
                {
                    message = "Có lỗi xảy ra!";
                }

            }

            
        }

        //maxItem = objComment.getDataCount(itemId);

        //MaxPage = maxItem / 8;
        //if (maxItem % 12 > 0) MaxPage += 1;
        //if (maxItem < 1) maxItem = 1;

        //pageId.iPage = page;
        //pageId.MaxPage = MaxPage;

        //DataTable objData1 = objComment.getDataTop(itemId,8,page,"DESC");
        //if(objData1 != null)
        //{
        //    dtlComment.DataSource = objData1.DefaultView;
        //    dtlComment.DataBind();

        //}

        



        /*
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
        //*/
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