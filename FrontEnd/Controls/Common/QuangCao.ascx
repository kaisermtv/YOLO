<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuangCao.ascx.cs" Inherits="FrontEnd_Controls_Common_QuangCao" %>

<asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
    <HeaderTemplate>
        <ul class="banner-quangcao" id="QuangCao">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <a href="<%# Eval("LINK") %>" target="_blank">
                <img src="/images/Slider/<%# Eval("IMG") %>" />
            </a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
