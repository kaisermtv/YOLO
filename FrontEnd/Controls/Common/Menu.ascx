﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="FrontEnd_Controls_Common_Menu" %>


<div id="menu-wraper">
    <div class="content">

        <div id="bar-menu">
            <ul class="menu fll">
                <li class="active"><a href="/">YOLO</a></li>
                <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                   
                    <ItemTemplate>
                        <li><a href="<%# Eval("LINK") %>"><%# Eval("NAME") %></a></li>
                    </ItemTemplate>
                    
                </asp:Repeater>
                
            </ul>
        </div>
    </div>
</div>
