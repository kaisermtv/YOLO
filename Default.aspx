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

    <!-- HIEU UNG CHU TREN ANH -->
    <%--<style>
        div.background {
            border: 0px solid black;
        }

        div.transbox {
            margin: 30px;
            background-color: #ffffff;
            opacity: 0.5;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            margin-top:-150px;
        }

        div.transbox p {
            margin: 5%;
            font-weight: bold;
            color: #000000;
            width:50%;
            border:solid 1px red;
        }
    </style>--%>
    <!-- -->

    <style>
        #myCarousel {
            width: 100%;
            position: absolute;
            top: 0px;
            padding-left: 120px;
            height: 100%;
            overflow: hidden;
        }

        #myCarousel .item{
            width:100%;
            text-align:center;
            vertical-align:central;
        }
    </style>
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
    <div class="container" style="margin-top: 30px;position:relative;">
        <div class="phoneHeader" id="newsHeader" style="min-height: 65px; background-color: #2c90f7; color: #fff; font-size: 30px; font-weight: bold; text-align: center; padding-top: 12px; margin-bottom: 30px;">
              <a href="https://www.Facebook.com/yolomobifone" style="color:white;">Facebook.com/yolomobifone</a>
        </div>


        <%--<div class="background" style="background-image: url(<%=pic_cover %>); background-repeat:no-repeat; width:100%!important;">--%>
        <a href="/ket-noi-facebook">
            <img src="<%=pic_cover %>" style="width: 100%;" />
        </a>

        <div style="position:absolute;bottom:0px;right:15px">
            <img src="/images/pimgpsh_fullsize_distr.png" />
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <asp:Repeater ID="dtlNewsFacebook" runat="server">
                        <ItemTemplate>
                            <div class="item <%= i++ ==0?"active":"" %>">
                                <a href="<%# Eval("link") %>"><h4><%# getTitle((dynamic)Container.DataItem) %></h4></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>

        </div>

           <%-- <div class="transbox">
                <p>This is some text that is placed in the transparent box.</p>
            </div>
        </div>--%>

    </div>
    <!-- KET THUC KHOI SO 2 -->


    <uc1:SanPhamDichVu runat="server" />

    <uc1:TinTucHoatDong runat="server" />
</asp:Content>
