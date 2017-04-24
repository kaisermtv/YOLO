<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../App_Master/Site.master" CodeFile="Seach.aspx.cs" Inherits="FrontEnd_Pages_Seach" %>

<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">


    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 ">

                            <div class="search-w" style="width: 100%; padding-left: 20px">
                                <form method="get" action="/tim-kiem">
                                    <input class="txt-search" name="Seach" placeholder="Nhập từ khóa tìm kiếm.." value="<%=seach %>" />

                                     <button type="submit" class="btn-search">Tìm kiếm</button>
                                </form>
                            </div>

                            <div class="row">

                                <ul class="col-xs-12 col-sm-12 col-md-12" id="list-tin-tuc">
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
                                </ul>
                            </div>

                            <div>

                                <ul class="pager">
                                    <asp:Repeater ID="ddlpager" runat="server" EnableViewState="False">
                                        <ItemTemplate>
                                            <li <%# ((bool)DataBinder.Eval(Container.DataItem, "Active"))?"class=\"active\"":"" %>>
                                                <a <%# (((String)DataBinder.Eval(Container.DataItem, "Link")) != "#")?"href=\"/tin-tuc/" +DataBinder.Eval(Container.DataItem, "Link") + "\"":"" %>>
                                                    <span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                    </span>
                                                </a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>

                            </div>
                        </div>
                        <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs">
                            <%--<uc1:DanhMuc runat="server" ID="DanhMuc" />--%>
                            <uc1:QuangCao runat="server" ID="QuangCao1" />
                        </div>
                    </div>


                </div>
            </div>
        </div>

    </div>
    <script type="text/javascript">
        //$('.main-header .search-w').hide();
    </script>
</asp:Content>
