<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vote.ascx.cs" Inherits="FrontEnd_Controls_Common_Vote" %>



    <asp:Repeater ID="dtlQuestion" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="YOLOVote <%= post?"":"voted" %>">
                <form method="post" action="/AnswerResult">
                    <input type="hidden" value="<%= objData["ID"] %>" name="QuestionID" />
                    <input type="hidden" value="<%= Request.Url %>" name="redirect" />
                    <h3><%= objData["Question"] %></h3>
                    <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <input class="deriku-radio-input" <%= post?"":"disabled=\"disabled\"" %> id="Yolo-vote-<%# Eval("ID") %>" name="AnswerResul" <%# ((int)Eval("ID") == result)?"checked=\"checked\"":"" %> value="<%# Eval("ID") %>" type="radio">
                <label for="Yolo-vote-<%# Eval("ID") %>" class="deriku-radio-label">
                    <span></span>
                    <div class="vote-percent-m">
                        <p><%# Eval("Content") %></p>
                        <div class="vote-percent p50">
                            <div class="vote-percent-r" <%# "style=\"width: " + ((int)Eval("Num") * 100 / countAnswerResult)  + "%;\"" %>></div>
                        </div>
                    </div>
                </label>
            </li>
        </ItemTemplate>
        <FooterTemplate>
                    </ul>
                    <button type="submit" <%= post?"":"hidden=\"hidden\"" %> class="btn btn-success btn-vote">Bình chọn</button>
                </div>
            </form>
            
        </FooterTemplate>
    </asp:Repeater>


