<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Manpower.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%-- 这些是引用文件 --%>        
    <script src="Theme/Scripts/jquery-3.5.1.js"></script>
    <script src="Theme/Layui/layui.js"></script>
    <link href="Theme/Images/user_icon.png" rel="icon" />
    <link href="Theme/Layui/css/layui.css" rel="stylesheet" />
    <script src="Theme/Pageset/CookieSet.js"></script>
    <%-- 这些是引用文件 --%>
    <title>Manpower-Index|首页</title>
</head>
<body>
    <form id="form1" runat="server" class="layui-form">
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header">
            <div class="layui-logo">Manpower System</div>
            <!-- 头部区域（可配合layui已有的水平导航） -->
            <ul class="layui-nav layui-layout-left">
                <li class="layui-nav-item"><a href="">控制台</a></li>
                <li class="layui-nav-item"><a href="">商品管理</a></li>
                <li class="layui-nav-item"><a href="">用户</a></li>
                <li class="layui-nav-item">
                    <a href="javascript:;">其它系统</a>
                    <dl class="layui-nav-child">
                        <dd><a href="">邮件管理</a></dd>
                        <dd><a href="">消息管理</a></dd>
                        <dd><a href="">授权管理</a></dd>
                    </dl>
                </li>
            </ul>
            <ul class="layui-nav layui-layout-right">
                <li class="layui-nav-item">
                    <a href="javascript:;">
                        <img src="Theme/Images/headerimg.jpeg" class="layui-nav-img"/>
                        <span id="welname" runat="server"></span>
                    </a>
                    <dl class="layui-nav-child">
                        <dd><a href="">基本资料</a></dd>
                        <dd><a href="">安全设置</a></dd>
                    </dl>
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

            <div class="layui-body">
                <!-- 内容主体区域 -->
                <div style="padding: 15px;">
                    <%-- 测试用已隐藏 --%>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Visible="False" />
                    <iframe id="iframeMain" src="" style="width:100%;height:600px"></iframe>
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
        layui.use(['element','form'], function () {
            var element = layui.element;
            var form = layui.form;



            $(document).ready(function () {
                $("dd>a").click(function (e) {
                    e.preventDefault();
                    $("#iframeMain").attr("src", $(this).attr("href"));
                });
            });
            $(".singout").click(function () {                                 
                delCookie("userroleid");
                delCookie("cname");
                delCookie("cpwd");
                delCookie("sname"); 
            });
        });
       
    </script>