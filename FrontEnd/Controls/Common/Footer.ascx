<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="FrontEnd_Controls_Common_Footer" %>


<div class="container-fluid" id="footer">
    <div class="main">
        <div class="row">
            <asp:Repeater ID="dtlFooter" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                        <ul class="footer-nav">
                            <li><a class="footer-no" href="<%# Eval("LINK") %>"><%# Eval("NAME") %></a></li>
                            <asp:Repeater ID="dtlFooterItem" DataSource='<%# getItemMenu((int)Eval("ID")) %>' runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <li><a href="<%# Eval("LINK") %>"><%# Eval("NAME") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="rvtd-m">
                    <div class="rvtd">Số người online : <%=Application["SoNguoiOnl"] %></div>
                    <div class="rvtd">Số người tham gia : <%=userRegis %></div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="container-fluid" id="copyright">
    <div class="main">
        © Copyright 2017 MobiFone. Bản beta đang xin giấy phép.
    </div>
</div>
