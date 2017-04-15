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
    private string path = "http://yolo.com/sitemap.xml";
    protected void Page_Load(object sender, EventArgs e)
    {
    


    }
   
    protected void btnXmlDownload_Click(object sender, EventArgs e)
    {
        Sitemap site = new Sitemap();
        site.ProcessFileRequest(this.Context);
        Page.ClientScript.RegisterStartupScript(GetType(),"confirm","confirm('sitemap.xml biên dịch thành công tại địa chỉ : "+path+" .')",true);
        return;
    }
    protected void btnChecking_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.google.com/webmasters/sitemaps/ping?sitemap="+path);
        return;
    }
    protected void btnXmlWatch_Click(object sender, EventArgs e)
    {
        Sitemap site = new Sitemap();
        site.ProcessTextRequest(this.Context);
        Page.ClientScript.RegisterStartupScript(GetType(), "confirm", "confirm('sitemap.xml biên dịch thành công tại địa chỉ : " + path + " .')", true);
        return;
    }
}
