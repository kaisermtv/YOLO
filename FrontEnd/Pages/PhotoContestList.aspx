<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="PhotoContestList.aspx.cs" Inherits="FrontEnd_Pages_PhotoContestList" %>


<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register Src="~/FrontEnd/Controls/PhotoContest/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <div id="fb-root"></div>
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.9&appId=1929429900621768";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <div class="container-fluid">
        <div class="row">
            <div class="main">
                <div class="cleft col-xs-12 col-sm-12 col-md-8 col-lg-8 ">
                    <div id="PhotoContest">
                        <h3>Cuộc thi ảnh Yolo - Dám chia sẻ</h3>
                        <p class="sapo">
                            Cuộc thi dành cho giới trẻ 4 Tỉnh miền trung Nghệ An, Thanh Hóa, Hà Tĩnh và Quảng Bình. Tự tin sống cá tính
                            <br />
                            Tích cực chia sẻ vì cộng đồng. YOLO- dám chia sẻ
                        </p>

                        <label>Danh sách thí sinh</label>
                        <div class="row">
                            <uc1:List runat="server" ID="ListPhotoContest" />
                        </div>
                    </div>
                    <br />

                    <hr />
                    <div class="likes fb-rm">
                        &nbsp;&nbsp;
                        Yolo-Dám chia sẻ đã nhận được &nbsp;&nbsp;
                    <a href="#">
                        <i class="fa fa-thumbs-o-up" aria-hidden="true"></i>
                        <%=new FbPhotoAlbum().countLikes() %> lượt thích
                    </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <a href="#">
                             <i class="fa fa-comments" aria-hidden="true"></i>
                             <%=new FbPhotoAlbum().countComments() %> lượt bình luận
                         </a>
                    </div>
                    <hr />
                    Bình luận 
                    <br />
                    <div class="fb-comments" data-href="https://www.facebook.com/pg/yolodamchiase/photos/?tab=album&album_id=271257546655466" data-width="800" data-numposts="5"></div>
                </div>
                <div class="cright hidden-xs   col-sm-12 col-md-4 col-xs-4" style="margin-top: 20px;">
                    <uc1:DanhMuc runat="server" ID="DanhMuc" />
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        if ($(window).width() > 768) {
            var heightNewsR = 0;
            var countNewsR = 0;
            var lenghtNewsR = $('.person-detail').length;
            setTimeout(function () {
                $('.news-r-detail li:first-child').each(function (i, item) {
                    if ($(item).height() > heightNewsR) {
                        heightNewsR = $(item).height();

                    }

                    countNewsR++;
                    if (countNewsR == lenghtNewsR) {
                        $('.person-detail').height(heightNewsR);
                    }
                });

            }, 500);
        }
    </script>
</asp:Content>
