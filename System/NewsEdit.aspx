<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" validateRequest="false" CodeFile="NewsEdit.aspx.cs" Inherits="System_NewsEdit" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        var roxyFileman = '/fileman/index.html';
        $(function () {
            CKEDITOR.replace('MainContent_txtContent', {
                filebrowserBrowseUrl: roxyFileman,
                filebrowserImageBrowseUrl: roxyFileman + '?type=image',
                removeDialogTabs: 'link:upload;image:upload'
            });
        });

    </script>

    <style>
        textarea{
            resize:vertical;
        }

    </style>

    <script>
        function LoadImgSrc(input, img, imp) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $(img)
                        .attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            } else {
                $(img).attr('src', '');
                document.getElementById('MainContent_' + imp).value = "";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
     
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên bài viết :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTitle" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Nhóm bài viết:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlGroup" runat="server" class="AdminTextControl"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem">
            Mô tả :
        </div>
        <div class="AdminRightItem" style="display:table;">
            <asp:TextBox ID="txtShortContent" TextMode="MultiLine" Rows="1" runat="server" class="AdminTextControl" ></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display:table;">
        <div class="AdminLeftItem" style="display:table;">
            Nội dung :
            <br />
            <br />
            Hình đại diện
            <img id="preview" src="<%=htxtimg.Value %>" style="width: 100%" alt="Hình đại diện" />
                <label class="file-upload" style="margin-top: 1px;">
                    <input type="hidden" id="htxtimg" runat="server"/>
                    <asp:FileUpload ID="FileUpload" onchange="LoadImgSrc(this,'#preview','htxtimg');" runat="server" Width="100%" accept="image/x-png, image/gif, image/jpeg" CssClass="FileUploadImage" Height="22px" />
                </label>

 
        </div>
        <div class="AdminRightItem" style="display:table;">
            <CKEditor:CKEditorControl ID="txtContent" CssClass="editor1" runat="server" Height="210" Width="100%" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tag :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTag" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Nguồn bài viết :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtAuthor" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbNoiBat" runat="server"></asp:CheckBox> Bài viết nổi bật
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <a href="/System/NewsList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>
</asp:Content>

