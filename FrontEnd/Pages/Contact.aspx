<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/App_Master/Site.master" CodeFile="Contact.aspx.cs" Inherits="FrontEnd_Pages_Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="BodyTitle">
                LIÊN HỆ
            </div>
            <br />
            <p>
                Các tổ chức, cá nhân cần liên hệ với Nhà sách Yến Công, vui lòng liên hệ với chúng tôi theo các thông tin sau:
            </p>
            <br />
            <p style="font-weight: bold; font-size: 15px;"><% Response.Write(this.strHtmlName.ToUpper()); %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Địa chỉ: <% Response.Write(this.strHtmlAddress); %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Điện thoại: <% Response.Write(this.strHtmlPhone); %></p>
            <p style="font-size: 13.5px; margin-top: -8px;">Email: <% Response.Write(this.strHtmlEmail); %></p>
            <br />
            <p style="margin-top: -5px;">
                Hoặc gửi thông tin liên hệ trực tiếp về cho chúng tôi theo mẫu sau đây
            </p>
            <br />
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">THÔNG TIN LIÊN HỆ</h3>
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon1">@</span>
                            <input type="text" style="width: 98%; max-width: 1000px !important;" id="txtFullName" onkeyup="validate()" class="form-control" runat="server" placeholder="Họ và tên" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon2">@</span>
                            <input type="email" style="width: 98%; max-width: 1000px !important;" id="txtEmail" onkeyup="validate()" class="form-control" runat="server" placeholder="Địa chỉ email" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon3">@</span>
                            <input type="text" style="width: 98%; max-width: 1000px !important;" id="txtTitle" onkeyup="validate()" class="form-control" runat="server" placeholder="Tiêu đề" aria-describedby="basic-addon1">
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <span class="input-group-addon" id="basic-addon4">@</span>
                            <textarea style="width: 98%;" id="txtQuestion" onkeyup="validate()" class="form-control" runat="server" placeholder="Nội dung liên hệ" rows="6" aria-describedby="basic-addon1"></textarea>
                        </div>
                        <br />
                        <div class="input-group" style="padding-left: 15px;">
                            <asp:Button ID="btnSend" CssClass="btn btn-default" Enabled="false" Style = "width:100px;" runat="server" Text="Gửi câu hỏi" OnClick="btnSend_Click" />
                            <button type="reset" runat="server" class="btn btn-default">Xóa trắng</button>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                        <br />
                    </div>
</asp:Content>