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
                                    <li>

                                        <div class="thumb">
                                            <a href="/tin-tuc/do-xe-kieu-paradel-parking-4826.htm" title="Đỗ xe kiểu Paradel Parking">
                                                <img src="http://admin.taxi24h.vn/upload/images/20160421110101976.png" alt="Đỗ xe kiểu Paradel Parking" title="Đỗ xe kiểu Paradel Parking">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/do-xe-kieu-paradel-parking-4826.htm" title="Đỗ xe kiểu Paradel Parking" class="tieu-de">Đỗ xe kiểu Paradel Parking</a>
                                            <p class="sapo">
                                                Đỗ xe kiểu Paradel Parking khá thách thức đối với các tay lái mới cầm vô lăng, nó đòi hỏi kỹ năng quan sát và óc tư duy đánh lái logic của người lái xe. Tuy nhiên chỉ với 7 bước cơ bản, Taxi Noi Bai gửi đến các bạn cách tiếp cận dễ nhất, đảm bảo ai cũng có thể làm được sau khi đọc hướng dẫn này !
                                            </p>
                                            <div class="time">Ngày đăng: 21/04/2016 11:01</div>
                                        </div>

                                    </li>
                                    <li>
                                        <div class="thumb">
                                            <a href="/tin-tuc/xang-lai-giam-gia-4822.htm" title="Xăng lại giảm giá ">
                                                <img src="http://admin.taxi24h.vn/upload/images/20160218154630498.png" alt="Xăng lại giảm giá " title="Xăng lại giảm giá ">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/xang-lai-giam-gia-4822.htm" title="Xăng lại giảm giá " class="tieu-de">Xăng lại giảm giá </a>
                                            <p class="sapo">
                                                Vào 15h chiều nay 18/02/2016, sau khi thực hiện quyết định của liên bộ Công Thương - Tài Chính về việc yêu cầu các đơn vị phân phối xăng dầu điều chỉnh giá bán lẻ, các đại lý đã tiến hành giảm giá xăng đồng loạt, với mức giảm đối với xăng A92 đến 960 đ/1 lít
                                   
                                            </p>
                                            <div class="time">Ngày đăng: 18/02/2016 15:46</div>
                                        </div>

                                    </li>
                                    <li>
                                        <div class="thumb">
                                            <a href="/tin-tuc/nhung-tinh-cam-cua-nguoi-dan-thu-do-khi-cu-rua-qua-doi-4820.htm" title="Những tình cảm của người dân Thủ Đô khi Cụ Rùa qua đời">
                                                <img src="http://admin.taxi24h.vn/upload/images/20160120203517781.png" alt="Những tình cảm của người dân Thủ Đô khi Cụ Rùa qua đời" title="Những tình cảm của người dân Thủ Đô khi Cụ Rùa qua đời">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/nhung-tinh-cam-cua-nguoi-dan-thu-do-khi-cu-rua-qua-doi-4820.htm" title="Những tình cảm của người dân Thủ Đô khi Cụ Rùa qua đời" class="tieu-de">Những tình cảm của người dân Thủ Đô khi Cụ Rùa qua đời</a>
                                            <p class="sapo">
                                                Gắn liền với truyền thuyết đòi Gươm báu khi Vua Lê Lợi đánh thắng Quân Minh, cụ Rùa Hồ Gươm đã trở thành biểu tượng, là linh vật thiêng liêng của người dân Thủ đô. Cụ Rùa đã ra đi ngày 19/01/2016, vào thời điểm trọng đại của Thủ đô và nhân dân cả nước trước thềm Đại hội Đảng toàn quốc lần thứ 12. Taxi 24h điểm lại một số tình cảm của các nghệ sỹ, người dân thủ đô khi Cụ Rùa qua đời !
                                   
                                            </p>
                                            <div class="time">Ngày đăng: 20/01/2016 20:35</div>
                                        </div>

                                    </li>
                                    <li>
                                        <div class="thumb">
                                            <a href="/tin-tuc/taxi-24h-trang-bi-binh-chua-chay-tren-100-xe-taxi-4819.htm" title="Taxi 24h trang bị bình chữa cháy trên 100% xe Taxi">
                                                <img src="http://admin.taxi24h.vn/upload/images/20160108163940296.png" alt="Taxi 24h trang bị bình chữa cháy trên 100% xe Taxi" title="Taxi 24h trang bị bình chữa cháy trên 100% xe Taxi">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/taxi-24h-trang-bi-binh-chua-chay-tren-100-xe-taxi-4819.htm" title="Taxi 24h trang bị bình chữa cháy trên 100% xe Taxi" class="tieu-de">Taxi 24h trang bị bình chữa cháy trên 100% xe Taxi</a>
                                            <p class="sapo">
                                                Thực hiện Thông tư 57/2015/TT-BCA của Bộ Công An ban hành ngày 26/10/2015 về việc hướng dẫn trang bị phương tiện phòng cháy chữa cháy đối với phương tiện giao thông cơ giới đường bộ, Taxi 24h đã chủ động đầu tư cho toàn bộ xe Taxi bình chữa cháy trên xe Taxi, do vậy 100% phương tiện của đơn vị được trang bị bao gồm cả những xe Taxi Noi Bai, Taxi đường dài liên tỉnh.
                                   
                                            </p>
                                            <div class="time">Ngày đăng: 08/01/2016 16:39</div>
                                        </div>

                                    </li>
                                    <li>
                                        <div class="thumb">
                                            <a href="/tin-tuc/xang-giam-gia-370-dong-1-lit-4816.htm" title="Xăng giảm giá 370 đồng 1 lít">
                                                <img src="http://admin.taxi24h.vn/upload/images/20160104215326015.png" alt="Xăng giảm giá 370 đồng 1 lít" title="Xăng giảm giá 370 đồng 1 lít">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/xang-giam-gia-370-dong-1-lit-4816.htm" title="Xăng giảm giá 370 đồng 1 lít" class="tieu-de">Xăng giảm giá 370 đồng 1 lít</a>
                                            <p class="sapo">
                                                Hôm nay 04.01.2016, vào lúc 15h00, các cửa hàng bán lẻ xăng dầu của Tập đoàn xăng dầu Việt Nam Petrolimex đồng loạt điều chỉnh giảm giá xăng dầu bán lẻ, theo đó mức giảm đối với xăng A92 được điều chỉnh lần này là 370 đồng/ 1lít.
                                   
                                            </p>
                                            <div class="time">Ngày đăng: 04/01/2016 21:53</div>
                                        </div>

                                    </li>
                                    <li>
                                        <div class="thumb">
                                            <a href="/tin-tuc/taxi-24h-ra-mat-san-pham-taxi-eco-4808.htm" title="Taxi 24h ra mắt sản phẩm Taxi Eco ">
                                                <img src="http://admin.taxi24h.vn/upload/images/20151207231705546.png" alt="Taxi 24h ra mắt sản phẩm Taxi Eco " title="Taxi 24h ra mắt sản phẩm Taxi Eco ">
                                            </a>
                                        </div>
                                        <div class="info-detail">
                                            <a href="/tin-tuc/taxi-24h-ra-mat-san-pham-taxi-eco-4808.htm" title="Taxi 24h ra mắt sản phẩm Taxi Eco " class="tieu-de">Taxi 24h ra mắt sản phẩm Taxi Eco </a>
                                            <p class="sapo">
                                                Ra đời trên 20 năm hoạt động vận tải Taxi tại Thủ đô, với thương hiệu mạnh đã được sự ghi nhận của nhiều khách hàng lớn và danh tiếng, đồng thời được sự tín nhiệm của đông đảo người dân thủ đô, trong nhiều năm qua Taxi Group tập chung ở phân khúc xe Taxi sang trọng với dòng xe Toyota Vios và Toyota Innova. Để mang đến khách hàng nhiều sự lựa chọn, Taxi 24h chính thức ra mắt sản phẩm Taxi Eco, với chất lượng dịch vụ tốt, giá thành cạnh tranh.
                                   
                                            </p>
                                            <div class="time">Ngày đăng: 07/12/2015 23:17</div>
                                        </div>

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
