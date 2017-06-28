using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListCategory : System.Web.UI.Page
{
    #region declare 
    public int index = 1;
    #endregion 

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        DanhMuc objDanhMuc = new DanhMuc();

        DataTable objTable = objDanhMuc.getListDanhMuc();
        if (objTable.Rows.Count > 0)
        {
            dtlData.DataSource = objTable.DefaultView;
            dtlData.DataBind();
        }

    }
    #endregion
}