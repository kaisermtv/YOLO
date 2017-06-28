<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="NewsGroupEdit.aspx.cs" Inherits="System_NewsGroupEdit" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tên nhóm:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display:table">
        <div class="AdminLeftItem">
            Mô tả:
        </div>
        <div class="AdminRightItem" style="display:table">
            <asp:TextBox ID="txtDescribe"  runat="server" class="AdminTextControl" TextMode="MultiLine" style="resize:vertical"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Trạng thái:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlTrangThai" runat="server" class="AdminTextControl">
                <asp:ListItem Value="1">Chia sẻ</asp:ListItem>
                <asp:ListItem Value="2">Lưu trữ</asp:ListItem>
                <asp:ListItem Value="3">Ẩn danh mục</asp:ListItem>
                <asp:ListItem Value="0">-/-</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>


    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSaver" runat ="server" CssClass="btn btn-primary" Text="Ghi Nhận" OnClick="btnSaver_Click" />
            <a href="/System/NewsGroupList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>

</asp:Content>

