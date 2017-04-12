<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="ChangPass.aspx.cs" Inherits="System_ChangPass" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tài khoản:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserName" runat="server" class="AdminTextControl" ReadOnly="true"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Mật khẩu:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPassword" type="password" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Nhập lại mật khẩu:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPassword2" type="password" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSaver" runat ="server" CssClass="btn btn-primary" Text="Ghi Nhận" OnClick="btnSaver_Click" />
            <a href="/System/ListAccount.aspx" class="btn btn-default">Thoát</a>
            <a href="/System/AccountEdit.aspx?id=<%= itemId %>" class="btn btn-danger">Đổi thông tin tài khoản</a>
        </div>
    </div>

</asp:Content>

