﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="GroupAcctList.aspx.cs" Inherits="System_GroupAcctList" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 20%;">Tên nhóm</th>
                    <th class="DataListTableHeaderTdItemJustify">Mô tả</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NAME") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("DESCRIBE") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("STATUS") %></td>
                <td class="DataListTableTdItemCenter">
                    <a href="GroupAccountEdit.aspx?id=<%# Eval("ID") %>">
                        <img src="/Images/Edit.png" alt=""></a>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="GroupAccountDel.aspx?id=<%# Eval("ID") %>">
                        <img src="/Images/delete.png" alt=""></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
</asp:Content>
