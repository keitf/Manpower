<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Manpower.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- 这些是引用文件 --%>
    <script src="Theme/Scripts/jquery-3.5.1.js"></script>
    <script src="Theme/Layui/layui.js"></script>
    <link href="Theme/Images/user_icon.png" rel="icon" />
    <link href="Theme/Layui/css/layui.css" rel="stylesheet" />
    <script src="Theme/Pageset/CookieSet.js"></script>
    <%-- 这些是引用文件 --%>
    <style>
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow: hidden;
        }
        
    </style>
    <title>Manpower-Index|首页</title>
</head>
<body>
    <form id="form1" runat="server" class="layui-form">
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header">
                <div class="layui-logo">
                    <a href="" style="color:#e8a8a8;">
                        <img src="Theme/Images/logo.png" alt="logo" style="height:100%;"/>
                        <span>Manpower System</span>
                    </a>
                </div>
                <!-- 头部区域（可配合layui已有的水平导航） -->
                <ul class="layui-nav layui-layout-left" runat="server" id="leftnav">
                    <li class="layui-nav-item defaultpage"><a href="default.html">控制台</a></li>
                    <li class="layui-nav-item"><a href="Serviceroot/User_management/Employee_add.html">员工添加</a></li>
                    <li class="layui-nav-item"><a href="Serviceroot/System_management/user.html">用户</a></li>
                </ul>
                <ul class="layui-nav layui-layout-right">
                    <li class="layui-nav-item">
                        <a href="javascript:;">
                            <img src="Theme/Images/headerimg.jpeg" class="layui-nav-img" />
                            <span id="welname" runat="server"></span>
                        </a>                        
                    </li>
                    <li class="layui-nav-item"><a href="" class="singout">退了</a></li>
                </ul>
            </div>

            <div class="layui-side layui-bg-black">
                <div class="layui-side-scroll">
                    <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
                    <ul class="layui-nav layui-nav-tree" lay-filter="test" runat="server" id="chuizhidaohang">
                    </ul>
                </div>
            </div>

            <div class="layui-body" runat="server" id="mainbody">
                <!-- 内容主体区域 -->
                <div style="width: 100%; height: 100%; border: 0px solid red">
                    <%-- 测试用已隐藏 --%>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Visible="False" />

                    <iframe id="iframeMain" src="default.html" style="border: none; width: 100%; height: 100%;"></iframe>
                </div>
            </div>

            <div class="layui-footer">
                <!-- 底部固定区域 -->
                © layui.com - 底部固定区域
            </div>
        </div>
    </form>
</body>
</html>
<script>
    //JavaScript代码区域
    layui.use(['element', 'form'], function () {
        var element = layui.element;
        var form = layui.form;

        $(".singout").click(function () {
            delCookie("userroleid");
            delCookie("cname");
            delCookie("cpwd");
            delCookie("sname");
        });

        $(function () {
            $("dd>a").click(function (e) {
                e.preventDefault();
                console.log($(this).text());
                if ($(this).text() == "退出登录") {
                    delCookie("userroleid");
                    delCookie("cname");
                    delCookie("cpwd");
                    delCookie("sname");
                    location.reload();
                }
                $("#iframeMain").attr("src", $(this).attr("href"));
            });
            $("li>a").click(function (e) {
                e.preventDefault();
                $("#iframeMain").attr("src", $(this).attr("href"));
            });            
        });
    });

</script>
