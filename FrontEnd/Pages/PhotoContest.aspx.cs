using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_PhotoContest : System.Web.UI.Page
{
    #region declare
    private FacebookApi objFacebook = new FacebookApi();

    private String itemId = "";
    public DataRow objData;

    private static String fields = "comments,name,id";
    private static string key_db = "Facebook_Token";
    public List<comments> lComment = new List<comments>();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.itemId = getParam("id");

        if (itemId != null && itemId == "") Response.Redirect("/");

        objData = objFacebook.getDataById(itemId);

        if (objData == null) Response.Redirect("/");


        //FacebookApi FbApi = new FacebookApi();
        FbPhotoAlbum FbPhotoAlbum = new FbPhotoAlbum();
        DataTable FbTable = FbPhotoAlbum.getData(5);
        dtlData.DataSource = FbTable.DefaultView;
        dtlData.DataBind();

        try { 
        string url = @"https://graph.facebook.com/" + objData["id"].ToString().Trim() + "?limit= " + 10 + "&fields=" + fields + "&access_token=" + new DataSetting().getValue(key_db) + ""; // mặc định là lấy ảnh của album có id =  // speci
        var json = objFacebook.getJsonString(3,10,url);
        lComment = objFacebook.parseJsonToPhotoPostsComments(json);
            }
        catch
        {
            return;
        }

    }
    #endregion

    //protected string GetSubStringNice(string str, int len)
    //{
    //    string kq = "";
    //    try
    //    {
    //        str = str.Trim();
    //        string newsStrDecode = HttpUtility.HtmlDecode(str);
    //        if (newsStrDecode != "")
    //        {
    //            if (newsStrDecode.Length > len)
    //            {
    //                newsStrDecode = newsStrDecode.Substring(0, len);
    //                string[] strNice = newsStrDecode.Split(' ');
    //                if (str.EndsWith(" ") == true)
    //                {
    //                    newsStrDecode = newsStrDecode.Substring(0, len).Trim() + "...";
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < (strNice.Length - 1); i++)
    //                    {
    //                        kq += strNice[i] + " ";
    //                    }
    //                    kq = kq.Trim() + "...";
    //                }
    //                if (!str.Contains(" ") && newsStrDecode.Length > len)
    //                {
    //                    newsStrDecode = newsStrDecode.Substring(0, len).Trim() + "...";
    //                }
    //            }
    //            else
    //            {
    //                kq = newsStrDecode;
    //            }
    //        }
    //    }
    //    catch (Exception)
    //    {

    //        kq = "";
    //    }
    //    return kq;

    //}
    

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