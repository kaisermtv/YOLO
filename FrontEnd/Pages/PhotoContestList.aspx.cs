using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_PhotoContestList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable FbTable = new DataTable();
        FacebookApi FbApi = new FacebookApi();
        FbPhotoAlbum FbPhotoAlbum = new FbPhotoAlbum();
        FbTable = FbPhotoAlbum.getData(1000);
        if (FbTable != null && FbTable.Rows.Count > 0)
        {
            ListPhotoContest.BindData(FbTable);
        }
    }
}