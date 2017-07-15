<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderTwo.ascx.cs" Inherits="Controller_SliderTwo" %>
<div class="container">
    <% if (lengSlider > 0)
       { %>
    <!-- KHOI SO 3 - SU KIEN AN TUONG -->

    <div id="SKAN">
        <%--        <div style="height: 115px; color: #7e787e; font-size: 30px; font-weight: bold; text-align: center; padding-top: 35px;">
            SỰ KIỆN ẤN TƯỢNG
        </div>--%>

        <div class="kai_banner_container clearfix">
            <div class="kai_banner_body clearfix">
                <asp:Repeater ID="dtlSlider" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <a href="<%# Eval("LINK") %>" style="width: 100%">
                            <%--<div style="z-index: 2; position: absolute; text-align: center; width: 100%; padding-top: 50px; white-space: normal!important; letter-spacing: 0px!important;">
                                    <div style="font-size: 30px; white-space: 0px!important; margin-bottom: 30px;"><%# Eval("TITLE") %></div>
                                    <div style="width: 100%; display: block; padding-left: 150px; padding-right: 150px; margin-bottom: 30px; font-size: 16px; height: 150px;">
                                        <%# Eval("DESCRIBE").ToString().Replace("\n","<br />") %>
                                    </div>
                                    <div style="width: 256px; height: 51px; padding-top: 14px; padding-left: 15px; text-align: justify; margin: auto; background-image: url('../Content/Images/buttonDetail1.png'); background-repeat: no-repeat;">
                                        Xem chi tiết &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Xem tất cả
                                    </div>
                                </div>--%>
                            <div style="z-index: 1; position: relative; width: 100%;">
                                <img src="<%# Eval("IMG") %>" style="width: 100%">
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="kai_banner_bottombtns hidden-xs hidden-sm">
                <asp:Repeater ID="dtlSliderSmall" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <%--<span <%# (index++ == 1)?"class=\"highlight\" ":"" %><%# "style='background-image: url(" + Eval("IMG") + ")'" %>></span>--%>
                        <img <%# (index++ == 1)?"class=\"highlight\" ":"" %> src="<%# Eval("IMG") %>" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <script src="/Scripts/jquery.kaibanner.js" type="text/javascript"></script>
        <script type="text/javascript">

            $('.kai_banner_container').kaiBanner({
                intervalTime: 3000,
                highlightClass: 'highlight'
            });
        </script>
    </div>
    <!--  KET THUC KHOI SO 3 -->
    <% } %>
</div>
