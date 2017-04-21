<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="FrontEnd_Pages_Contact" %>

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
                        Hoặc gửi thông tin liên hệ trực tiếp về cho chúng tôi theo mẫu sau đây
                    </p>
                    <br>
                    <div id="MainContent_UpdatePanel">
                        <form method="post">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">THÔNG TIN LIÊN HỆ</h3>
                            </div>
                            <br>
                            <div class="input-group" style="padding-left: 15px;">
                                <span class="input-group-addon" id="basic-addon1">@</span>
                                <input name="name" style="width: 98%; max-width: 1000px !important;" class="form-control" placeholder="Họ và tên" aria-describedby="basic-addon1" type="text">
                            </div>
                            <br>
                            <div class="input-group" style="padding-left: 15px;">
                                <span class="input-group-addon" id="basic-addon2">@</span>
                                <input name="email" style="width: 98%; max-width: 1000px !important;" class="form-control" placeholder="Địa chỉ email" aria-describedby="basic-addon1" type="email">
                            </div>
                            <br>
                            <div class="input-group" style="padding-left: 15px;">
                                <span class="input-group-addon" id="basic-addon3">@</span>
                                <input name="title" style="width: 98%; max-width: 1000px !important;" class="form-control" placeholder="Tiêu đề" aria-describedby="basic-addon1" type="text">
                            </div>
                            <br>
                            <div class="input-group" style="padding-left: 15px;">
                                <span class="input-group-addon" id="basic-addon4">@</span>
                                <textarea name="noidung" style="width: 98%;" class="form-control" placeholder="Nội dung liên hệ" rows="6" aria-describedby="basic-addon1"></textarea>
                            </div>
                            <br>
                            <div class="input-group" style="padding-left: 15px;">
                                <input type="submit" value="Gửi câu hỏi" class="aspNetDisabled btn btn-default" style="width: 100px;">
                                <button type="reset" class="btn btn-default">Xóa trắng</button>
                                <span id="lblMsg" style="color: Red;"><%=msg %></span>
                            </div>
                            <br>
                        </div>
                        </form>
                    </div>
                    <br>
                </div>
                <div class="hidden-xs hidden-sm col-md-4 col-lg-4">
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
