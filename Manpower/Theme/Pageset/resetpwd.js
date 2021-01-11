
layui.use(['form', 'layer'], function () {
    var form = layui.form;
    var layer = layui.layer;
    var $ = layui.$;
    //表单验证
    form.verify({
        pwd: function () {
            var data = form.val("resetpwd");
            var pwd = data.nowpwd;
            var repwd = data.renowpwd;
            if (pwd != repwd)
                return '密码不一致';
        }
    });
    //监听submit提交
    form.on('submit(pwdreg)', function (data) {
        var userdata = data.field;
        //console.log(userdata); //当前容器的全部表单字段，名值对形式：{name: value}
        var id = getCookie("userroleid");
        Repwd(userdata.oldpwd, id, userdata.renowpwd);
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    });
    //修改密码
    function Repwd(oldpwd,id,newpwd) {       
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/UserEdit.ashx',
            data: { ac: 'UserRepwd',opwd:oldpwd,id:id,npwd:newpwd },
            cache: false,
            async: false,
            success: function (data) {
                //alert(data);
                if ("0" == data) {
                    layer.alert("初始密码不正确");
                }
                else if ("1" == data) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content:'修改成功',
                            time: 1500,
                            //end: function () {
                            //    delCookie("userroleid");
                            //    delCookie("cname");
                            //    delCookie("cpwd");
                            //    delCookie("sname");                                
                            //}
                        });
                }
                else {
                    layer.alert("系统异常！");
                }
            }
        });
    }
});