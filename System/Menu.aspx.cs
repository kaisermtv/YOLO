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

        if (Request.RequestType == "POST")
        {
            SystemClass objSystemClass = new SystemClass();
            try
            {
                int idDel = int.Parse(Request.Form["idDel"]);

                objMenu.delData(idDel);

                objSystemClass.addMessage("Xóa menu thành công!");
            }
            catch
            {
                objSystemClass.addMessage("Có lỗi xảy ra!");
            }
        }
        
        if (itemId != 0)
        {
            objData = objMenu.getData(itemId);
            if (objData == null) Response.Redirect("Menu.aspx?type=" + type,false);

            type = (int)objData["MenuID"];
        }

        ddlGroup.DataSource = objMenu.getDataToCombobox("-- Thư mục gốc --", 0, type);
        ddlGroup.DataBind();

        


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

}