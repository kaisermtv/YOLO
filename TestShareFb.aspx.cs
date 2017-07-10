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

        dynamic retdata = objFb.Share("", "", "http://113.164.227.242:4083/" + SystemClass.convertToUnSign2("test") + "-v" + 1,"","123123","svsdjvsdv7ds7v");
        output = JsonConvert.SerializeObject(retdata);


        //output = JsonConvert.SerializeObject(objFb.getTopPostPage());
    }
}