<%@ Page Language="C#" Title="Trang chủ" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%--<%@ Register Src="~/Controller/SliderOne.ascx" TagPrefix="uc1" TagName="SliderOne" %>--%>
<%@ Register Src="~/Controller/SliderTwo.ascx" TagPrefix="uc1" TagName="SliderTwo" %>
<%--<%@ Register Src="~/Controller/CuocThiAnh.ascx" TagPrefix="uc1" TagName="CuocThiAnh" %>--%>
<%@ Register Src="~/Controller/SanPhamDichVu.ascx" TagPrefix="uc1" TagName="SanPhamDichVu" %>
<%@ Register Src="~/Controller/TinTucHoatDong.ascx" TagPrefix="uc1" TagName="TinTucHoatDong" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link href="/css/HeaderSlide.css" rel="stylesheet" />--%>

    <link href="/css/jquerysctipttop.css" rel="stylesheet" type="text/css">
    <link href="/css/normalize.min.css" rel="stylesheet" type="text/css">
    <link href="/css/Slide3.css" rel="stylesheet" type="text/css">

    <link rel="stylesheet" href="/css/bootstrap-grid.css">
    <link rel="stylesheet" href="/css/trainghiemSPDV/style.css">


    <!-- Theme flexslider -->
    <link rel="stylesheet" type="text/css" href="/css/flexslider.css" />

    <!-- Responsive -->
    <link rel="stylesheet" type="text/css" href="/css/responsive.css">
    
    <link rel="stylesheet" type="text/css" href="/css/shortcodes.css">
   <%-- <link rel="stylesheet" type="text/css" href="/css/style1.css">--%>
    
</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript" src="../Scripts/jquery.flexslider-min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.magnific-popup.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.sticky.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-waypoints.js"></script>
    <script type="text/javascript" src="../Scripts/main.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <uc1:SliderTwo runat="server" />
    <%--<uc1:SliderOne runat="server"  />--%>
    
    <%--<uc1:CuocThiAnh runat="server" />--%>

    <!-- KHOI SO 2 - FANPER  -->
    <div class="container" style="margin-top:30px">
        <img src="<%=pic_cover %>" style="width:100%" />
    </div>
    <!-- KET THUC KHOI SO 2 -->


    <uc1:SanPhamDichVu runat="server" />

    <uc1:TinTucHoatDong runat="server" />
</asp:Content>