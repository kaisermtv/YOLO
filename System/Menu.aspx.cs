using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Menu : System.Web.UI.Page
{
    #region declare
    private DataMenu objMenu = new DataMenu();

    public int index = 1;
    public int itemId = 0;
    public int type = 1;

    public DataRow objData;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        try
        {
            this.type = int.Parse(Request["type"].ToString());
        }
        catch { }
        if (type == 0) type = 1;


        Context.Items["strTitle"] = "QUẢN LÝ MENU";

        if (itemId != 0)
        {
            objData = objMenu.getData(itemId);
            if (objData == null) Response.Redirect("Menu.aspx?type=" + type);

            type = (int)objData["MenuID"];
        }


        if (!Page.IsPostBack)
        {
            ddlGroup.DataSource = objMenu.getDataToCombobox("-- Thư mục gốc --", 0, type);
            ddlGroup.DataValueField = "ID";
            ddlGroup.DataTextField = "NAME";
            ddlGroup.DataBind();

            ddlGroup.SelectedValue = itemId.ToString();

            ddlType.SelectedValue = type.ToString();
        }

    }
    #endregion

    #region method Page_PreRender()
    public void Page_PreRender(object sender, EventArgs e)
    {
        DataTable objData = objMenu.getList(itemId,type);

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int id;
        try
        {
            id = int.Parse(idDel.Value);
        }
        catch
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        if (id != 0)
        {
            objMenu.delData(id);

        }
        else
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }
    }
    #endregion
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Menu.aspx?id=" + ddlGroup.SelectedValue + "&type=" + ddlType.SelectedValue);
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?id=" + ddlGroup.SelectedValue + "&type=" + ddlType.SelectedValue);
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?id=" + ddlGroup.SelectedValue + "&type=" + ddlType.SelectedValue);
    }
}