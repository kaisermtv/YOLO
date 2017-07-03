<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMucTin.ascx.cs" Inherits="Controller_DanhMucTin" %>

<div id="danhmuc-tintuc">
    <div class="header">Danh mục tin tức - sự kiện</div>
    <ul>
        <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">

            <ItemTemplate>
                <li>
                    <div class="zc<%# (itemId == (int)Eval("ID"))?" active":"" %>" id="<%# Eval("NAME") %>">
                        <a href="/<%# SystemClass.convertToUnSign2(Eval("NAME").ToString()) %>-cat<%# Eval("ID") %>"><%# Eval("NAME") %></a>
                    </div>
                </li>
            </ItemTemplate>

        </asp:Repeater>
    </ul>
</div>
