
//加载layui模块
layui.use(['form', 'layedit', 'laydate'], function () {
    var form = layui.form
        , layer = layui.layer
        , layedit = layui.layedit
        , laydate = layui.laydate;


//访问\刷新时加载验证码
var show_num = [];
draw(show_num);

//点击验证码图框时重新加载
$("#canvas").on('click', function () {
    draw(show_num);
});

//输入框\验证码判断
$(".layui-btn").click(function () {
    //判断用户名
    var na = $(".name").val();
    var pwd = $(".password").val();
    //记录是否记住密码
    if ($(".wirte").prop("checked")) { //是否被选中
        var swch = "on";
    }
    else {
        var swch = "off";
    }
    if (na == '') {
        layer.msg('账号不能为空', { icon: 5 });
    }
    if (na != '' && pwd == '') {
        layer.msg('密码不能为空', { icon: 5 });
    }
    //判断验证码
    var val = $(".input-val").val().toLowerCase();
    var num = show_num.join("");
    if (na != '' && pwd != '' && val == '') {
        layer.msg('验证码不能为空', { icon: 5 });
    }
    else if (na != '' && pwd != '' && val != num) {
        layer.msg('验证码错误', { icon: 5 });
    }
    else if (na != '' && pwd != '' && val == num) {
        //layer.msg('OK!', { icon: 6 });
        UserLogin(na, pwd, swch);
    }
});

//验证码生成
function draw(show_num) {
    var canvas_width = $('#canvas').width();
    var canvas_height = $('#canvas').height();
    var canvas = document.getElementById("canvas");//获取到canvas的对象，演员
    var context = canvas.getContext("2d");//获取到canvas画图的环境，演员表演的舞台
    canvas.width = canvas_width;
    canvas.height = canvas_height;
    var sCode = "A,B,C,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,W,X,Y,Z,1,2,3,4,5,6,7,8,9,0";
    var aCode = sCode.split(",");
    var aLength = aCode.length;//获取到数组的长度

    for (var i = 0; i <= 3; i++) {
        var j = Math.floor(Math.random() * aLength);//获取到随机的索引值
        var deg = Math.random() * 30 * Math.PI / 180;//产生0~30之间的随机弧度
        var txt = aCode[j];//得到随机的一个内容
        show_num[i] = txt.toLowerCase();
        var x = 10 + i * 20;//文字在canvas上的x坐标
        var y = 20 + Math.random() * 8;//文字在canvas上的y坐标
        context.font = "bold 23px 微软雅黑";

        context.translate(x, y);
        context.rotate(deg);

        context.fillStyle = randomColor();
        context.fillText(txt, 0, 0);

        context.rotate(-deg);
        context.translate(-x, -y);
    }
    for (var i = 0; i <= 5; i++) { //验证码上显示线条
        context.strokeStyle = randomColor();
        context.beginPath();
        context.moveTo(Math.random() * canvas_width, Math.random() * canvas_height);
        context.lineTo(Math.random() * canvas_width, Math.random() * canvas_height);
        context.stroke();
    }
    for (var i = 0; i <= 30; i++) { //验证码上显示小点
        context.strokeStyle = randomColor();
        context.beginPath();
        var x = Math.random() * canvas_width;
        var y = Math.random() * canvas_height;
        context.moveTo(x, y);
        context.lineTo(x + 1, y + 1);
        context.stroke();
    }
}

//得到随机的颜色值
function randomColor() {
    var r = Math.floor(Math.random() * 256);
    var g = Math.floor(Math.random() * 256);
    var b = Math.floor(Math.random() * 256);
    return "rgb(" + r + "," + g + "," + b + ")";
}

//调用一般处理程序
function UserLogin(na, pwd, swch) {
    $.ajax({
        type: 'post',
        dataType: 'text',
        url: 'Handlers/Login_hd.ashx',
        data: { ac: 'Userlogin', name: na, pwd: pwd, swch: swch },
        cache: false,
        async: false,
        success: function (data) {
            if (data ==0) {
                layer.alert("该用户已停用！请联系管理员！<br> TEL:130-152-12138");
            }
            if (data >0) {
                document.cookie = 'userroleid=' + data;
                window.location = 'Index.aspx';
            }
            if (data == -1) {
                layer.msg('用户名错误!', { icon: 5 });
            }
            if (data == -2) {
                layer.msg('密码错误!', { icon: 6 });
            }
        },
    });
    }
});