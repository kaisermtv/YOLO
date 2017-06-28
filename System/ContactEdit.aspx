<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="ContactEdit.aspx.cs" Inherits="System_ContactEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <style>
        iframe{
            height:200px !important;
            max-height:200px  !important;
        }
    </style>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Người gửi:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtFullName" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Địa chỉ email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tiêu đề:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Nội dung hỏi:
        </div>
        <div class="AdminRightItem" style="display:table;">
            <asp:TextBox ID="txtQuestion" TextMode="MultiLine" ReadOnly="true" Rows="1" runat="server" class="AdminTextControl" Height="60px"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trả lời:
        </div>
        <div class="AdminRightItem" style="display:table;">
            <CKEditor:CKEditorControl ID="txtContent" CssClass="editor1" runat="server" Height="200" Width="100%" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Trả lời" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <a href="/System/ContactList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>
</asp:Content>

