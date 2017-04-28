using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Menu : System.Web.UI.UserControl
{
    #region declare
    private DataMenu objMenu = new DataMenu();

    public int index = 1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    #region method getData()
    private void getData()
    {
        DataTable objData = objMenu.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region getActive(string link)
    public string getActive(string link)
    {
        link = link.ToLower();

        if (link == "/" || link == "/home" || link == "/trang-chu" || Regex.IsMatch(link, "^/home/.*") || Regex.IsMatch(link, "^/trang-chu/.*"))
        {
            if((string)Context.Items["PageType"] == "home")
            {
                return "class=\"active\"";
            }
            return "";
        }


        if (link == "/tin-tuc" || link == "/news" || link == "/tin-tuc/" || link == "/news/")
        {
            if ((string)Context.Items["PageType"] == "news" && (string)Context.Items["PageID"] == "")
            {
                return "class=\"active\"";
            }
            return "";
        }

        if (Regex.IsMatch(link, "^/tin-tuc/\\?.*") || Regex.IsMatch(link, "^/news/\\?.*"))
        {
            if ((string)Context.Items["PageType"] != "news") return "";

            Match m = Regex.Match(link, "id=[\\d]+", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                if ((string)Context.Items["PageID"] == m.Value.Substring(3)) return "class=\"active\"";
            }

            return "";
        }

        if (Regex.IsMatch(link, "^/[^/^\\?]*-cat[\\d]+$"))
        {
            if ((string)Context.Items["PageType"] != "news") return "";

            Match m = Regex.Match(link, "-cat[\\d]+$", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                if ((string)Context.Items["PageID"] == m.Value.Substring(4)) return "class=\"active\"";
            }

            return "";
        }

        if (link == "/contact" || link == "/lien-he" || link == "/contact/" || link == "/lien-he/")
        {
            if ((string)Context.Items["PageType"] == "contact" && (string)Context.Items["PageID"] == "")
            {
                return "class=\"active\"";
            }
            return "";
        }


        if (Regex.IsMatch(link, "^/[^/^\\?]*-v[\\d]+$"))
        {
            if ((string)Context.Items["PageType"] != "view") return "";

            Match m = Regex.Match(link, "-v[\\d]+$", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                if ((string)Context.Items["PageID"] == m.Value.Substring(2)) return "class=\"active\"";
            }

            return "";
        }

        if (Regex.IsMatch(link, "^/[^/^\\?]*-p[\\d]+$"))
        {
            if ((string)Context.Items["PageType"] != "photoview") return "";

            Match m = Regex.Match(link, "-p[\\d]+$", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                if ((string)Context.Items["PageID"] == m.Value.Substring(2)) return "class=\"active\"";
            }

            return "";
        }

        if (link == "/cuoc-thi-ah-dep" || link == "/cuoc-thi-ah-dep/")
        {
            if ((string)Context.Items["PageType"] == "photo" && (string)Context.Items["PageID"] == "")
            {
                return "class=\"active\"";
            }
            return "";
        }

        return "";
    }
    #endregion
}