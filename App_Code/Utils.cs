using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetSubStringNice(string str, int len)
    {
        string kq = "";
        try
        {
            str = str.Trim();
            string newsStrDecode = HttpUtility.HtmlDecode(str);
            if (newsStrDecode != "")
            {
                if (newsStrDecode.Length > len)
                {
                    newsStrDecode = newsStrDecode.Substring(0, len);
                    string[] strNice = newsStrDecode.Split(' ');
                    if (str.EndsWith(" ") == true)
                    {
                        newsStrDecode = newsStrDecode.Substring(0, len).Trim() + "...";
                    }
                    else
                    {
                        for (int i = 0; i < (strNice.Length - 1); i++)
                        {
                            kq += strNice[i] + " ";
                        }
                        kq = kq.Trim() + "...";
                    }
                }
                else
                {
                    kq = newsStrDecode;
                }
            }
        }
        catch (Exception)
        {

            kq = "";
        }
        return kq;
    }

}