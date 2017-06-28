<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/System.master" AutoEventWireup="true" CodeFile="ListCategory.aspx.cs" Inherits="System_ListCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th>Nhóm 1</th>
                    <th>Nhóm 2</th>
                    <th>Nhóm 3</th>
                    <th>Nhóm 4</th>
                    <th>Nhóm 5</th>
                </tr>
            </thead>
<%--            <tbody>
                <tr>
                    <td class ="CategoryItem"><a href ="TonGiao.aspx">Tôn giáo</a></td>
                    <td class ="CategoryItem"><a href ="DanToc.aspx">Dân tộc</a></td>
                    <td class ="CategoryItem"><a href ="ChucVu.aspx">Chức vụ</a></td>
                    <td class ="CategoryItem"><a href ="LinhVuc.aspx">Lĩnh vực</a></td>
                    <td class ="CategoryItem"><a href ="HinhThucTuyenDung.aspx">Hình thức tuyển dụng</a></td>
                </tr>
            </tbody>--%>
            <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <tbody>
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <td class ="CategoryItem"><a href ="DanhMuc.aspx?id=<%# Eval("IdDanhMuc") %>"><%# Eval("NameDanhMuc") %></a></td>
                </ItemTemplate>
                <SeparatorTemplate>
                    <% if(index++ % 5 == 0 ){ %>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>
                    <% } %>
                </SeparatorTemplate>
                <FooterTemplate>
                        </tr>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

