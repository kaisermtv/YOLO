using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_GroupAcctList : System.Web.UI.Page
{
    #region declare
    private DataGroupAcct objGroupAcct = new DataGroupAcct();

    public int index = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH NHÓM TÀI KHOẢN";

        if(Request.RequestType == "POST")
        {
            SystemClass objSystemClass = new SystemClass();
            int id = 0;
            try
            {
                id = int.Parse(Request.Form["idDel"]);
                if (id != 0)
                {
                    objGroupAcct.delData(id);
                }
                objSystemClass.addMessage("Xóa nhóm tài khoản thành công!");
            }
            catch
            {
                
                objSystemClass.addMessage("Có lỗi xảy ra!");
            }
            
        }

        DataTable objData = objGroupAcct.getList();

        cpData.MaxPages = 1000;
        cpData.PageSize = 15;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
        index = 1;
    }
    #endregion

}