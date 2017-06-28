using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_DanhMucDel : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;
    public string danhmuc = "";
    public DataRow objData;
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/System/ListCategory.aspx");
        }

        DanhMuc objDanhMuc = new DanhMuc();

        objData = objDanhMuc.getItem(itemId);
        if (objData == null) Response.Redirect("/System/ListCategory.aspx");
        if ((int)objData["DanhMucId"] == 0) Response.Redirect("/System/ListCategory.aspx");

        try
        {
            danhmuc = objDanhMuc.getDanhMuc((int)objData["DanhMucId"])["NameDanhMuc"].ToString();
        }
        catch { }
        
    }
    #endregion 

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DanhMuc objDanhMuc = new DanhMuc();
        objDanhMuc.delData(itemId, (int)objData["DanhMucId"]);

        Response.Redirect("DanhMuc.aspx?id=" + objData["DanhMucId"].ToString());
    }
    #endregion
}