<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="FrontEnd_Controls_Common_Banner" %>


<asp:Repeater ID="dtlNews" runat="server" EnableViewState="False">
    <HeaderTemplate>
        <div id="tab" class="hidden-xs hidden-sm">
            <ul class="tab-w">
    </HeaderTemplate>
    <ItemTemplate>
                <li class="tab-el">
                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>">
                        <h3><%# Eval("Title") %></h3>
                        <div class="img-w">
                            <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                        </div>

                    </a>
                </li>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>

<div class="tab-slide-m visible-xs visible-sm">
    <div class="swiper-wrapper">
        <div class="swiper-slide" data-href="/">
            <h3>8 homestay đẹp lung linh thôi thúc bạn đi du lịch ngay và luôn</h3>
            <div class="img-w">
                <img src="/images/Front-End/banner-1.png" alt="" />
            </div>
        </div>
        <div class="swiper-slide" data-href="/">
            <h3>8 homestay đẹp lung linh thôi thúc bạn đi du lịch ngay và luôn</h3>
            <div class="img-w">
                <img src="/images/Front-End/banner-2.png" alt="" />
            </div>
        </div>
        <div class="swiper-slide" data-href="/">
            <h3>8 homestay đẹp lung linh thôi thúc bạn đi du lịch ngay và luôn</h3>
            <div class="img-w">
                <img src="/images/Front-End/banner-1.png" alt="" />
            </div>
        </div>
        <div class="swiper-slide" data-href="/">
            <h3>8 homestay đẹp lung linh thôi thúc bạn đi du lịch ngay và luôn</h3>
            <div class="img-w">
                <img src="/images/Front-End/banner-1.png" alt="" />
            </div>
        </div>
    </div>
    <!-- Add Pagination -->
    <div class="swiper-pagination"></div>
    <!-- Add Arrows -->
    <div class="swiper-button-next"></div>
    <div class="swiper-button-prev"></div>
</div>

<div id="banner">
    <img src="../../../images/Front-End/banner.png" />
</div>
