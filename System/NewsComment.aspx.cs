using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_NewsComment : System.Web.UI.Page
{
    #region declare
    private DataNewsComment objComment = new DataNewsComment();

    public int index = 0;
    public int itemmId = 0;

    public string txtSearch = "";
    public int trangthai = 0;
    #endregion


    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "THÔNG TIN PHẢN HỒI";

        try
        {
            this.itemmId = int.Parse(Request["id"].ToString());
        }
        catch { }

        try
        {
            this.txtSearch = Request["Search"].ToString();
        }
        catch { }

        try
        {
            this.trangthai = int.Parse(Request["trangthai"].ToString());
        }
        catch { }


        if (Request.RequestType == "POST")
        {
            SystemClass objSystemClass = new SystemClass();
            try
            {
                int idDel = int.Parse(Request.Form["idDel"]);

                objComment.delData(idDel);

                objSystemClass.addMessage("Xóa thành công!");
            }
            catch
            {
                objSystemClass.addMessage("Có lỗi xảy ra!");
            }
        }

        getData();
    }
    #endregion

    #region method getData()
    private void getData()
    {
        DataTable objData = objComment.getList(itemmId, trangthai,txtSearch);

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
}