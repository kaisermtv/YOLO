<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="FrontEnd_Pages_News_Detail" %>


<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">


    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 " style="padding-top: 20px;">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12">
                                    <label class="time">Ngày đăng: 21/04/2016 11:01:01 AM</label>

                                    <h3 class="tieu-de" style="margin-top: 10px; margin-bottom: 10px"><%= objData["Title"] %></h3>
                                    <p class="sapo" style="font-weight: bold; margin-bottom: 10px; font-size: 16px;">
                                        Đỗ xe kiểu Paradel Parking khá thách thức đối với các tay lái mới cầm vô lăng, nó đòi hỏi kỹ năng quan sát và óc tư duy đánh lái logic của người lái xe. Tuy nhiên chỉ với 7 bước cơ bản, Taxi Noi Bai gửi đến các bạn cách tiếp cận dễ nhất, đảm bảo ai cũng có thể làm được sau khi đọc hướng dẫn này !
                           
                                    </p>
                                    <div class="content-detail">

                                        <center></center>
                                        <br>
                                        <br>
                                        <p><span style="font-size: 14px"><strong>Bước 1:</strong></span></p>

                                        <p style="text-align: center">
                                            <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.1.jpg" style="height: 735px; width: 317px">
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Bước 2:&nbsp;</strong></span></p>

                                        <p style="text-align: center">
                                            <span style="font-size: 14px"><strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.2.jpg" style="height: 735px; width: 320px"></strong></span>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Bước 3:&nbsp;</strong></span></p>

                                        <p style="text-align: center">
                                            <strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.3.jpg" style="height: 735px; width: 324px"></strong>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><strong><span style="font-size: 14px">Bước 4:&nbsp;</span></strong></p>

                                        <p>&nbsp;</p>

                                        <p style="text-align: center">
                                            <strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.4.jpg" style="height: 735px; width: 341px"></strong>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><strong><span style="font-size: 14px">Bước 5:&nbsp;</span></strong></p>

                                        <p>&nbsp;</p>

                                        <p style="text-align: center">
                                            <strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.5.jpg" style="height: 735px; width: 373px"></strong>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Bước 6:</strong></span></p>

                                        <p>&nbsp;</p>

                                        <p style="text-align: center">
                                            <strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.6.jpg" style="height: 733px; width: 378px"></strong>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Bước 7:&nbsp;</strong></span></p>

                                        <p>&nbsp;</p>

                                        <p style="text-align: center">
                                            <strong>
                                                <img alt="" src="http://admin.taxi24h.vn/Upload/Images/paradelparking1.7.jpg" style="height: 735px; width: 363px"></strong>
                                        </p>

                                        <p style="text-align: center">&nbsp;</p>

                                        <p><span style="font-size: 16px"><strong>Lưu ý:&nbsp;</strong></span></p>

                                        <p>&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Nguyên lý:&nbsp;</strong>Khi lùi xe là 2 lần quay compass&nbsp;sao cho xe không chạm vào góc sau - ngoài của xe phía trước.</span></p>

                                        <p>&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Mẹo:&nbsp;</strong></span></p>

                                        <p><span style="font-size: 14px">- Ở bước 1: Khoảng cách giữa 2 xe là 20 cm. Tăng hoặc giảm đều dẫn tới việc phải điều chỉnh ở các bước sau.&nbsp;</span></p>

                                        <p>&nbsp;</p>

                                        <p><span style="font-size: 14px">- Xác định vị trí bánh sau phải ở bước 2: bánh sau thường tương ứng với ô cửa sổ nhỏ ở hàng ghế sau.</span></p>

                                        <p>&nbsp;</p>

                                        <p><span style="font-size: 14px"><strong>Taxi Noi Bai</strong> chúc các bạn thực hiện thành công cách đỗ xe này !</span></p>

                                        <p>&nbsp;</p>


                                    </div>

                                </div>
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
