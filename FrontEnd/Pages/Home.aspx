﻿<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="FrontEnd_Pages_Home" %>

<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register TagPrefix="uc1" TagName="Banner" Src="~/FrontEnd/Controls/Common/Banner.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <div class="YoloWraper container-fluid">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="main">
                        <uc1:Banner runat="server" ID="Banner" />
                    </div>
                </div>
            </div>
        </div>
    <div id="slide-w">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="main">
                        <h3>Cuộc thi ảnh đẹp</h3>
                        <div class="line"></div>
                        <div class="swiper-container">
                            <div class="swiper-wrapper">
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                                <div class="swiper-slide">
                                    <div class="img-w person">
                                        <img src="../../../../images/Front-End/person.png" />
                                    </div>
                                    <div class="person-detail">
                                        <h3>An Khánh</h3>
                                        <p>Ngày sinh: 28/03/1991</p>
                                        <p>Đến từ: Nghệ An</p>
                                    </div>
                                    <a href="#" class="person-nav"></a>
                                </div>
                            </div>
                            <!-- Add Pagination -->
                            <div class="swiper-pagination"></div>
                            <!-- Add Arrows -->
                            <div class="swiper-button-next"></div>
                            <div class="swiper-button-prev"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="main">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8" id="news">
                    <h3>Tin tức</h3>
                    <div class="line"></div>
                    <ul class="lst-news">
                        <li>
                            <div class="img-w">
                                <img src="../../images/Front-End/banner-1.png" alt="" />
                            </div>
                            <div class="lst-news-detail">
                                <a class="title" href="#">Nếu nhà nước không thu phí, bảo kê sẽ thu tiền sử dụng vỉa hè</a>
                                <i>27/03/2017</i>
                                <p>Tiến sĩ Lương Hoài Nam, chuyên gia giao thông khẳng định nếu nhà nước không cho thuê vỉa hè để thu phí thì sẽ có lực lượng ‘bảo kê’ ngầm đến thu tiền của...</p>
                                <a href="#" class="view-more"></a>
                            </div>
                        </li>
                        <li>
                            <div class="img-w">
                                <img src="../../images/Front-End/banner-1.png" alt="" />
                            </div>
                            <div class="lst-news-detail">
                                <a class="title" href="#">Nếu nhà nước không thu phí, bảo kê sẽ thu tiền sử dụng vỉa hè</a>
                                <i>27/03/2017</i>
                                <p>Tiến sĩ Lương Hoài Nam, chuyên gia giao thông khẳng định nếu nhà nước không cho thuê vỉa hè để thu phí thì sẽ có lực lượng ‘bảo kê’ ngầm đến thu tiền của...</p>
                                <a href="#" class="view-more"></a>
                            </div>
                        </li>
                        <li>
                            <div class="img-w">
                                <img src="../../images/Front-End/banner-1.png" alt="" />
                            </div>
                            <div class="lst-news-detail">
                                <a class="title" href="#">Nếu nhà nước không thu phí, bảo kê sẽ thu tiền sử dụng vỉa hè</a>
                                <i>27/03/2017</i>
                                <p>Tiến sĩ Lương Hoài Nam, chuyên gia giao thông khẳng định nếu nhà nước không cho thuê vỉa hè để thu phí thì sẽ có lực lượng ‘bảo kê’ ngầm đến thu tiền của...</p>
                                <a href="#" class="view-more"></a>
                            </div>
                        </li>
                        <li>
                            <div class="img-w">
                                <img src="../../images/Front-End/banner-1.png" alt="" />
                            </div>
                            <div class="lst-news-detail">
                                <a class="title" href="#">Nếu nhà nước không thu phí, bảo kê sẽ thu tiền sử dụng vỉa hè</a>
                                <i>27/03/2017</i>
                                <p>Tiến sĩ Lương Hoài Nam, chuyên gia giao thông khẳng định nếu nhà nước không cho thuê vỉa hè để thu phí thì sẽ có lực lượng ‘bảo kê’ ngầm đến thu tiền của...</p>
                                <a href="#" class="view-more"></a>
                            </div>
                        </li>
                    </ul>
                    <div class="row" id="news-r">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>Sống nơi công sở</h3>
                            <ul class="news-r-detail">
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>LET’S WORK</h3>
                            <ul class="news-r-detail">
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>Cafe lắng</h3>
                            <ul class="news-r-detail">
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                            </ul>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>Du lịch</h3>
                            <ul class="news-r-detail">
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                                <li>
                                    <div class="img-w">
                                        <img src="../../images/Front-End/banner-1.png" alt="" />
                                    </div>
                                    <label>Bí kíp giải quyết những lời nhờ...</label>
                                    <p>Khi đi làm bạn khó mà tránh được những lời nhờ vả của đồng nghiệp xung quanh. Lời nhờ vả như thế nào và bao giờ thì bạn nên chấp nhận? Hãy cùng lắng...</p>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4" id="quangcao">
                    <h3>Mobifone công sở</h3>
                    <a href="#" class="news">
                        <div class="img-w">
                            <img src="../../images/Front-End/banner-1.png" alt="" />
                        </div>
                        <p>Hoa anh đào Nhật Bản khoe sắc bên Hồ Gươm</p>
                    </a>
                    <uc1:QuangCao runat="server" ID="QuangCao1" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
