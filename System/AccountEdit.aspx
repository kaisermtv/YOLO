<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="AccountEdit.aspx.cs" Inherits="System_AccountEdit" %>

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
            &nbsp;&nbsp;Nhóm tài khoản:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlGroup" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Họ tên:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtFullName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Địa chỉ email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Năm sinh:
        </div>
        <div class="AdminRightItem">
            <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                <input type='text' class="AdminTextControl" id="txtNgaySinh" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>

            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker({
                        format: 'DD/MM/YYYY'
                    });
                });
            </script>

        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Giới tính:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlGioiTinh" runat="server" class="AdminTextControl">
                <asp:ListItem value="0" >Nam</asp:ListItem>
                <asp:ListItem value="1" >Nữ</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSaver" runat ="server" CssClass="btn btn-primary" Text="Ghi Nhận" OnClick="btnSaver_Click" />
            <a href="/System/AccountList.aspx" class="btn btn-default">Thoát</a>
            <a href="/System/ChangPass.aspx?id=<%= itemId %>" class="btn btn-danger">Đổi mật khẩu</a>
        </div>
    </div>

</asp:Content>

