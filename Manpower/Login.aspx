<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Manpower.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%-- 这些是引用文件 --%>        
    <link href="Theme/Layui/css/layui.css" rel="stylesheet" />
    <script src="Theme/Layui/layui.js"></script>
    <script src="Theme/Scripts/jquery-3.5.1.js"></script>
    <link href="Theme/Images/user_icon.png" rel="icon" />
    <%-- 这些是引用文件 --%>
    <title>Manpower-Login|登录</title>
</head>
<body>
    <form class="layui-form" action="#" method="post" runat="server">
        <div class="container">
            <div class="layui-form-mid layui-word-aux">
                <img id="logoid" src="Theme/Images/06.png" height="35"/>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">用户名</label>
                <div class="layui-input-block">
                    <input type="text" name="name" placeholder="请输入用户名"
                        autocomplete="off" class="layui-input name" runat="server" id="name" value="admin"/>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">密 &nbsp;&nbsp;码</label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="pwd" runat="server" name="password" placeholder="请输入密码" autocomplete="off" class="layui-input password" TextMode="Password" Text=""></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">验证码</label>
                <div class="layui-input-inline">
                    <input type="text" name="verifycode" placeholder="验证码(不区分大小写)"
                        autocomplete="off" class="layui-input verity input-val"/>
                    <canvas id="canvas" width="100" height="38"></canvas>
                </div>                
            </div>

            <div class="layui-form-item">
                <label class="layui-form-label">记住密码</label>
                <div class="layui-input-block">
                  <input type="radio" name="dpwd" value="on" title="是" class="wirte" />
                  <input type="radio" name="dpwd" value="off" title="否" checked class="nowirte" />
                </div>
            </div>

            <div class="layui-form-item">
                <div class="layui-input-block">
                    <button type="button" class="layui-btn">登录</button>
                </div>
            </div>
            <a href="recover.html" class="font-set">忘记密码?</a> <a href="reg.html" class="font-set">立即注册</a>
        </div>
    </form>
</body>
</html>
<script src="Theme/Pageset/login.js"></script>
<link href="Theme/Pageset/login.css" rel="stylesheet" />