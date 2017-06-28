using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for CVDateTime
/// </summary>
public class CVDateTime
{
    public static String Rex1 = @"^\d{2}/\d{2}/\d{4}$";
    public static String Rex2 = @"^\d{2}-\d{2}-\d{4}$";


    #region method Parse
    public static DateTime Parse(String txt)
    {
        if (Regex.IsMatch(txt, Rex1))
        {
            txt = txt.Substring(0, 2) + "-" + txt.Substring(3, 2) + "-" + txt.Substring(6, 4);


            return DateTime.Parse(txt);
        }
        else if (Regex.IsMatch(txt, Rex2))
        {
            return DateTime.Parse(txt);
        }
        else
        {

        }

        return new DateTime();
    }
    #endregion
}