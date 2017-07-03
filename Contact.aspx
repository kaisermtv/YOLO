<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #MainContent_UpdatePanel {
            display: block;
            margin: 0 auto;
            padding: 30px;
        }

            #MainContent_UpdatePanel input[type="text"],
            #MainContent_UpdatePanel input[type="email"] {
                height: 40px;
                margin-bottom: 20px;
                border-radius: 0;
                border: none;
                box-shadow: none;
                border-bottom: 1px solid #ccc;
            }

            #MainContent_UpdatePanel textarea {
                margin-bottom: 20px;
                border-radius: 0;
                border: none;
                box-shadow: none;
                border-bottom: 1px solid #ccc;
            }

            #MainContent_UpdatePanel input[type="submit"] {
            }

        .BodyTitle {
            color: #337ab7;
            font-size: 30px;
            text-overflow: ellipsis;
            font-family: CondBold;
            display: inline-block;
            width: 100%;
            margin: 30px 0 10px;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="main contact-w">
                <div class="col-xs-12 col-sm-12 ">
                    <div class="BodyTitle">
                        LIÊN HỆ
                   
                    </div>
                    <br />
                    <p style="text-align: justify;">
                        Các tổ chức, cá nhân cần liên hệ với <%= this.getValue("Name") %>, vui lòng liên hệ với chúng tôi theo các thông tin sau:
                   
                    </p>
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
                    <div id="MainContent_UpdatePanel" class="MainContent_UpdatePanel">
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
            </div>
        </div>
    </div>
</asp:Content>
