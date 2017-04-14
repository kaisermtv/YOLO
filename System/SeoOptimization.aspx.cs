using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class System_SeoOptimization : System.Web.UI.Page
{
    public string ss = "";
   private string path = "~/sitemap2.xml";
    protected void Page_Load(object sender, EventArgs e)
    {
      Sitemap site = new Sitemap();
      site.ProcessRequest(this.Context);
      writeSiteMapFile(site.sitemap);
    }
    public int writeSiteMapFile(String s)
    {
        try { 
        using(StreamWriter  writer  = new StreamWriter(Server.MapPath(path),true))
        {
            writer.WriteLine(s);
        }
            return 1;
            }
        catch(IOException e)
        {
            System.Diagnostics.Debug.WriteLine("[ ERROR ] CANNOT WRITE STRING TO FILE :   " + e.GetBaseException());
            return 0;   
        }
    }


}
