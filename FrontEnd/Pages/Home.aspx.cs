using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Pages_Home : System.Web.UI.Page
{
    #region declare
    private DataNews objNews = new DataNews();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();

    public String cat1, cat2, cat3, cat4;



    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "Trang chủ";

        if (!Page.IsPostBack)
        {
            DataTable objData = objNews.getDataTop(5);

           
            if (objData != null)
            {
                dtlNews.DataSource = objData.DefaultView;
                dtlNews.DataBind();
            }


            cat1 = objNewsGroup.getNameById(3);
            DataTable objData1 = objNews.getDataTop(3, 3);
            if (objData1 != null)
            {
                dtlData1.DataSource = objData1.DefaultView;
                dtlData1.DataBind();
            }

            cat2 = objNewsGroup.getNameById(4);
            DataTable objData2 = objNews.getDataTop(3, 4);
            
            if (objData2 != null)
            {
                dtlData2.DataSource = objData2.DefaultView;
                dtlData2.DataBind();
            }

            cat3 = objNewsGroup.getNameById(5);
            DataTable objData3 = objNews.getDataTop(3, 5);
            if (objData3 != null)
            {
                dtlData3.DataSource = objData3.DefaultView;
                dtlData3.DataBind();
            }
            

            cat4 = objNewsGroup.getNameById(2);
            DataTable objData4 = objNews.getDataTop(3, 2);
         
            if (objData4 != null)
            {
                dtlData4.DataSource = objData4.DefaultView;
                dtlData4.DataBind();
            }

            //FacebookApi FbApi = new FacebookApi();
            FbPhotoAlbum FbPhotoAlbum = new FbPhotoAlbum();
            DataTable FbTable = FbPhotoAlbum.getData(12);
           

            if (FbTable != null)
            {
                YoLoSlide.DataSource = FbTable.DefaultView;
                YoLoSlide.DataBind();
            }
        }
    }
}