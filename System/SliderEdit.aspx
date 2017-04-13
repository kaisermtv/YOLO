<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="SliderEdit.aspx.cs" Inherits="System_SliderEdit" %>


<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tiêu đề:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserName" runat="server" class="AdminTextControl"></asp:TextBox>
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
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSaver" runat ="server" CssClass="btn btn-primary" Text="Ghi Nhận" OnClick="btnSaver_Click" />
            <a href="/System/SliderList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>

</asp:Content>

