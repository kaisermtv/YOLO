<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("tintuc1", "{name}-cat{id}", "~/News.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });
        routes.MapPageRoute("view2", "tin-tuc/{name}-v{id}", "~/NewsView.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });
        routes.MapPageRoute("view3", "news/{name}-v{id}", "~/NewsView.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });
        routes.MapPageRoute("view1", "{name}-v{id}", "~/NewsView.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });
        routes.MapPageRoute("CatView1", "trai-nghiem/{name}-ct{id}", "~/CatView.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });
        routes.MapPageRoute("photo1", "{name}-p{id}", "~/PhotoContest.aspx", false, new RouteValueDictionary { { "id", @"[0-9]+" }, { "name", ".*" } });


        routes.MapPageRoute("trangchu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("home", "home", "~/Default.aspx");
        routes.MapPageRoute("home1", "", "~/Default.aspx");

        routes.MapPageRoute("trainghiem", "trai-nghiem", "~/Category.aspx");
        routes.MapPageRoute("trainghiem1", "Category", "~/Category.aspx");

        routes.MapPageRoute("timkiem", "tim-kiem", "~/Seach.aspx");
        routes.MapPageRoute("Seach", "seach", "~/Seach.aspx");


        routes.MapPageRoute("lienhe", "lien-he", "~/Contact.aspx");
        routes.MapPageRoute("Contact", "contact", "~/Contact.aspx");

        routes.MapPageRoute("ContactOk", "ContactOk", "~/ContactOk.aspx");

        routes.MapPageRoute("Logout", "Logout", "~/Logout.aspx");

        routes.MapPageRoute("dangnhap", "dang-nhap", "~/Login.aspx");
        routes.MapPageRoute("Login", "Login", "~/Login.aspx");

        routes.MapPageRoute("dangky", "dang-ky", "~/Register.aspx");
        routes.MapPageRoute("Register", "Register", "~/Register.aspx");


        routes.MapPageRoute("tintuc", "tin-tuc", "~/News.aspx");
        routes.MapPageRoute("news", "news", "~/News.aspx");

        routes.MapPageRoute("view", "view", "~/NewsView.aspx");
        routes.MapPageRoute("catview", "catview", "~/CatView.aspx");

        routes.MapPageRoute("photo", "photo", "~/PhotoContest.aspx");

        routes.MapPageRoute("AnswerResult", "AnswerResult", "~/AnswerResult.aspx");


        routes.MapPageRoute("cuocthianhdep", "cuoc-thi-ah-dep", "~/PhotoContestList.aspx");

        //, false, new RouteValueDictionary { { "id", "/d" } }
    }

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        
    }

    void Application_Error(object sender, EventArgs e)
    {
    }

       
</script>
