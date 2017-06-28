using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_Paging : System.Web.UI.UserControl
{
    #region declare
    public int MaxPage = 1;
    public int iPage = 1;
    private string url = "";
    private string url1 = "";

    public string pageName = "page";
    #endregion


    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        


    }
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        if (MaxPage < 1) MaxPage = 1;
        if (iPage < 1) iPage = 1;
        if (iPage > MaxPage) iPage = MaxPage;

        ArrayList objData = new ArrayList();


        if(iPage > 1 )
        {
            objData.Add("<");
            objData.Add("1");
        }

        int x = iPage - 4;
        if (x < 2) x = 2;
        for (int i = x; i < iPage; i++)
        {
            objData.Add(i.ToString());
        }

        objData.Add(iPage.ToString());

        for (int i = iPage + 1; i < iPage + 4 && i < MaxPage; i++)
        {
            objData.Add(i.ToString());
        }

        if (iPage < MaxPage)
        {
            objData.Add(MaxPage.ToString());
            objData.Add(">");
        }

        dtlData.DataSource = objData;
        dtlData.DataBind();
    }
    #endregion

    #region Method GetLink
    public string GetLink(string input)
    {
        if (input == iPage.ToString()) return "";

        if(url == "")
        {
            string buf = "";

            foreach (string key in Request.QueryString)
            {
                if (key == pageName) continue;

                if (buf != "") buf += "&";
                buf += HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(Request.QueryString[key]);
            }

            if (buf != "")
            {
                url = Request.Path + "?" + buf ;
                url1 = url + "&" + pageName + "=";
            }
            else
            {
                url = Request.Path;
                url1 = url + "?" + pageName + "=";
            }
        }
        string ret = "";

        if (input == "1") ret = url;
        else if (input == "<")
        {
            if (iPage - 1 == 1) ret = url;
            else ret = url1 + (iPage - 1);
        }
        else if (input == ">") ret = url1 + (iPage + 1);
        else ret = url1 + input;

        return "href=\"" + ret + "\"";
    }
    #endregion

}