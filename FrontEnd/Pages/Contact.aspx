<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../App_Master/Site.master" CodeFile="Contact.aspx.cs" Inherits="FrontEnd_Pages_Contact" %>

<%@ Register TagPrefix="uc1" TagName="QuangCao" Src="~/FrontEnd/Controls/Common/QuangCao.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="main contact-w">
                <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div class="BodyTitle">
                        LIÊN HỆ
           
                    </div>
                    <br />
                    <p>
                        Các tổ chức, cá nhân cần liên hệ với <%= this.getValue("Name") %>, vui lòng liên hệ với chúng tôi theo các thông tin sau:
                    </p>
                    <br />
                    <p style="font-weight: bold; font-size: 15px;"><%= this.getValue("Name") %></p>
                    <p style="font-size: 13.5px;">Địa chỉ: <%= this.getValue("Address") %></p>
                    <p style="font-size: 13.5px;">Điện thoại: <%= this.getValue("Phone") %></p>
                    <p style="font-size: 13.5px;">Email: <%= this.getValue("Email") %></p>
                    <p style="font-size: 13.5px;">Hotline: <%= this.getValue("Hotline") %></p>
                    <br />
                    <p style="margin-top: -5px;">
                        Hoặc gửi thông tin liên hệ trực tiếp về cho chúng tôi theo mẫu sau đây: 
                    </p>
                    <br />
                    <div id="MainContent_UpdatePanel">
                        <form method="post">
                            <div class="">
                                <input name="name" class="form-control" placeholder="Họ và tên" type="text" />
                                <input name="email" class="form-control" placeholder="Địa chỉ email" type="email" />
                                <input name="title" class="form-control" placeholder="Tiêu đề" type="text" />
                                <textarea name="noidung" class="form-control" placeholder="Nội dung liên hệ" rows="6"></textarea>
                                <div class="input-group">
                                    <input type="submit" value="Gửi câu hỏi" class="aspNetDisabled btn btn-default" style="width: 100px;" />
                                    <span id="lblMsg" style="color: Red;"><%=msg %></span>
                                </div>
                            </div>
                        </form>
                    </div>
                    <br />
                </div>
                <div class="hidden-xs hidden-sm col-md-4 col-lg-4" style="margin-top: 20px;">
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
