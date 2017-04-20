﻿<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="FrontEnd_Pages_Home" %>

<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register TagPrefix="uc1" TagName="Banner" Src="~/FrontEnd/Controls/Common/Banner.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <div class="YoloWraper container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="main">
                    <uc1:Banner runat="server" ID="Banner" />
                </div>
            </div>
        </div>
    </div>
    <div id="slide-w">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="main">
                        <h3>Cuộc thi ảnh đẹp</h3>
                        <div class="line"></div>
                        <div class="swiper-container">
                            <div class="swiper-wrapper">
                                <asp:Repeater ID="YoLoSlide" runat="server">
                                    <ItemTemplate>
                                        <div class="swiper-slide">
                                            <div class="img-w person">
                                                <img src="<%#Eval("picture")%>" />
                                            </div>
                                            <div class="person-detail">
                                                <h3><%#Eval("user_name")%></h3>
                                                <p>Ngày sinh: <%#Eval("user_birthday")%></p>
                                                <p>Đến từ: <%#Eval("user_address")%></p>
                                            </div>
                                            <a href="/FrontEnd/Pages/PhotoContest.aspx?id=<%#Eval("id")%>" class="person-nav"></a>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="swiper-slide">
                                    <a href="/FrontEnd/Pages/PhotoContestList.aspx" class="PhotoContest-nav">Xem tất cả</a>
                                </div>
                            </div>
                            <!-- Add Pagination -->
                            <div class="swiper-pagination"></div>
                            <!-- Add Arrows -->
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="main">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8" id="news">
                    <asp:Repeater ID="dtlNews" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <h3>Tin tức</h3>
                            <div class="line"></div>

                            <ul class="lst-news">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <div class="img-w">
                                    <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                                </div>
                                <div class="lst-news-detail">
                                    <a class="tieu-de" href="/FrontEnd/Pages/News_Detail.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a>
                                    <i><%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyyy") %></i>
                                    <p><%# Eval("ShortContent") %></p>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>

                    <div class="row" id="news-r">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3><%=cat1 %></h3>
                            <ul class="news-r-detail">
                                <asp:Repeater ID="dtlData1" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <li>
                                            <div class="img-w">
                                                <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                                            </div>
                                            <a href="/FrontEnd/Pages/News_Detail.aspx?id=<%# Eval("Id") %>" class="tieu-de"><%# Eval("Title") %></a>
                                            <p><%# Eval("ShortContent") %></p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3><%=cat2 %></h3>
                            <ul class="news-r-detail">
                                <asp:Repeater ID="dtlData2" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <li>
                                            <div class="img-w">
                                                <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                                            </div>
                                            <a href="/FrontEnd/Pages/News_Detail.aspx?id=<%# Eval("Id") %>" class="tieu-de"><%# Eval("Title") %></a>
                                            <p><%# Eval("ShortContent") %></p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3><%=cat3 %></h3>
                            <ul class="news-r-detail">
                                <asp:Repeater ID="dtlData3" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <li>
                                            <div class="img-w">
                                                <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                                            </div>
                                            <a href="/FrontEnd/Pages/News_Detail.aspx?id=<%# Eval("Id") %>" class="tieu-de"><%# Eval("Title") %></a>
                                            <p><%# Eval("ShortContent") %></p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3><%=cat4 %></h3>
                            <ul class="news-r-detail">
                                <asp:Repeater ID="dtlData4" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <li>
                                            <div class="img-w">
                                                <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                                            </div>
                                            <a href="/FrontEnd/Pages/News_Detail.aspx?id=<%# Eval("Id") %>" class="tieu-de"><%# Eval("Title") %></a>
                                            <p><%# Eval("ShortContent") %></p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4" id="quangcao">
                    <h3>Mobifone công sở</h3>
                    <a href="#" class="news">
                        <div class="img-w">
                            <img src="../../images/Front-End/banner-1.png" alt="" />
                        </div>
                        <p>Hoa anh đào Nhật Bản khoe sắc bên Hồ Gươm</p>
                    </a>
                    <uc1:QuangCao runat="server" ID="QuangCao1" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var heightNewsR = 0;
        var countNewsR = 0;
        var lenghtNewsR = $('.news-r-detail li:first-child').length;
        $('.news-r-detail li:first-child').each(function (i, item) {
            if ($(item).height() > heightNewsR) {
                console.log(item)
                console.log($(item).height())
                console.log(heightNewsR)
                heightNewsR = $(item).height();
            }
            countNewsR++;
            if (countNewsR == lenghtNewsR) {
                $('.news-r-detail li:first-child').height(heightNewsR);
            }
        });
    </script>
</asp:Content>
