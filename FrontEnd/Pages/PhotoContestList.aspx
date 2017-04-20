<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="PhotoContestList.aspx.cs" Inherits="FrontEnd_Pages_PhotoContestList" %>


<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register Src="~/FrontEnd/Controls/PhotoContest/List.ascx" TagPrefix="uc1" TagName="List" %>







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
                            <uc1:List runat="server" ID="ListPhotoContest" />
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
