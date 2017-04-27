<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("tintuc1", "{name}-cat{id}", "~/frontend/pages/News.aspx", false, new RouteValueDictionary { { "id", "/d" } });
        routes.MapPageRoute("view1", "{name}-v{id}", "~/frontend/pages/News_Detail.aspx", false, new RouteValueDictionary { { "id", "/d" } });
        routes.MapPageRoute("photo1", "{name}-p{id}", "~/frontend/pages/PhotoContest.aspx", false, new RouteValueDictionary { { "id", "/d" } });
        
        
        routes.MapPageRoute("trangchu", "trang-chu", "~/frontend/pages/home.aspx");
        routes.MapPageRoute("home", "home", "~/frontend/pages/home.aspx");
        routes.MapPageRoute("home1", "", "~/frontend/pages/home.aspx");


        routes.MapPageRoute("timkiem", "tim-kiem", "~/frontend/pages/Seach.aspx");
        routes.MapPageRoute("Seach", "seach", "~/frontend/pages/Seach.aspx");


        routes.MapPageRoute("lienhe", "lien-he", "~/frontend/pages/Contact.aspx");
        routes.MapPageRoute("Contact", "contact", "~/frontend/pages/Contact.aspx");

        routes.MapPageRoute("ContactOk", "ContactOk", "~/frontend/pages/ContactOk.aspx");

        routes.MapPageRoute("Logout", "Logout", "~/frontend/pages/Logout.aspx");
        
        routes.MapPageRoute("dangnhap", "dang-nhap", "~/frontend/pages/Login.aspx");
        routes.MapPageRoute("Login", "Login", "~/frontend/pages/Login.aspx");

        routes.MapPageRoute("dangky", "dang-ky", "~/frontend/pages/Register.aspx");
        routes.MapPageRoute("Register", "Register", "~/frontend/pages/Register.aspx");
        

        routes.MapPageRoute("tintuc", "tin-tuc", "~/frontend/pages/News.aspx");
        routes.MapPageRoute("news", "news", "~/frontend/pages/News.aspx");

        routes.MapPageRoute("view", "view", "~/frontend/pages/News_Detail.aspx");

        routes.MapPageRoute("photo", "photo", "~/frontend/pages/PhotoContest.aspx");

        routes.MapPageRoute("AnswerResult", "AnswerResult", "~/frontend/pages/AnswerResult.aspx");
        

        routes.MapPageRoute("cuocthianhdep", "cuoc-thi-ah-dep", "~/frontend/pages/PhotoContestList.aspx");
        
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
