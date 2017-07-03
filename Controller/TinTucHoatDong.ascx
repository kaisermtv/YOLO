<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TinTucHoatDong.ascx.cs" Inherits="Controller_TinTucHoatDong" %>
<% if (lengNews > 0){ %>
    <!-- KHOI THU 5 - TIN TUC -->
    <div id="site-content">
        <section class="flat-row popup pad-top70px pad-bottom70px">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <div class="title-section">
                            <h2 class="title">TIN TỨC HOẠT ĐỘNG</h2>
                            <p class="desc-title">Tổng hợp tin tức hoạt động của Yolo, dám chia sẻ và của Mobifone</p>
                        </div>
                    </div>
                    <!-- /.col-md-6 -->
                </div>
                <!-- /.row -->

                <div class="flat-divider d50px"></div>

                <div class="row">
                    <div class="col-md-4" style="margin-bottom:20px">
                        <a href="<%= link %>"><img onerror="imgCatchError(this)" src="<%= image %>" style="width:100%" alt="image"></a>
                        
                        <!-- /.images-single-flexslider -->
                    </div>
                    <!-- /.col-md-4 -->

                    <div class="col-md-4">
                        <div class="flat-about-us">
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
                                    <div class="flat-progress">
                                        <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" >
                                            <p class="name"><%# Eval("Title") %></p>
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