using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ContactList : System.Web.UI.Page
{
    #region declare
    private DataContact objContact = new DataContact();

    public int index = 0;
    public string seach = "";
    public int trangThai = 0;
    #endregion

    #region Event Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH LIÊN HỆ";
        try
        {
            seach = Request["Seach"].ToString();
        }
        catch { }

        try
        {
            trangThai = int.Parse(Request["tt"].ToString());
        }
        catch { }

        if (!Page.IsPostBack)
        {
            ddlTrangThai.SelectedValue = trangThai.ToString();
            txtSearch.Value = seach;

        }
    }
    #endregion

    #region Event Page_PreRender()
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objContact.getList();

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpData.MaxPages = 1000;
        cpData.PageSize = 15;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;

        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region Event btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        SystemClass objSystemClass = new SystemClass();

        int id;
        try
        {
            id = int.Parse(idDel.Value);
        }
        catch
        {
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        if (id != 0)
        {
            objContact.delData(id);

        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        objSystemClass.addMessage("Xóa thành công!");

        Response.Redirect(Request.Url.ToString());
    }
    #endregion

    #region Event btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Redirect();
    }
    #endregion

    #region Event ddlTrangThai_SelectedIndexChanged
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        Redirect();
    }
    #endregion

    #region Method Redirect()
    public void Redirect()
    {
        string rq = "?";
        if (txtSearch.Value.Trim() != "")
        {
            rq += "Seach=" + HttpUtility.UrlEncode(txtSearch.Value.Trim());
        }

        if (int.Parse(ddlTrangThai.SelectedValue) != -1)
        {
            if (rq != "?") rq += "&";
            rq += "tt=" + ddlTrangThai.SelectedValue;
        }

        Response.Redirect("ContactList.aspx" + rq);
    }
    #endregion
}