using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_YoloDamchiase : System.Web.UI.Page
{
    public DataTable objTblFbPhotoPost = new DataTable();
    FacebookApi api = new FacebookApi();
    FbPhotoAlbum objfb_post = new FbPhotoAlbum();
    public int count_photo_like = 0, count_photo_comment = 0, count_photo_post = 0;
 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            objTblFbPhotoPost = objfb_post.getData(1000);
            count_photo_post = objTblFbPhotoPost.Rows.Count;
            count_photo_comment = objfb_post.countComments();
            count_photo_like = objfb_post.countLikes();
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        api.refressPhotoPost(20);                     // limits 30
        Response.Redirect(Request.RawUrl);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objfb_post.delAllData();
        api.saveAllPostToDb(2,200);
        Response.Redirect(Request.RawUrl);
    }
    protected void btnUpdateToken_Click(object sender, EventArgs e)
    {
        
    }
}