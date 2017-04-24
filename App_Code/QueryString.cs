using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QueryString
/// </summary>
public static class QueryString
{

    #region phan bo tro
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu Integer
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>Số kiểu Integer, nếu lỗi return int.MinValue</returns>
    public static int Object2Integer(object value)
    {
        if (null == value) return 0;
        try
        {
            return Convert.ToInt32(value);
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu Long
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>Số kiểu Long, nếu lỗi return long.MinValue</returns>
    public static long Object2Long(object value)
    {
        if (null == value) return 0;
        try
        {
            return Convert.ToInt64(value);
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu Double
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>Số kiểu Double, nếu lỗi return double.NaN</returns>
    public static double Object2Double(object value)
    {
        if (null == value) return 0;
        try
        {
            return Convert.ToDouble(value);
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu float
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>Số kiểu float, nếu lỗi return float.NaN</returns>
    public static float Object2Float(object value)
    {
        if (null == value) return 0;
        try
        {
            return float.Parse(value.ToString());
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu boolean
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>giá trị kiểu boolean, nếu lỗi return false</returns>
    public static bool Object2Boolean(object value)
    {
        if (null == value) return false;
        try
        {
            return Convert.ToBoolean(value);
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 giá trị sang kiểu DateTime
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <returns>Số kiểu DateTime, nếu lỗi return DateTime.MinValue</returns>
    public static DateTime Object2DateTime(object value)
    {
        if (null == value) return DateTime.MinValue;
        try
        {
            return Convert.ToDateTime(value);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }
    /// <summary>
    /// Chuyển đổi 1 xâu ngày tháng dạng dd/MM/yyyy sang ngày tháng
    /// </summary>
    /// <param name="value">Xâu nhập</param>
    /// <returns>Trả về kiểu DateTime cua ngày cần chuyển đổi (Nếu lỗi thì trả về DateTime.MinValue)</returns>
    public static DateTime String2Date(string value)
    {
        string temp = value;

        string date = temp.Substring(0, temp.IndexOf("/"));
        temp = temp.Substring(temp.IndexOf("/") + 1);
        string month = temp.Substring(0, temp.IndexOf("/"));
        string year = temp.Substring(temp.IndexOf("/") + 1);

        string[] months = new string[] { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };
        try
        {
            return Convert.ToDateTime(date + " " + months[Convert.ToInt32(month) - 1] + " " + year);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }
    /// <summary>
    /// Lấy 1 xâu ngẫu nhiên
    /// </summary>
    /// <param name="length">Số lượng ký tự</param>
    /// <returns>Xâu ngẫu nhiên</returns>
    public static string GetRamdomString(int length)
    {
        string temp = "";
        string[] myAlphabet = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        Random Rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            temp += myAlphabet[Rnd.Next(0, myAlphabet.Length - 1)];
        }
        return temp;
    }

    #region Chuyen doi xau dang unicode co dau sang dang khong dau
    const string UniChars = "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";
    const string KoDauChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

    public static string UnicodeToKoDau(string s)
    {
        string retVal = String.Empty;
        for (int i = 0; i < s.Length; i++)
        {
            int pos = UniChars.IndexOf(s[i].ToString(), StringComparison.Ordinal);
            if (pos >= 0)
                retVal += KoDauChars[pos];
            else
                retVal += s[i];
        }
        return retVal.ToLower();
    }

    public static string UnicodeToKoDauAndGach(string s)
    {
        const string strChar = "abcdefghijklmnopqrstxyzuvxw0123456789- ";
        s = UnicodeToKoDau(s.ToLower().Trim());
        string sReturn = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (strChar.IndexOf(s[i]) > -1)
            {
                if (s[i] != ' ')
                    sReturn += s[i];
                else if (i > 0 && s[i - 1] != ' ' && s[i - 1] != '-')
                    sReturn += "-";
            }
        }
        return sReturn.Replace("--", "-").ToLower();
    }
    #endregion
    #endregion

    public static string CategoryFullUrl
    {
        get
        {
            return HttpContext.Current.Request.QueryString["url"] ?? string.Empty;
        }
    }

    public static int CategoryID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["cat_id"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["cat_id"]);
        }
    }
    public static int Pack
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["pack"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["pack"]);
        }
    }
    public static int CourseId
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["courseid"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["courseid"]);
        }
    }
    public static int FlashCardId
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["flashcardid"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["flashcardid"]);
        }
    }
    public static string ZoneIds
    {
        get
        {
            return HttpContext.Current.Request.QueryString["zoneids"] ?? string.Empty;
        }
    }

    public static int ParentCategory
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["parent_id"])) return 0;
            return Object2Integer(HttpContext.Current.Request.QueryString["parent_id"]);
        }
        #region
        //get
        //{
        //    return GetParentCategoryIdByCategoryId(CategoryID);
        //}
        #endregion
    }

    public static string Cat_ParentUrl
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["purl"])) return "";

            return HttpContext.Current.Request.QueryString["purl"];
        }
    }
    public static string OrderBy
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["OrderBy"])) return "";

            return HttpContext.Current.Request.QueryString["OrderBy"];
        }
    }
    public static int Level
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["Level"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["Level"]);
        }
    }
    public static int PageIndex
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["PageIndex"])) return 1;

            return Object2Integer(HttpContext.Current.Request.QueryString["PageIndex"]);
        }
    }
    public static int Pi
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["pi"])) return 1;

            return Object2Integer(HttpContext.Current.Request.QueryString["pi"]);
        }
    }
    public static int PageSize
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["PageSize"])) return 1;

            return Object2Integer(HttpContext.Current.Request.QueryString["PageSize"]) > 200
                       ? 200
                       : Object2Integer(HttpContext.Current.Request.QueryString["PageSize"]);
        }
    }

    public static int AlbumID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["albumid"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["albumid"]);
        }
    }
    public static int Id
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["id"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["id"]);
        }
    }
    public static int VideoID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["videoid"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["videoid"]);
        }
    }

    public static int VoteItemID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["VoteItemID"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["VoteItemID"]);
        }
    }

    public static int InterviewID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["InterviewID"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["InterviewID"]);
        }
    }

    public static int VoteID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["VoteID"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["VoteID"]);
        }
    }
    public static long NewsID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["NewsID"])) return 0;

            return Object2Long(HttpContext.Current.Request.QueryString["NewsID"]);
        }
    }
    public static long ParentID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ParentID"])) return 0;

            return Object2Long(HttpContext.Current.Request.QueryString["ParentID"]);
        }
    }
    public static string GetDay
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["getday"])) return "";

            return HttpContext.Current.Request.QueryString["getday"];
        }
    }

    public static string GetMonth
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["getmonth"])) return "";

            return HttpContext.Current.Request.QueryString["getmonth"];
        }
    }

    public static string GetYear
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["getyear"])) return "";

            return HttpContext.Current.Request.QueryString["getyear"];
        }
    }

    public static int ViewByDate_Day
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["p0"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["p0"]);
        }
    }

    public static int ViewByDate_Month
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["p1"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["p1"]);
        }
    }

    public static int ViewByDate_Year
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["p2"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["p2"]);
        }
    }

    public static string ViewByDate
    {
        get
        {
            return ViewByDate_Day + "_" + ViewByDate_Month + "_" + ViewByDate_Year;
        }
    }
    public static int ThreadID
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ThreadID"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["ThreadID"]);
        }
    }

    public static string HomeUrl
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["homeurl"])) return "";

            return HttpContext.Current.Request.QueryString["homeurl"];
        }
    }
    public static string KeyWords
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params["keywords"])) return "";

            return HttpContext.Current.Request.Params["keywords"];
        }
    }
    public static string Type
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params["type"])) return "";

            return HttpContext.Current.Request.Params["type"];
        }
    }
    public static string KeySearch
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params["keysearch"])) return "";

            return HttpContext.Current.Request.Params["keysearch"];
        }
    }
    public static string Action
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Params["act"])) return "";

            return HttpContext.Current.Request.Params["act"];
        }
    }
    public static string Title
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["title"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["title"].ToLower();
        }
    }
    public static string Sapo
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["sapo"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["sapo"].ToLower();
        }
    }
    public static string Kana
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["kana"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["kana"].ToLower();
        }
    }
    public static string Word
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["word"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["word"].ToLower();
        }
    }
    public static string Romaji
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["romaji"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["romaji"].ToLower();
        }
    }
    public static string Meaning
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["meaning"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["meaning"].ToLower();
        }
    }

    public static string Avatar
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["avatar"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["avatar"].ToLower();
        }
    }
    public static string Sound
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["sound"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["sound"].ToLower();
        }
    }
    public static string NewsUrl
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["newsUrl"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["newsUrl"].ToLower();
        }
    }
    public static string CatParentUrl
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["catParentUrl"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["catParentUrl"].ToLower();
        }
    }
    public static string CatUrl
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["catUrl"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["catUrl"].ToLower();
        }
    }
    //Video
    public static int VideoId
    {
        get
        {
            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["VideoID"])) return 0;

            return Object2Integer(HttpContext.Current.Request.QueryString["VideoID"]);
        }
    }

    public static string VideoZoneUrl
    {
        get
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["zoneurl"])
                       ? ""
                       : HttpContext.Current.Request.QueryString["zoneurl"].ToLower();
        }
    }

    public static bool IsRenderCache
    {
        get
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["isCache"]) && HttpContext.Current.Request.QueryString["isCache"] == "1";
        }
    }
    public static T ChangeType<T>(object obj)
    {
        if (null == obj)
            return default(T);

        try
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
        catch
        {
            return default(T);
        }
    }

    public static T GetParam<T>(this HttpRequest request, string paramName, T defaultValue = default(T))
    {
        if (request.RequestType == "GET")
        {
            return request.QueryString[paramName] == null
                ? defaultValue
                : ChangeType<T>(request.QueryString[paramName]);
        }
        return request.Params[paramName] == null
            ? defaultValue
            : ChangeType<T>(request.Params[paramName]);
    }
}