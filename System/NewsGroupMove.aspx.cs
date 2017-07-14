using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_NewsGroupMove : System.Web.UI.Page
{

    #region declare
    //private DataMenu objMenu = new DataMenu();
    private DataNewsGroup objNewsGroup = new DataNewsGroup();
    //private SystemClass objSystemClass = new SystemClass();

    public int itemId = 0;
    public int vtId = 0;
    public int page = 1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch { }

        try
        {
            this.vtId = int.Parse(Request["vt"].ToString());
        }
        catch { }

        try
        {
            this.page = int.Parse(Request["page"].ToString());
        }
        catch { }

        if (!Page.IsPostBack && this.itemId != 0)
        {
            objNewsGroup.MoveItem(itemId, vtId);
        }

        Response.Redirect("NewsGroupList.aspx" + (page > 1?"?page="+page:""));
    }
}