<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paging.ascx.cs" Inherits="FrontEnd_Controls_Common_Paging" %>


<ul class="pager">
    <asp:Repeater ID="Pager" runat="server" EnableViewState="False">
        <ItemTemplate>
            <li <%# ((bool)DataBinder.Eval(Container.DataItem, "Active"))?"class=\"active\"":"" %>>
                <a <%# (((String)DataBinder.Eval(Container.DataItem, "Link")) != "#")?"href=\"/tin-tuc/" +DataBinder.Eval(Container.DataItem, "Link") + "\"":"" %>>
                    <span>
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </span>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
