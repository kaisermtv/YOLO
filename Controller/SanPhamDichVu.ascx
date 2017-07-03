<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SanPhamDichVu.ascx.cs" Inherits="Controller_SanPhamDichVu" %>
<% if (lengNews > 0)
   { %>
<!-- KHOI THU 4 - TRAI NGHIEM SAN PHAM, DICH VU -->
<div class="container">
    <div style="margin: auto; margin-top:30px;">
        <div class="phoneHeader" id="phoneHeader" style="min-height: 65px; background-color:#2c90f7; color: #fff; font-size: 30px; font-weight: bold; text-align: center; padding-top: 5px; margin-bottom:30px;">
            TRẢI NGHIỆM SẢN PHẨM, DỊCH VỤ
        </div>
        <div style="overflow: hidden;">
            <div class="row">
                <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="col-md-3 col-sm-6">
                            <div style="width: 100%; position: relative;">
                                <img class="serviceBoxIMG" src="<%# Eval("IMG") %>" alt="<%# Eval("TITLE") %>">
                            </div>
                            <div class="serviceBox">
                                <%--<div class="service-icon">
                                    <img style="margin-top: -40px; width: 100%;" src="<%# Eval("IMG") %>" alt="<%# Eval("TITLE") %>">
                                </div>--%>
                                <div class="service-content">
                                    <h3 class="title"><%# Eval("TITLE") %></h3>
                                    <p class="description">
                                        <%# Eval("DESCRIBE").ToString().Replace("\n","<br />") %>
                                    </p>
                                </div>
                                <a href="<%# Eval("LINK") %>" class="read">Chi tiết</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</div>
<!-- KET THUC KHOI THU 4 -->
<% } %>