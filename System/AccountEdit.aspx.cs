using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AccountEdit : System.Web.UI.Page
{
    #region declare
    private int itemId = 0;

    private DataAccount objAccount = new DataAccount();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch{}

        if(!Page.IsPostBack)
        {
            //DataRow objData = objAccount.getAccount(this.itemId);


        }
    }
}