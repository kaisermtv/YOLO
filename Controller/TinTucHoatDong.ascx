<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TinTucHoatDong.ascx.cs" Inherits="Controller_TinTucHoatDong" %>
<% if (lengNews > 0)
   { %>
<!-- KHOI THU 5 - TIN TUC -->
<div id="site-content">
    <section class="flat-row popup pad-top70px pad-bottom70px">
        <div class="container">
            <div class="phoneHeader" id="newsHeader" style="min-height: 65px; background-color: #2c90f7; color: #fff; font-size: 30px; font-weight: bold; text-align: center; padding-top: 12px; margin-bottom: 30px;">
                TIN TỨC, SỰ KIỆN
            </div>

            <div class="flat-divider d50px"></div>

            <div class="row">
                <div class="col-md-4" style="margin-bottom: 20px">
                    <a href="<%= link %>">
                        <img onerror="imgCatchError(this)" src="<%= image %>" style="width: 100%" alt="image"></a>

                    <!-- /.images-single-flexslider -->
                </div>
                <!-- /.col-md-4 -->

                <div class="col-md-4">
                    <div class="flat-about-us" style ="text-align:justify;">
                        <a href="<%= link %>">
                            <p><span class="dropcap"><%=beginChar %></span><%=title %></p>
                        </a>
                        <br />
                        <p><%=describe %></p>
                        <a class="button white" href="<%= link %>">Xem chi tiết</a>
                    </div>
                    <!-- /.flat-about-us -->
                </div>
                <!-- /.col-md-4 -->

                <div class="col-md-4">
                    <div class="flat-progress-bar">
                        <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <div class="flat-progress" style ="text-align:justify;">

                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>">
                                        <img onerror="imgCatchError(this)" src="<%#Eval("ImgUrl")%>" style="width:80px;float:left;margin-bottom:10px" />
                                        <p class="name" style="float:right;margin-left:-90px;padding-left:90px;width:100%;"><%# Eval("Title") %></p>
                                    </a>
                                    <div class="progress-bar" data-percent="90" data-waypoint-active="yes">
                                        <div class="progress-animate"></div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- /.flat-progress -->
                </div>
                <!-- /.col-md-4 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>
    <!-- /.flat-row -->

</div>
<!-- KET THUC KHOI THU 5 -->
<% } %>