layui.use(['form','laydate','table','layer'], function () {
    var form = layui.form;
    var laydate = layui.laydate;
    var table = layui.table;
    var $ = layui.$;
    var layer = layui.layer;

    OptIN();

    Formadd();

    //监听提交按钮
    form.on('submit(emadd)', function (data) {
        //layer.alert(JSON.stringify(data.field), {
        //    title: '最终的提交信息'
        //})

        EmAdd(JSON.stringify(data.field));

        //阻止跳转
        return false;
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#Birthday' //指定元素
        , calendar: true
        , max: getDate()
    });

    //所有下拉框赋值
    function OptIN() {
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Department.ashx',
            data: { ac: 'OptIN_edep'},
            cache: false,
            async: false,
            success: function (data) {
                $(".edepoptin").html(data);
            }
        });
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Employee_DIC.ashx',
            data: { ac: 'OptIN_eposition' },
            cache: false,
            async: false,
            success: function (data) {
                $(".eposition").html(data);
            }
        });
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Employee_DIC.ashx',
            data: { ac: 'OptIN_epople' },
            cache: false,
            async: false,
            success: function (data) {
                $(".epople").html(data);
            }
        });
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Employee_DIC.ashx',
            data: { ac: 'OptIN_ePoliticaloutlook' },
            cache: false,
            async: false,
            success: function (data) {
                $(".ePoliticaloutlook").html(data);
            }
        });
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Employee_DIC.ashx',
            data: { ac: 'OptIN_eeducation' },
            cache: false,
            async: false,
            success: function (data) {
                $("#eeducation").html(data);
            }
        });
        form.render();
    }

    //添加员工
    function EmAdd(empinfo) {
        if (getCookie("EmployeeID") != "") {
            var emifid = getCookie("EmployeeID");
        }
        else {
            emifid = "0";
        }
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/Employee.ashx',
            data: { ac: 'EmAdd', eminfo: empinfo, eminfoid:emifid},
            cache: false,
            async: false,
            success: function (data) {
                if (data >0) {
                    layer.alert("OK");
                    setCookie("EmployeeID");
                    var mylay = parent.layer.getFrameIndex(window.name);
                    parent.layer.close(mylay);
                }
                else {
                    layer.alert("ERROR");
                }
                layui.form.render();

                
            }
        });
    }

    //表单赋值
    function Formadd() {
        if (getCookie('EmployeeID') != '') {
            console.log(getCookie('EmployeeID'));
            $.ajax({
                type: 'post',
                dataType: 'text',
                url: '../../Handlers/Employee.ashx',
                data: { ac: 'Formadd', empid: getCookie('EmployeeID') },
                cache: false,
                async: false,
                success: function (data) {
                    if (data > 0) {
                        //layer.alert("OK");
                        form.val("example", {
                            "ID":getCookie("EmployeeID"),
                            "Name": getCookie("ename"),
                            "DepartmentID": getCookie("edepid"),
                            "Sex": getCookie("esex"),
                            "Birthday": getCookie("ebir"),
                            "IdCard": getCookie("eidcard"),
                            "Position": getCookie("eposi"),
                            "Phone": getCookie("ephone"),
                            "Email": getCookie("email"),
                            "Nation": getCookie("enation"),
                            "Polity": getCookie("epoli"),
                            "Degree": getCookie("edegr"),
                            "Salary": getCookie("esalart"),
                            "Resume": getCookie("eresume"),
                            "Meno": getCookie("estatus")
                        })
                    }
                    else {
                        //layer.alert("ERROR");
                    }
                    layui.form.render();
                }
            });
        }
        else {
            console.log("ID为空！");
        }
    }

    //获取当前的时间
    function getDate() {
        var myDate = new Date()
        var year = myDate.getFullYear()
        var month = myDate.getMonth() + 1
        var date = myDate.getDate();
        var h = myDate.getHours();
        var m = myDate.getMinutes();
        var s = myDate.getSeconds();
        var now = year + '-' + conver(month) + '-' + conver(date) + ' ' + conver(h) + ': ' + conver(m) + ': ' + conver(s);
        return now;
    }
    function conver(s) {
        return s < 10 ?'0' + s : s;
    }
});