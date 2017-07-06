<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadMoreFacebook.aspx.cs" Inherits="ajax_LoadMoreFacebook" %>

<asp:repeater id="dtlData" runat="server">
    <ItemTemplate>
        <hr />
        <div class="row fb_content">
                                                <div class="image col-md-5">
                                                    <img src="<%# Eval("full_picture") %>" />
                                                </div>
                                                <div class="fb_body col-md-7">
                                                    <div class="fb_header">
                                                    </div>
                                                    <h5 id="facebookHeader"><%# (((dynamic)Container.DataItem).name != null)?Eval("name").ToString().Replace("Timeline Photos","Ảnh trên dòng thời gian"):"" %></h5>
                                                    <p id="facebookMeaasge"><%# (((dynamic)Container.DataItem).message != null)?Eval("message").ToString().Replace("\n","<br>"):"" %></p>
                                                </div>
                                            </div>
                                            <div class="fb_footer">
                                                <div style="float: left; margin-right:5px;">
                                                    <img src="/images/facebook-new-like-symbol-32.png" style="width: 20px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# (((dynamic)Container.DataItem).likes != null)?Eval("likes.summary.total_count"):"0" %>
                                                </div>
                                                <div style="float: left; margin-left:10px; margin-right:5px;">
                                                    <img src="/images/comments-512.png" style="width: 18px; margin-top:2px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# (((dynamic)Container.DataItem).comments != null)?Eval("comments.summary.total_count"):"0" %>
                                                </div>
                                                 <div style="float: left; margin-left:10px; margin-right:5px;">
                                                    <img src="/images/shares.png" style="width: 18px; margin-top:2px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# (((dynamic)Container.DataItem).shares != null)?Eval("shares.count"):"0" %>
                                                </div>
                                                <div style ="float:right; padding-top:5px; font-size: 12px; color:#849292;"><a href="<%# Eval("permalink_url") %>" style="float: right;">Xem trên facebook</a></div>
                                                <%--<div class="fb-like" data-href="<%# Eval("link") %>" data-layout="button_count" data-action="like" data-size="small" data-show-faces="false" data-share="false" style="width: 70%; float: left;"></div>--%>
                                            </div>
    </ItemTemplate>
</asp:repeater>

<div id="loadmore" style="text-align: center; margin-top: 20px">
    <%--<asp:Button ID="prev" runat="server" OnClick="prev_Click" Text="Trước" />--%>
    <%--<asp:Button ID="next" runat="server" OnClick="next_Click" Text="Tiếp" />--%>

    <button id="loadbutton" class="btn btn-default" onclick="loadNextPage('<%= nextUrl %>')">Tải thêm</button>
</div>
