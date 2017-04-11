using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FacebookSetup : System.Web.UI.Page
{
    public DataTable objTblFbPost = new DataTable();
    FacebookApi api = new FacebookApi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
         
          // 
        }

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
            
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        api.saveToDb();
    }
}