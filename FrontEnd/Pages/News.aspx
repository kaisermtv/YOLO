<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="FrontEnd_Pages_News" %>

<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <script>
        customMenu('/news/?id=<%=this.itemId%>123');
      </script>    

    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <asp:Repeater ID="dtlTop" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="col-xs-12">
                                    <div class="row" id="tin-chinh">
                                        <div class="cleft col-xs-12 col-sm-12 col-md-12">
                                            <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>">
                                                <img onError="this.src='/images/Front-End/no-image-available.png';" src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" height="auto" width="100%"></a>
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
                                    <div class="dr"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 ">
                            <div class="row" style="display: none">
                                <div class="col-xs-12 col-sm-9 col-md-9" id="tin-trung-binh">
                                    <div class="img-wraper">
                                        <a href="" title="">
                                            <img onError="this.src='/images/Front-End/no-image-available.png';" src="" height="auto" width="687"></a>
                                    </div>
                                    <div class="time">Ngày đăng: </div>
                                    <a href="" title="" class="tieu-de"></a>
                                    <p>
                                    </p>
                                </div>
                                <div class="col-xs-12 col-sm-3 col-md-3" id="list-tin-tieu-diem">
                                    <div class="header">Tiêu điểm tuần</div>
                                    <ul>
                                    </ul>
                                </div>
                            </div>

                            <div class="row">
                                <h3 style="float:left"><%=groupname %></h3>
                                <div style="float:right;width:250px">
                                    <select class="form-control" onchange="sapxep(this.options[this.selectedIndex].value)">
                                        <option value="0">Mới nhất</option>
                                        <option value="1" <%= (sapXep == "ASC")?"selected=\"selected\"":""  %>>Cũ nhất</option>
                                    </select>
                                </div>
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

        <script>
            function sapxep(a)
            {
                window.location = "?sapxep=" + a;
            }
        </script>

    </div>
</asp:Content>
