<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMuc.ascx.cs" Inherits="FrontEnd_Controls_News_DanhMuc" %>


<div id="danhmuc-tintuc">
    <div class="header">Danh mục tin tức - sự kiện</div>
    <ul>
        <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">

            <ItemTemplate>
                <li>
                    <div class="zc" id="<%# Eval("NAME") %>">
                        <a href="/<%# SystemClass.convertToUnSign2(Eval("NAME").ToString()) %>-cat<%# Eval("ID") %>"><%# Eval("NAME") %></a>
                    </div>
                </li>
            </ItemTemplate>

        </asp:Repeater>
    </ul>
</div>
<script>
    var UrlCatTabRight = $("#UrlCat").val();
    $("#danhmuc-tintuc ul li #" + UrlCatTabRight).addClass("active");
</script>
