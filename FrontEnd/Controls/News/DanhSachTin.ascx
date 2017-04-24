<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachTin.ascx.cs" Inherits="FrontEnd_Controls_News_DanhSachTin" %>


<asp:Repeater ID="dtlNews" runat="server" EnableViewState="False">
    <ItemTemplate>
        <li>
            <div class="thumb img-w">
                <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>>" title="<%# Eval("Title") %>">
                    <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>">
                </a>
            </div>
            <div class="info-detail">
                <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>" class="tieu-de"><%# Eval("Title") %></a>
                <p class="sapo">
                    <%# Eval("ShortContent") %>
                </p>
                <div class="time"><%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyyy hh:MM") %></div>
            </div>
        </li>
    </ItemTemplate>
</asp:Repeater>
