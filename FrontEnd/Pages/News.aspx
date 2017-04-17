<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="FrontEnd_Pages_News" %>

<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">


    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <div class="col-xs-12">
                            <a href="/tin-tuc.htm" title="Tin tức"></a>
                            <div class="row" id="tin-chinh">
                                <a href="/tin-tuc.htm" title="Tin tức"></a>
                                <div class="cleft col-xs-12 col-sm-12 col-md-12">
                                    <a href="/tin-tuc.htm" title="Tin tức"></a><a href="/dich-vu/taxi-noi-bai-4827.htm" title="Taxi Noi Bai">
                                        <img src="http://admin.taxi24h.vn/upload/images/20160815164557072.png" height="auto" width="100%"></a>
                                </div>
                                <div class="clearfix visible-xs-block"></div>
                                <div class="tinchinh-h3 col-xs-12 col-sm-12 col-md-12">
                                    <div class="time">Ngày đăng: 15/08/2016 16:45</div>
                                    <a href="/FrontEnd/Pages/News_Detail.aspx" title="Taxi Noi Bai" class="tieu-de">Taxi Noi Bai</a>
                                    <p class="sapo">
                                        Taxi Noi Bai là dịch vụ được Taxi 24h đưa vào phục vụ khách hàng chuyên tuyến Hà Nội đi Nội Bài, Đón khách hàng từ Nội Bài về Hà Nội và đi các tỉnh. Với hệ thống chất lượng phương tiện mới, cao cấp và đội ngũ lái xe Taxi chuyên nghiệp, Taxi Noi Bai đang được khách hàng đánh giá cao về chất lượng dịch vụ với giá thành cạnh tranh trên thị trường hiện nay.
                                    </p>

                                </div>
                            </div>
                            <div class="dr"></div>
                        </div>
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 ">
                            <div class="row" style="display: none">
                                <div class="col-xs-12 col-sm-9 col-md-9" id="tin-trung-binh">
                                    <div class="img-wraper">
                                        <a href="" title="">
                                            <img src="" height="auto" width="687"></a>
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
                                <ul class="col-xs-12 col-sm-12 col-md-12" id="list-tin-tuc">
                                    <asp:Repeater ID="dtlNews" runat="server" EnableViewState="False">
                                        <ItemTemplate>
                                            <li>
                                                <div class="thumb">
                                                    <a href="/tin-tuc/do-xe-kieu-paradel-parking-4826.htm" title="<%# Eval("Title") %>">
                                                        <img src="<%# "/Images/News/" + Eval("ImgUrl").ToString() %>" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>">
                                                    </a>
                                                </div>
                                                <div class="info-detail">
                                                    <a href="/tin-tuc/do-xe-kieu-paradel-parking-4826.htm" title="<%# Eval("Title") %>" class="tieu-de"><%# Eval("Title") %></a>
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
                                    <li class="active"><span><a href="/tin-tuc.htm">1</a></span></li>
                                    <li class=""><span><a href="/tin-tuc/trang-2.htm">2</a></span></li>
                                    <li class=""><span><a href="/tin-tuc/trang-3.htm">3</a></span></li>
                                    <li class=""><span><a rel="nofollow" href="/tin-tuc/trang-4.htm">4</a></span></li>
                                    <li class=""><span><a rel="nofollow" href="/tin-tuc/trang-5.htm">5</a></span></li>
                                    <li class="next sprite"><span><a rel="nofollow" href="/tin-tuc/trang-6.htm">Sau</a></span></li>
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
</asp:Content>
