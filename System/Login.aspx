<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="System_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
	    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	    <title>Đăng nhập quản trị viên</title>
	
	    <link href="/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
	    <link href="/css/login.css" rel='stylesheet' type='text/css' />
    </head>

    <body>
	    <div class="login">
            <h1>Đăng nhập quản trị viên</h1>
            <form method="post" action="/System/Login.aspx" >
    	        <% if(this.Message != ""){ %>
	                 <div style="color:red;margin:10px 0px;">
	                        <%=this.Message %>
	                 </div>
                <% } %>
                <input type="text" name="account" value="<%=Account %>" placeholder="Tài khoản" required="required" />
                <input type="password" name="password" placeholder="Mật khẩu" required="required" />

                <div style="width: 100%; text-align: right">
                    <input type="checkbox" id="remember" name="remember" <%= Remember?"checked":"" %> /><label for="remember" > Nhớ tôi</label>
                </div>
                <button type="submit" class="btn btn-primary btn-block btn-large">Đăng nhập</button>
            </form>
        </div>
    </body>
</html>
