﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SanPhamDichVu.ascx.cs" Inherits="Controller_SanPhamDichVu" %>
<% if (lengNews > 0){ %>
    <!-- KHOI THU 4 - TRAI NGHIEM SAN PHAM, DICH VU -->
    <div style="margin: auto; margin-top: -10px;">
        <div style="min-height: 105px; color: #7e787e; font-size: 30px; font-weight: bold; text-align: center; padding-top: 15px;">
            TRẢI NGHIỆM SẢN PHẨM, DỊCH VỤ
        </div>

        <div>
            <div class="row">
                <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="col-md-3 col-sm-6">
                            <div class="serviceBox">
                                <div class="service-icon">
                                    <img style="margin-top: -40px; width: 100%;" src="<%# Eval("IMG") %>" alt="<%# Eval("TITLE") %>">
                                </div>
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
    <!-- KET THUC KHOI THU 4 -->
<% } %>