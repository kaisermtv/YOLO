<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin.master" CodeFile="Menu.aspx.cs" Inherits="System_Menu" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function delmodal(id, name) {
            $("#idDel").val(id);
            $("#ttk").html(name);

            $("#myModal").modal("show");
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <form method="get" id="seachform">
    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td >
                <select name="id" onchange="SubmitForm('seachform');" class="form-control">
                    <asp:Repeater ID="ddlGroup" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <option value="<%# Eval("ID") %>"<%# Eval("ID").ToString() == itemId.ToString()?" selected=\"selected\"":"" %>><%# Eval("NAME") %></option>
                        </ItemTemplate>
                    </asp:Repeater>
                </select>
            </td>
            <td style="width:15%">
                <select name="type" onchange="SubmitForm('seachform');" class="form-control">
                    <option value="1" <%= type==1?"selected=\"selected\"":"" %>>Menu ngang</option>
                    <option value="2" <%= type==2?"selected=\"selected\"":"" %>>Footer menu</option>
                </select>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <input type="image" src="/images/Search.png" style="margin-bottom: -15px; margin-left: -15px;" />
            </td>
        </tr>
    </table>
    </form>

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
    <form method="post">
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <input name="idDel" id="idDel" type="hidden" />
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
                        <%--<asp:Button ID="btnDel" runat="server" CssClass="btn btn-primary" Text="Xác nhận xóa" OnClick="btnDel_Click" />--%>
                        <button type="submit" class="btn btn-primary">Xác nhận xóa</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </form>
</asp:Content>
