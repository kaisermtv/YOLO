<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paging.ascx.cs" Inherits="Controller_Paging" %>
    <div style="width: 100%; text-align: center;">
        <ul class="pagination">
            <asp:Repeater ID="dtlData" runat="server">
                <ItemTemplate>
                    <li<%# Container.DataItem.ToString() == iPage.ToString()?" class=\"active\"":"" %>><a <%# GetLink(Container.DataItem.ToString()) %>><%# Container.DataItem.ToString() %> </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
