<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="MenuEdit.aspx.cs" Inherits="System_MenuEdit" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Thư mục cha:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlGroup" runat="server" class="AdminTextControl"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tên menu:
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

    <div class="AdminItem" style="display:table">
        <div class="AdminLeftItem">
            Link:
        </div>
        <div class="AdminRightItem" style="display:table">
            <asp:TextBox ID="txtLink" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSaver" runat ="server" CssClass="btn btn-primary" Text="Ghi Nhận" OnClick="btnSaver_Click" />
            <a href="/System/Menu.aspx?id=<%= ddlGroup.SelectedValue  %>&type=<%=menuid %>" class="btn btn-default">Thoát</a>
            <a href="/System/MenuNew.aspx?pid=<%= ddlGroup.SelectedValue %>&type=<%=menuid %>" class="btn btn-danger" style="float:right">Thêm mới</a>
        </div>
    </div>

</asp:Content>


