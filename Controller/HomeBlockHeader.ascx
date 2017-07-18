<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomeBlockHeader.ascx.cs" Inherits="Controller_HomeBlockHeader" %>

<div class="BlockHeader">
    <small></small>
    <div class="txt"><%= (link != ""?"<a href=\""+link+ "\" >":"") + text +(link != ""?"</a>":"") %></div>
</div>
