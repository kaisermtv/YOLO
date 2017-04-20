<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="PhotoContest.aspx.cs" Inherits="FrontEnd_Pages_PhotoContest" %>

<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="main">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div id="PhotoContest">
                        <h3>Cuộc thi ảnh Yolo - Dám chia sẻ</h3>
                        <p class="sapo">
                            Cuộc thi dành cho giới trẻ 4 Tỉnh miền trung Nghệ An, Thanh Hóa, Hà Tĩnh và Quảng Bình. Tự tin sống cá tính
                            <br />
                            Tích cực chia sẻ vì cộng đồng. YOLO- dám chia sẻ
                        </p>
                        <div class="img-w">
                            <img src="https://scontent.fhan4-1.fna.fbcdn.net/v/t1.0-9/17904263_284664605314760_4431628831004374782_n.jpg?oh=d45b1eebb3844aa1aac091c1ef9addde&oe=594F7A9D" alt="Yolo chia sẻ đam mê" />
                        </div>
                        <label><span>Họ tên: </span>Hồ Thị Nguyệt Hằng</label>
                        <label><span>Ngày sinh:</span>27/06/1998</label>
                        <label><span>Đến từ:</span> Nghệ An</label>
                        <p>Những điều chúng ta nghĩ quyết định những điều sẽ xảy ra với chúng ta, và vì thế nếu chúng ta muốn thay đổi cuộc sống, chúng ta cần phải thay đổi từ cách suy nghĩ của chúng ta. " Cuộc sống không cho bạn tất cả những gì bạn mơ ước, nhưng cuộc sống cho bạn quyền được thực hiện nó ".Cuộc sống có vô vàn điều kì diệu và tuyệt vời. Dù ta có sống hết cuộc đời cũng chưa chắc trải nghiệm được hết. Cuộc sống vì thế rất muôn màu và sặc sỡ. Hãy luôn yêu đời và yêu những người đáng mến ở chung quanh. Một khi yêu thương được trao đi, tâm hồn bạn là một vườn hoa trái. ^^ </p>
                        <div class="comment-w">
                        </div>
                    </div>


                    <h3 class="" style="font-size: 24px; font-family: CondBold; display: inline-block; width: 100%; margin-top: 40px; margin-bottom: 10px;">Bài thi liên quan</h3>
                    <ul id="PhotoContestList">
                        <li>
                            <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                    <div class="img-w">
                                        <a href="#"><img src="https://scontent.fhan4-1.fna.fbcdn.net/v/t1.0-9/17499489_272995456481675_4364065248420784381_n.jpg?oh=589ffda603f3808804ae3a21c0aa3cf4&oe=5984A059" alt="Yolo chia sẻ đam mê" /></a>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">

                                    <div class="PhotoContest-rt">
                                        <div class="PhotoContest-rt-m">
                                            <a href="javascript:;">
                                                <img src="/images/Front-End/logo.png" />
                                            </a>
                                            <label>Yolo- Dám chia sẻ</label>
                                            <div class="social">
                                                <div class="likes fb-rm">
                                                    <i class="fa fa-thumbs-o-up" aria-hidden="true"></i>
                                                    <span>100</span>
                                                </div>
                                                <div class="comments fb-rm">
                                                    <i class="fa fa-comments" aria-hidden="true"></i>
                                                    <span>100</span>
                                                </div>
                                                <div class="share fb-rm">
                                                    <i class="fa fa-share" aria-hidden="true"></i>
                                                    <span>100</span>
                                                </div>
                                            </div>
                                        </div>
                                        <label><span>Họ tên: </span>Hồ Thị Nguyệt Hằng</label>
                                        <label><span>Ngày sinh:</span>27/06/1998</label>
                                        <label><span>Đến từ:</span> Nghệ An</label>
                                        <p><%=Utils.GetSubStringNice("Những điều chúng ta nghĩ quyết định những điều sẽ xảy ra với chúng ta, và vì thế nếu chúng ta muốn thay đổi cuộc sống, chúng ta cần phải thay đổi từ cách suy nghĩ của chúng ta. \" Cuộc sống không cho bạn tất cả những gì bạn mơ ước, nhưng cuộc sống cho bạn quyền được thực hiện nó \".Cuộc sống có vô vàn điều kì diệu và tuyệt vời. Dù ta có sống hết cuộc đời cũng chưa chắc trải nghiệm được hết. Cuộc sống vì thế rất muôn màu và sặc sỡ. Hãy luôn yêu đời và yêu những người đáng mến ở chung quanh. Một khi yêu thương được trao đi, tâm hồn bạn là một vườn hoa trái. ^^".ToString(), 200) %></p>
                                        <div><a class="see-more" href="#">Xem thêm</a></div>
                                    </div>
                                </div>
                            </div>

                        </li>
                    </ul>
                </div>
                <div class="hidden-xs hidden-sm col-md-4 col-lg-4">
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
