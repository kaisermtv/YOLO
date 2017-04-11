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
    FbPosts objfb_post = new FbPosts();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            objTblFbPost = objfb_post.getData();
            //count like , count comment , count xxx
        }

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        api.refresh();
        Response.Redirect(Request.RawUrl);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objfb_post.delAllData();
        api.saveAllToDb();
        Response.Redirect(Request.RawUrl);
    }
}