<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="Menu.aspx.cs" Inherits="System_Menu" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function delmodal(id, name) {
            $("#MainContent_idDel").val(id);
            $("#ttk").html(name);

            $("#myModal").modal("show");
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td >
                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" class="form-control">

                </asp:DropDownList>
            </td>
            <td style="width:15%">
                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" class="form-control">
                    <asp:ListItem Value="1">Menu ngang</asp:ListItem>
                    <asp:ListItem Value="2">Footer menu</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="/images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="table-responsive" <%--style="max-height:100px"--%>>
                <table class="DataListTable" <%--style="min-width:1500px"--%>>
                    <tr class="DataListTableHeader">
                        <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                        <th class="DataListTableHeaderTdItemJustify" style="width: 20%;">Tên Menu</th>
                        <th class="DataListTableHeaderTdItemJustify">Link</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Up</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Down</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><a href="Menu.aspx?id=<%# Eval("ID") %>"><%# Eval("NAME") %></a></td>
                <td class="DataListTableTdItemJustify"><%# Eval("LINK") %></td>
                <td class="DataListTableTdItemCenter">
                    <center>
                        <a href="MenuMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index-2 %>">
                            <div class="arrow-up"></div>
                        </a></center>
                </td>
                <td class="DataListTableTdItemCenter">
                    <center><a href="MenuMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index %>">
                            <div class="arrow-down"></div>
                        </a></center>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="MenuEdit.aspx?id=<%# Eval("ID") %>">
                        <img src="/Images/Edit.png" alt="">
                    </a>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="#myModal" onclick="delmodal(<%# Eval("ID") %>,'<%# Eval("NAME") %>')">
                        <img src="/Images/delete.png" alt="">
                    </a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <a href="MenuNew.aspx?pid=<%= itemId %>&type=<%= type %>" class="btn btn-primary">Thêm menu</a>
    <% if(objData != null){ %>
    <a href="Menu.aspx?type=<%= type %><%= (objData["PID"].ToString() != "")?"&pid="+objData["PID"].ToString():""  %>" class="btn btn-danger">Trở lại</a>
    <% } %>

    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <input id="idDel" type="hidden" runat="server" />
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Xóa menu</h4>
                </div>
                <div class="modal-body">
                    <p>Bạn xác nhận xóa menu <b id="ttk"></b></p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnDel" runat="server" CssClass="btn btn-primary" Text="Xác nhận xóa" OnClick="btnDel_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
