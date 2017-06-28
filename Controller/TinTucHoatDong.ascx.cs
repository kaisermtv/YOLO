using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_TinTucHoatDong : System.Web.UI.UserControl
{
    #region declare
    private DataNews objNews = new DataNews();
    public int lengNews = 0;
    public string beginChar = "";
    public string title = "";
    public string describe = "";
    public string link = "";
    public string image = "";
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        


    }
    #endregion

    #region Even Page_PreRender
    public void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable objData = objNews.getDataTop(5, 1);
            if (objData.Rows.Count > 0)
            {
                lengNews = objData.Rows.Count;

                beginChar = objData.Rows[0]["Title"].ToString().Substring(0, 1);
                title = objData.Rows[0]["Title"].ToString().Substring(1);

                describe = objData.Rows[0]["ShortContent"].ToString();
                link = "";
                image = objData.Rows[0]["ImgUrl"].ToString();

                objData.Rows.Remove(objData.Rows[0]);

                dtlData.DataSource = objData.DefaultView;
                dtlData.DataBind();
            }
        }
    }
    #endregion
}