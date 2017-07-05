<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadMoreFacebook.aspx.cs" Inherits="ajax_LoadMoreFacebook" %>

<asp:repeater id="dtlData" runat="server">
    <ItemTemplate>
                                        <hr />
                                        <div class="row fb_content">
                                            <div class="image col-md-5" >
                                                <img src="<%# Eval("full_picture") %>" />
                                            </div>
                                            <div class="fb_body col-md-7" >
                                                <div class="fb_header">

                                                </div>
                                                <h5><%# (((dynamic)Container.DataItem).name != null)?Eval("name").ToString().Replace("Timeline Photos","Ảnh trên dòng thời gian"):"" %></h5>
                                                <p><%# (((dynamic)Container.DataItem).message != null)?Eval("message"):"" %></p>
                                            </div>
                                        </div>
                                        <div class="fb_footer">
                                            <div class="fb-like" data-href="<%# Eval("link") %>" data-layout="button_count" data-action="like" data-size="small" data-show-faces="false" data-share="false"></div>
                                            <a href="<%# Eval("permalink_url") %>" style="float:right;" >Xem trên facebook</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:repeater>

<div id="loadmore" style="text-align: center; margin-top: 20px">
    <button id="loadbutton" class="btn btn-default" onclick="loadNextPage('<%= nextUrl %>')">Tải thêm</button>
</div>