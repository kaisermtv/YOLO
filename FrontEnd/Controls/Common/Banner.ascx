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
                            <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
                        </div>

                    </a>
                </li>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>


<asp:Repeater ID="ddlSlider" runat="server" EnableViewState="False">
    <HeaderTemplate>
        <div class="tab-slide-m visible-xs visible-sm">
            <div class="swiper-wrapper">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="swiper-slide" data-href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>">
            <h3><%# Eval("Title") %></h3>
            <div class="img-w">
                <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" />
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
            </div>
            <!-- Add Pagination -->
            <div class="swiper-pagination"></div>
            <!-- Add Arrows -->
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>
    </FooterTemplate>
</asp:Repeater>

<div id="banner">
    <img src="../../../images/Front-End/banner.png" />
</div>
