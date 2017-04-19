<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="PhotoContestList.aspx.cs" Inherits="FrontEnd_Pages_PhotoContestList" %>


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

                        <label>Danh sách thí sinh</label>
                        <div class="row">

                            <asp:Repeater ID="YoLoSlide" runat="server">
                                <ItemTemplate>
                                    <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                        <a href="/<%# SystemClass.convertToUnSign2(Eval("user_name").ToString()) %>-p<%#Eval("id")%>" class="PhotoContestPerson">
                                            <div class="img-w person">
                                                <img src="<%#Eval("picture")%>" />
                                            </div>
                                            <div class="person-detail">
                                                <h3><%#Eval("user_name")%></h3>
                                                <p>Ngày sinh: <%#Eval("user_birthday")%></p>
                                                <p>Đến từ: <%#Eval("user_address")%></p>
                                            </div>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>

                </div>
                <div class="hidden-xs hidden-sm col-md-4 col-lg-4">
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
