<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="NewsCommentEdit.aspx.cs" Inherits="System_NewsCommentEdit" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <style>
        iframe{
            height:200px !important;
            max-height:200px  !important;
        }
    </style>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Người gửi:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtFullName" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Địa chỉ email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tỉnh thành:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTinhThanh" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tiêu đề:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            Nội dung:
        </div>
        <div class="AdminRightItem" style="display:table;">
            <asp:TextBox ID="txtQuestion" TextMode="MultiLine" ReadOnly="true" Rows="1" runat="server" class="AdminTextControl" Height="60px"></asp:TextBox>
        </div>
    </div>

    <%--<div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trả lời:
        </div>
        <div class="AdminRightItem" style="display:table;">
            <CKEditor:CKEditorControl ID="txtContent" CssClass="editor1" runat="server" Height="200" Width="100%" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
        </div>
    </div>--%>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Trả lời" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <a href="/System/ContactList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>
</asp:Content>
