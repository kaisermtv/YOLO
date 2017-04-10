<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("trangchu", "trang-chu", "~/Default.aspx");
        routes.MapPageRoute("home", "home", "~/Default.aspx");
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
