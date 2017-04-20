using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_PhotoContest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

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
}