using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AccountList : System.Web.UI.Page
{
    #region declare
    private DataAccount objAccount = new DataAccount();

    public int index = 1;
    public string seach = "";
    public int group = -1;

    #endregion

    #region Event Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH TÀI KHOẢN";

        try
        {
            seach = Request["Seach"].ToString();
        }
        catch { }

        try
        {
            group = int.Parse( Request["group"].ToString());
        }
        catch { }
        
        if (!Page.IsPostBack)
        {
            DataGroupAcct objGroupAcct = new DataGroupAcct();
            ddlGroup.DataSource = objGroupAcct.getDataToCombobox();
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            ddlGroup.SelectedValue = group.ToString();

            txtSearch.Value = seach;

        }
    }
    #endregion

    #region Event Page_PreRender()
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objAccount.getList(int.Parse(ddlGroup.SelectedValue), txtSearch.Value.Trim());

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpAccount.MaxPages = 1000;
        cpAccount.PageSize = 15;
        cpAccount.DataSource = objData.DefaultView;
        cpAccount.BindToControl = dtlAccount;

        dtlAccount.DataSource = cpAccount.DataSourcePaged;
        dtlAccount.DataBind();

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
            objAccount.delAccount(id);
        }
        else
        {
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        objSystemClass.addMessage("Xóa tài khoản thành công!");

        Response.Redirect(Request.Url.ToString());
    }
    #endregion

    #region Event btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
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

        if (int.Parse(ddlGroup.SelectedValue) != -1)
        {
            if (rq != "?") rq += "&";
            rq += "group=" + ddlGroup.SelectedValue;
        }

        Response.Redirect("AccountList.aspx" + rq);
    }
    #endregion

    #region Event ddlGroup_SelectedIndexChanged
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Redirect();
    }
    #endregion
}