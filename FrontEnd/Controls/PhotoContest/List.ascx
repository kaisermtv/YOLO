<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="FrontEnd_Controls_PhotoContest_List" %>

<asp:Repeater ID="ListContest" runat="server">
    <ItemTemplate>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <a href="/<%# SystemClass.convertToUnSign2(Eval("user_name").ToString()) %>-p<%#Eval("id")%>" class="PhotoContestPerson">
                <div class="img-w person">
                     <img  onError="this.src='/images/Front-End/no-image-available.png';" src="<%#Eval("picture")%>" />
                </div>
                <div class="person-detail">
                    <h3><%#Eval("user_name")%></h3>
                    <p>Ngày sinh: <%#Eval("user_birthday")%></p>
                    <p>Đến từ: <%#Eval("user_address")%></p>
                </div>
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>
