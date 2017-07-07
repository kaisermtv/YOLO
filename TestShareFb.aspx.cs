using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.Dynamic;
using Newtonsoft.Json;

public partial class TestShareFb : System.Web.UI.Page
{
    public string output = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        FacebookAPI objFb = new FacebookAPI();



        //output = JsonConvert.SerializeObject(objFb.Share(""));
    }
}