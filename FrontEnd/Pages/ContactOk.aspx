<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../App_Master/Site.master" CodeFile="ContactOk.aspx.cs" Inherits="FrontEnd_Pages_ContactOk" %>

<%@ Register TagPrefix="uc1" TagName="QuangCao" Src="~/FrontEnd/Controls/Common/QuangCao.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="main contact-w">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div class="BodyTitle">
                        LIÊN HỆ
           
                    </div>
                    <br>
                    <p>
                        Các tổ chức, cá nhân cần liên hệ với <%= this.getValue("Name") %>, vui lòng liên hệ với chúng tôi theo các thông tin sau:
                    </p>
                    <br>
                    <p style="font-weight: bold; font-size: 15px;"><%= this.getValue("Name") %></p>
                    <p style="font-size: 13.5px; ">Địa chỉ: <%= this.getValue("Address") %></p>
                    <p style="font-size: 13.5px;">Điện thoại: <%= this.getValue("Phone") %></p>
                    <p style="font-size: 13.5px; ">Email: <%= this.getValue("Email") %></p>
                    <p style="font-size: 13.5px; ">Hotline: <%= this.getValue("Hotline") %></p>
                    <br>
                    <p style="margin-top: -5px;">
                        Cảm ơn bạn đã gởi thông tin cho chúng tôi. Chúng tôi sẽ cố gắng trả lời bạn sớm nhất.
                    </p>
                    <br>
                </div>
                <div class="hidden-xs hidden-sm col-md-4 col-lg-4">
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
