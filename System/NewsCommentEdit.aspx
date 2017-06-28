<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="NewsCommentEdit.aspx.cs" Inherits="System_NewsCommentEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tiêu đề :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            Nội dung :
        </div>
        <div class="AdminRightItem" style="display:table;">
            <asp:TextBox ID="txtShortContent" TextMode="MultiLine" Rows="1" runat="server" class="AdminTextControl" ></asp:TextBox>
        </div>
    </div>
</asp:Content>