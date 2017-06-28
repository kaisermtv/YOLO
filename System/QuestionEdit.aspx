<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="QuestionEdit.aspx.cs" Inherits="System_QuestionEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
     
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Câu hỏi :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    
    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            Mô tả :
        </div>
        <div class="AdminRightItem" style="display:table;">
            <asp:TextBox ID="txtContent" TextMode="MultiLine" Height="150px" runat="server" CssClass="AdminTextControl" ></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <a href="/System/QuestionList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>
</asp:Content>

