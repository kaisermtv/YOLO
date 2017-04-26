<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="FrontEnd_Pages_News" %>

<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register Src="~/FrontEnd/Controls/News/DanhSachTin.ascx" TagPrefix="uc1" TagName="DanhSachTin" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <script>
        customMenu('/news/?id=<%=this.itemId%>123');
    </script>

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
                                <asp:Repeater ID="dtlTop" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <div class="col-xs-12">
                                            <div class="row" id="tin-chinh">
                                                <div class="cleft col-xs-12 col-sm-12 col-md-12">
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>">
                                                        <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" height="auto" width="100%"></a>
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
                                        <li data-value="DESC" class="<%= (sapXep != "ASC")?"active":""  %>">Mới nhất</li>
                                        <li data-value="ASC" class="<%= (sapXep == "ASC")?"active":""  %>">Cũ nhất</li>
                                    </ul>
                                </div>
                                <ul class="col-xs-12 col-sm-12 col-md-12" id="list-tin-tuc">
                                    <uc1:DanhSachTin runat="server" ID="DanhSachTin" />
                                </ul>
                            </div>

                            <div>

                                <%-- <ul class="pager">
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
                                </ul>--%>
                                <a href="javascript:;" class="btn btn-default-2 btn-xemthem" data-value="1">Xem thêm</a>
                            </div>
                        </div>
                        <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs">
                            <uc1:DanhMuc runat="server" ID="DanhMuc" />
                            <uc1:QuangCao runat="server" ID="QuangCao1" />
                        </div>
                    </div>


                </div>
            </div>
        </div>

        <script>
            $('#news-orderby li').click(function () {
                $('#news-orderby li').removeClass('active');
                $(this).addClass('active');
                var OrderBy = $(this).data('value');
                //window.location = "?sapxep=" + value;
                $.ajax({
                    type: "GET",
                    url: "/FrontEnd/Ajax/News/LoadList.aspx?Id=<%=this.itemId%>&PageIndex=1&OrderBy=" + OrderBy,
                    success: function (res) {
                        if (res != "") {
                            $('#list-tin-tuc').html(res);
                            $('.btn-xemthem').attr('data-value', 1);
                            $('.btn-xemthem').show();
                        }
                    }
                });
            });
            $('.btn-xemthem').click(function () {
                var PageIndex = parseInt($(this).attr('data-value')) + 1;
                var OrderBy = $('#news-orderby li.active').data('value');
                //window.location = "?sapxep=" + value;
                $.ajax({
                    type: "GET",
                    url: "/FrontEnd/Ajax/News/LoadList.aspx?Id=<%=this.itemId%>&PageIndex=" + PageIndex + "&OrderBy=" + OrderBy,
                    success: function (res) {
                        $('.btn-xemthem').attr('data-value', PageIndex);
                        if (res.trim() != "") {
                            $('#list-tin-tuc').append(res);

                        } else {
                            $('.btn-xemthem').hide();
                        }
                    }
                });
            });
            function sapxep(a) {
                window.location = "?sapxep=" + a;
            }
        </script>

    </div>
</asp:Content>
