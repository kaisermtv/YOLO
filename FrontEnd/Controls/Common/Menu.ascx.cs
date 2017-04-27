using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontEnd_Controls_Common_Menu : System.Web.UI.UserControl
{
    #region declare
    private DataMenu objMenu = new DataMenu();

    public int index = 1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    #region method getData()
    private void getData()
    {
        DataTable objData = objMenu.getList();

        dtlData.DataSource = objData.DefaultView;
        dtlData.DataBind();

        index = 1;
    }
    #endregion

    #region getActive(string link)
    public string getActive(string link)
    {
      //  link = link.ToLower();

      //  if (link == "/" || link == "/home" || link == "/trang-chu" || Regex.IsMatch(link, "^/home/.*") || Regex.IsMatch(link, "^/trang-chu/.*"))
      //  {

      //  } 


      //  if (link == "/tin-tuc") return "class=\"active\"";

      //  Match m = Regex.Match(link, "-cat[\\d]+$", RegexOptions.IgnoreCase);
      //if (m.Success)
      //   Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);


        //Regex.IsMatch(link,".*-cat[\\d]",

        return "";
    }
    #endregion
}