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
          
            //count like , count comment , count xxx
            //last_token = api.getNewAccessToken();
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        api.refreshPost(30);        // limits 30
        Response.Redirect(Request.RawUrl);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
     //   objfb_post.delAllData();
        api.saveAllPostToDb();
        Response.Redirect(Request.RawUrl);
    }
    protected void btnUpdateToken_Click(object sender, EventArgs e)
    {
        if(txtNewToken.Value.Trim() == "" || txtNewToken.Value.Trim().Length <= 30) 
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "alert", "confirm('Định  dạng không đúng ')", true);
            return;
        }
        else
        {
            //if (api.setNewAccessToken(txtNewToken.Value.Trim()) == 1)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "alert", "if(confirm('Cập nhật Token thành công !')){window.location.reload()}", true);
            //    result.InnerText = "Cập nhật Token thành công !";
            //    Debug.WriteLine("TOKEN ĐẢ ĐƯỢC THAY ĐỔI");
            //    Response.Redirect(Request.RawUrl);
            //   return;
            //}
            //Page.ClientScript.RegisterStartupScript(GetType(), "alert", "confirm('Cập nhật thất bại')", true);
            //result.InnerText = "Cập nhật thất bại";
         //  Response.Redirect(Request.RawUrl);
           return;
        }
    }
}