using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

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

    #region contractor
    public SystemClass()
    {
        try
        {
            SessionKey = HttpContext.Current.Request.Cookies["LoginCookie"].Value;
        }
        catch { }
    }
    #endregion

    #region isLogin
    public bool isLogin(int group = 0)
    {
        if (SessionKey == "") return false;

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
                if ((int)objData["LGROUP"] != 0 && (int)objDataAcct["ACCT_GROUP"] != (int)objData["LGROUP"])
                {
                    objData["LGROUP"] = 0;
                }

                if (objDataAcct["ACCT_PASS"].ToString() == objData["PASS"].ToString() && (group == 0 || (group != 0 && group == (int)objData["LGROUP"])))
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

        //if (SessionKey != "")
        //{
            objDataRemember.Clean();
            SessionKey = "";
            context.Response.Cookies["LoginCookie"].Value = "";
            context.Response.Cookies["LoginCookie"].HttpOnly = true;
        //}

        return false;
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

    #region Method setMenuActive()
    public static void setMenuActive(string type = "home",string id = "")
    {
        if (id == "0") id = "";
        HttpContext context = HttpContext.Current;
        context.Items["PageType"] = type;
        context.Items["PageID"] = id;
    }
    #endregion


    #region Method ExportToWord
    public static byte[] ExportToWord(string PathFile, List<string> lststr, List<string> lstReplace)
    {
        if (lststr.Count < lstReplace.Count) return null;
        byte[] byteArray = File.ReadAllBytes(HttpContext.Current.Server.MapPath(PathFile));
        using (MemoryStream stream = new MemoryStream())
        {
            stream.Write(byteArray, 0, (int)byteArray.Length);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
            {
                var body = doc.MainDocumentPart.Document.Body;

                foreach (var text in body.Descendants<Text>())
                {
                    // Duyet cac Tu can replace
                    for (int i = 0; i < lststr.Count; i++)
                    {
                        if (text.Text.Contains(lststr[i]))
                        {
                            text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                        }
                    }
                }
                #region block
                // code replace noi dung trong cac element
                //var paras = body.Elements<Paragraph>();
                //foreach (var para in paras)
                //{
                //    //for (int i = 0; i < lststr.Count; i++)
                //    //{
                //    //    if (para.InnerText.Contains(lststr[i]))
                //    //       {
                //    //           string modifiedString = Regex.Replace(para.InnerText, lststr[i], lstReplace[i]);
                //    //           //Style stl = para.FirstChild.Elements<Style>();/// .RemoveAllChildren<Run>();
                //    //           RunProperties t = (RunProperties)para.Elements<Run>().First().RunProperties.CloneNode(true);
                //    //           Run r = new Run(new Text(modifiedString));
                //    //           r.PrependChild<RunProperties>(t);
                //    //            para.RemoveAllChildren<Run>();
                //    //            para.AppendChild<Run>(r);
                //    //            //para.Append<par
                //    //           //para.InnerText = para.InnerText.Replace(lststr[i], lstReplace[i]);
                //    //       }
                //    //    //foreach (var text in para.Elements<Text>())
                //    //    //{
                //    //    //    if (text.Text.Contains(lststr[i]))
                //    //    //    {
                //    //    //        text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                //    //    //    }
                //    //    //}

                //    //}
                // Code goc
                //    foreach (var run in para.Elements<Run>())
                //    {
                //        // Duyet cac Tu can replace
                //        for (int i = 0; i < lststr.Count; i++)
                //        {
                //            foreach (var text in run.Elements<Text>())
                //            {
                //                if (text.Text.Contains(lststr[i]))
                //                {
                //                    text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                //                }
                //            }

                //        }

                //    }
                //}
                #endregion
            }


            return stream.ToArray();
            //DateTime MyDatetime = DateTime.Now;
            //PathNewFile = (Path.GetFullPath(PathFile).Substring(0, PathFile.LastIndexOf("\\"))).Replace("Temp", "Temp2\\") + "/Temp/" + Path.GetFileName(PathFile).Split('.')[0] + MyDatetime.Day + MyDatetime.Month + MyDatetime.Year + MyDatetime.Hour + MyDatetime.Minute + MyDatetime.Second + ".docx";
            //File.WriteAllBytes(PathNewFile, stream.ToArray());
        }
        //return null;
    }
    #endregion

    #region method saveImage
    public static String saveImage(HttpPostedFile PostedFile, string config, string defau)
    {
        try
        {

            if (PostedFile.ContentLength > 5048576 || PostedFile.ContentLength == 0)
            {
                return defau;
            }
            else
            {
                string cfgFolder = System.Configuration.ConfigurationSettings.AppSettings[config].ToString();
                string strBaseLoactionImg = HttpContext.Current.Server.MapPath(cfgFolder);

                SystemClass objSystemClass = new SystemClass();

                string sFileName = objSystemClass.getIDAccount() + DateTime.Now.ToString("-dd-MM-yyy--hh-mm-ss-fffffff-");
                string strEx = System.IO.Path.GetFileName(PostedFile.FileName);
                //strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                PostedFile.SaveAs(strBaseLoactionImg);

                if (defau != "") DeleteFile(defau);

                return cfgFolder + sFileName + strEx;
            }
        }
        catch //(Exception ex)
        {
            return defau;
        }
    }
    #endregion

    #region Method DeleteFile
    public static bool DeleteFile(string file)
    {
        try
        {
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(file));
            return true;
        }
        catch //(System.IO.IOException e)
        {
            return false;
        }
    }

    #endregion
}