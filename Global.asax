<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("trangchu", "trang-chu", "~/frontend/pages/home.aspx");
        routes.MapPageRoute("home", "home", "~/frontend/pages/home.aspx");
        routes.MapPageRoute("home1", "", "~/frontend/pages/home.aspx");


        routes.MapPageRoute("tintuc", "tin-tuc", "~/frontend/pages/News.aspx");
        routes.MapPageRoute("news", "news", "~/frontend/pages/News.aspx");
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
