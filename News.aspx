<%@ Page Language="C#" Title="Tin Tức" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="News.aspx.cs" Inherits="News" %>


<%@ Register Src="~/Controller/Paging.ascx" TagPrefix="uc1" TagName="Paging" %>
<%@ Register Src="~/Controller/DanhMucTin.ascx" TagPrefix="uc1" TagName="DanhMucTin" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/front-end.css">
    <link rel="stylesheet" type="text/css" href="/css/reset.css">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <ul id="NavDetail">
                                <li><a href="/">Trang chủ</a></li>
                                <li class="active"><a><%=groupname %></a></li>
                            </ul>

                        </div>
                    </div>
                    <div class="row show-grid">


                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 ">


                            <div class="row">
                                <%--<% if (topData != null){ %>
                                <div class="col-xs-12">
                                            <div class="row" id="tin-chinh">
                                                <div class="cleft col-xs-12 col-sm-12 col-md-12">
                                                    <a href="/<%= SystemClass.convertToUnSign2(topData["Title"].ToString()) %>-v<%= topData["Id"] %>" title="<%= topData["Title"] %>">
                                                        <img onerror="imgCatchError(this)" src="<%= topData["ImgUrl"].ToString() %>" height="auto" width="100%"></a>
                                                </div>
                                                <div class="clearfix visible-xs-block"></div>
                                                <div class="tinchinh-h3 col-xs-12 col-sm-12 col-md-12">
                                                    <div class="time">Ngày đăng: <%= ((DateTime)topData["DayPost"]).ToString("dd/MM/yyy hh:mm") %></div>
                                                    <a href="/<%# SystemClass.convertToUnSign2(topData["Title"].ToString()) %>-v<%= topData["Id"] %>" title="<%= topData["Title"] %>" class="tieu-de"><%= topData["Title"] %></a>
                                                    <p class="sapo">
                                                        <%= topData["ShortContent"] %>
                                                    </p>

                                                </div>
                                            </div>

                                        </div>
                                <% } %>--%>
                                <asp:Repeater ID="dtlTop" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <div class="col-xs-12">
                                            <div class="row" id="tin-chinh">
                                                <div class="cleft col-xs-12 col-sm-12 col-md-12">
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>">
                                                        <img onerror="imgCatchError(this)" src="<%# Eval("ImgUrl").ToString() %>" height="auto" width="100%"></a>
                                                </div>
                                                <div class="clearfix visible-xs-block"></div>
                                                <div class="tinchinh-h3 col-xs-12 col-sm-12 col-md-12">
                                                    <div class="time">Ngày đăng: <%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyy hh:mm") %></div>
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>" class="tieu-de"><%# Eval("Title") %></a>
                                                    <p class="sapo">
                                                        <%# Eval("ShortContent") %>
                                                    </p>

                                                </div>
                                            </div>

                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <ul id="news-orderby">
                                        <li data-value="DESC" class="<%= (sapXep != "ASC")?"active":""  %>"><a href="<%= getLink(0) %>">Mới nhất</a></li>
                                        <li data-value="ASC" class="<%= (sapXep == "ASC")?"active":""  %>"><a href="<%= getLink(1) %>">Cũ nhất</a></li>
                                    </ul>
                                </div>
                                <ul class="col-xs-12 col-sm-12 col-md-12" id="list-tin-tuc">
                                    <asp:Repeater ID="dtlNews" runat="server" EnableViewState="False">
                                        <ItemTemplate>
                                            <li>
                                                <div class="thumb img-w">
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>">
                                                        <img onerror="imgCatchError(this)" src="<%# Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>">
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

                                </ul>
                            </div>

                            <div style="float:right; margin-top:20px;">

                                <uc1:Paging ID="pageId" runat="server" />
                                <%--<a href="javascript:;" class="btn btn-default-2 btn-xemthem" data-value="1">Xem thêm</a>--%>
                            </div>
                        </div>
                        <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs">
                            <uc1:DanhMucTin ID="danhMuc" runat="server" />
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
