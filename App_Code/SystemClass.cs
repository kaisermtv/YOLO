using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SystemClass
/// </summary>
public class SystemClass
{
    #region declare value
    private DataRemember objDataRemember = new DataRemember();

    private HttpContext context = HttpContext.Current;
    public String SessionKey = "";

    private DataRow loginAcct;
    private int islogin = 0;
    private int loginGroup = 0;

    public String Message = "";

    #endregion

    public SystemClass()
    {
        try
        {
            SessionKey = HttpContext.Current.Request.Cookies["LoginCookie"].Value;
        }
        catch { }
    }

    #region isLogin
    public bool isLogin(int group = 0)
    {
        if (context.Items["islogin"] != null)
        {
            if ((int)context.Items["islogin"] == 2) return false;

            if (group != 0 && group != (int)context.Items["loginGroup"]) return false;

            return true;
        }

        DataRow objData = objDataRemember.getData(SessionKey);
        if (objData != null)
        {
            DataAccount objAccount = new DataAccount();
            DataRow objDataAcct = objAccount.getAccount((int)objData["USERID"]);

            if (objDataAcct != null)
            {
                if (objDataAcct["ACCT_PASS"].ToString() == objData["PASS"].ToString())
                {
                    context.Items["loginAcct"] = objDataAcct;
                    context.Items["islogin"] = 1;
                    context.Items["loginGroup"] = objData["LGROUP"];

                    context.Items["login"] = (int)objData["USERID"];

                    objDataRemember.updateOnline(SessionKey);

                    //Message = objData["ACCT_PASS"].ToString();
                    return true;
                }

                Logout();
            }
        }

        context.Items["islogin"] = 2;
        return false;

    
        //if (context.Session["Login"] == null)
        //{
        //    if (SessionKey != null && SessionKey != "")
        //    {
                
        //        DataRow objData = objDataRemember.getData(SessionKey);
        //        if(objData != null)
        //        {
        //            context.Session["Login"] = objData["USERID"];
        //            context.Session["LoginPass"] = objData["PASS"];
        //            context.Session["LoginGroup"] = objData["LGROUP"];
        //        }
        //    }
            

        //}

        //if (context.Session["Login"] != null)
        //{
        //    if (group == 0 || group != 0 && context.Session["LoginGroup"] != null && (int)context.Session["LoginGroup"] == group)
        //    {
        //        DataAccount objAccount = new DataAccount();

        //        DataRow objData = objAccount.getAccount((int)context.Session["Login"]);

        //        if(objData != null)
        //        {
        //            if (objData["ACCT_PASS"].ToString() == context.Session["LoginPass"].ToString())
        //            {
        //                context.Items["login"] = (int)context.Session["Login"];
        //                context.Items["loginAcct"] = objData;
        //                context.Items["islogin"] = 1;
        //                context.Items["loginGroup"] = group;

        //                if (SessionKey != null && SessionKey != "") objDataRemember.updateOnline(SessionKey);

        //                Message = objData["ACCT_PASS"].ToString();
        //                return true;
        //            }
                   
        //            Logout();
        //        }

        //    }
        //}

        //context.Items["islogin"] = 2;
        //return false;
    }
    #endregion

    #region getAccount()
    public DataRow getAccount()
    {
        if (isLogin())
        {
            return (DataRow)context.Items["loginAcct"];
        }
        else
        {
            return null;
        }
        
    }
    #endregion

    #region getIDAccount()
    public int getIDAccount()
    {
        if (isLogin())
        {
            return (int)context.Items["login"];
        }
        else
        {
            return 0;
        }

    }
    #endregion

    #region Login
    public bool Login(String acct, String pass, bool remember = false, int group = 0)
    {
        DataAccount objAccount = new DataAccount();

        DataRow objData = objAccount.getAccount(acct);

        if (objData == null)
        {
            Message = "Không tìm thấy tài khoản!";
            return false;
        }

        if (group != 0 && (int)objData["ACCT_GROUP"] != group) // Kiểm tra nhóm admin
        {
            Message = "Quyền hạn của bạn không đủ!";
            return false;
        }

        if (objData["ACCT_PASS"].ToString() != pass)
        {
            Message = "Mật khẩu không đúng!";
            return false;
        }

        //context.Session["Login"] = (int)objData["ACCT_ID"];
        //context.Session["LoginPass"] = pass;
        //context.Session["LoginTime"] = DateTime.Now;
        //context.Session["LoginGroup"] = group;

        HttpCookie loginCookie = new HttpCookie("LoginCookie");
        // Lưu vào Cookie
        String key = objDataRemember.addLogin((int)objData["ACCT_ID"], pass, group, remember);

        loginCookie.Value = key;
        loginCookie.HttpOnly = true;
        //Message = key;

        context.Response.Cookies.Add(loginCookie);

        return true;
    }
    #endregion

    #region Logout
    public void Logout()
    {
        //context.Session["Login"] = null;
        //context.Session["LoginPass"] = null;
        //context.Session["LoginTime"] = null;
        //context.Session["LoginAdmin"] = null;

        objDataRemember.delData(SessionKey);
        context.Response.Cookies["LoginCookie"].Value = "";
        context.Response.Cookies["LoginCookie"].HttpOnly = true;
    }
    #endregion

    #region addMessage(String message,int opt = 0)
    public void addMessage(String message,int opt = 0)
    {
        String txt = "Message" + opt.ToString();

        ArrayList arr;
        if (context.Session[txt] == null)
        {
            arr = new ArrayList();
        } else {
            try{
                arr = (ArrayList)context.Session[txt];
            } catch {
                arr = new ArrayList();
            }
        }

        arr.Add(message);

        context.Session[txt] = arr;
    }
    #endregion

    #region getMessage(int opt = 0)
    public ArrayList getMessage(int opt = 0)
    {
        String txt = "Message" + opt.ToString();

        ArrayList arr;
        if (context.Session[txt] == null)
        {
            arr = new ArrayList();
        }
        else
        {
            arr = (ArrayList)context.Session[txt];
            context.Session[txt] = null;
        }

        return arr;
    }
    #endregion

    #region method CVDate()
    public static DateTime CVDate(String dt)
    {
        try
        {
            return new DateTime(int.Parse(dt.Substring(6, 4)), int.Parse(dt.Substring(3, 2)), int.Parse(dt.Substring(0, 2)));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region method convertToUnSign2
    public static string convertToUnSign2(string s)
    {
        string stFormD = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int ich = 0; ich < stFormD.Length; ich++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[ich]);
            }
        }
        sb = sb.Replace('Đ', 'D');
        sb = sb.Replace('đ', 'd');
        string strReturn = (sb.ToString().Normalize(NormalizationForm.FormD)).Replace("-", " ").Replace(" ", "-").Replace("\"", "").Replace("/", "-").Replace(",", "").Replace(":", "").Replace(".", "").Replace("%", "-").Replace("?", "-");
        return strReturn.Replace("/", "").ToLower();
    }
    #endregion
}