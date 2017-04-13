using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FacebookSetup : System.Web.UI.Page
{
    public DataTable objTblFbPost = new DataTable();
    FacebookApi api = new FacebookApi();
    FbPosts objfb_post = new FbPosts();
    public  int count_like = 0,count_comment= 0 , count_post=0;
    public string last_token = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            objTblFbPost = objfb_post.getData();
            count_post = objTblFbPost.Rows.Count;
            count_like = objfb_post.countLikes();
            count_comment = objfb_post.countComments();
            //count like , count comment , count xxx
            last_token = api.getNewAccessToken();
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
    protected void btnUpdateToken_Click(object sender, EventArgs e)
    {
        if(txtNewToken.Value.Trim() == "" || txtNewToken.Value.Trim().Length <= 30) 
        {
            return;
        }
        else
        {
            if(api.setNewAccessToken(txtNewToken.Value.Trim()) == 1)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alert", "confirm('Cập nhật thất bại')", true);
                Debug.WriteLine("TOKEN ĐẢ ĐƯỢC THAY ĐỔI");
                return;
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "alert", "confirm('Cập nhật Token thành công !')", true);
            return;
        }
    }
}