layui.use(['form', 'tree', 'table', 'layer','element'], function () {
    var form = layui.form;
    var tree = layui.tree;
    var table = layui.table;
    var layer = layui.layer;
    var element = layui.element;
    var $ = layui.$;

    //Tree数据源
    var data = TreeData();   

    //左侧Tree部门树q
    tree.render({
        elem: '#departTree'
        , data: data
        , showCheckbox: true
        , id: 'demoid'
        , accordion: true
        , edit: ['add', 'update', 'del']
        //结点被点击时
        , click: function (obj) {
                        
        }
        //右侧编辑按钮
        , operate: function (obj) {
            var type = obj.type;
            var id = obj.data.id;

            switch (type) {
                case 'add':
                    console.log('添加' + id + obj.data.title);
                    $.ajax({
                        type: 'post',
                        dataType: 'text',
                        url: '../../Handlers/Department.ashx',
                        data: { ac: 'treeadd',pid:id },
                        cache: false,
                        async: false,
                        success: function (data) {
                            if (data > 0) {
                                TreeReload();
                                console.log(data);
                            }
                            else {
                                layer.alert("ERROR");
                            }
                            
                        }
                    });
                    break;
                case 'update':
                    console.log('修改' + id + obj.data.title);
                    $.ajax({
                        type: 'post',
                        dataType: 'text',
                        url: '../../Handlers/Department.ashx',
                        data: { ac: 'treeupdate', id: id, name: obj.data.title },
                        cache: false,
                        async: false,
                        success: function (data) {
                            if (data == true) {
                                TreeReload();
                                console.log(data);
                            }
                            else {
                                layer.alert("ERROR");
                            }
                        }
                    });
                    break;
                case 'del':
                    console.log('删除' + id);
                    $.ajax({
                        type: 'post',
                        dataType: 'text',
                        url: '../../Handlers/Department.ashx',
                        data: { ac: 'treedel', id: id},
                        cache: false,
                        async: false,
                        success: function (data) {
                            if (data == true) {
                                TreeReload();
                                console.log(data);
                            }
                            else {
                                layer.alert("ERROR");
                            }
                        }
                    });
                    //layer.alert("权限不足，请联系管理员！</br>权限不足，请联系管理员！</br>权限不足，请联系管理员!");
                    //return false;
                    break;
            }
        }
        //是否勾选事件
        , oncheck: function (obj) {
            var arrchk = [];
            $('input[type=checkbox]:checked').each(function () {
                arrchk.push($(this).val());
            });
            console.log(JSON.stringify(arrchk));
            //返回查询json数据 AND 表格重载
            table.reload('employeeList', {
                 url:'../../Handlers/Employee.ashx?ac=SelEmpByDerpID'
                ,where: {
                    IDs: arrchk.join(',')
                }
            })    
        }
    });

    //右侧Table员工列表
    table.render({
        elem: '#employeeList'
        , url: '../../Handlers/Employee.ashx?ac=SEL' //数据接口            
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'ID', title: 'ID', sort: true, fixed: 'left' }
            , { field: 'Department', title: '部门'}
            , { field: 'Name', title: '姓名', sort: true,templet: '#usernameTpl' }
            , { field: 'Sex', title: '性别', templet: function (d) { if (d.Sex == 1) { return '男' } else { return '女' } }}
            , { field: 'Birthday', title: '生日'  }
            , { field: 'IdCard', title: '身份证', sort: true }
            , { field: 'Position', title: '职位',  sort: true }
            , { field: 'Phone', title: '电话'}
            , { field: 'Email', title: '邮箱',  sort: true }
            , { field: 'Nation', title: '民族 ' }
            , { field: 'Polity', title: '政治面貌',  sort: true }
            , { field: 'Degree', title: '学历', sort: true }
            , { field: 'Salary', title: '月薪'  }
            , { field: 'Resume', title: '个人履历', sort: true }
            , { field: 'Meno', title: '备注'}            
            , { fixed: 'right', title: '操作', toolbar: '#barDemo', minWidth:115 }
        ]]
        , page: true
        , cellMinWidth: 80
        , height:'full-179'
        , toolbar: '#toolbarDemo'
    });

    //监听头工具栏
    table.on('toolbar(test)', function (obj) {
        var checkStatus = table.checkStatus(obj.config.id);

        switch (obj.event) {
            case 'getCheckData':
                var data = checkStatus.data;
                layer.alert(JSON.stringify(data));
                break;
            case 'getCheckLength':
                var data = checkStatus.data;
                layer.msg('选中了：' + data.length + ' 个');
                break;
            case 'isAll':
                layer.msg(checkStatus.isAll ? '全选' : '未全选');
                break;
        }
    });

    //监听行工具栏
    table.on('tool(test)', function (obj) {
        switch (obj.event) {
            case 'edit':
                //layer.msg("编辑");
                layer.open({
                    type: 2
                    , title: '编辑'
                    , content: 'employee_add.html'
                    , area: ['800px', '700px']
                    , success: function (layero, index) {
                        document.cookie = "EmployeeID=" + obj.data.ID;
                    }
                    , cancel: function (index, layero) {
                        if (confirm("确定要关闭吗？")) {
                            //table.reload('employeeList', {

                            //})

                        }
                    }
                    , end: function () {
                        table.reload('employeeList', {

                        })
                        //layer.msg("修改成功！")
                    }
                });
                break;
            case 'del':
                console.log(JSON.stringify(obj.data));
                if (confirm("确定要删除吗？")) {
                    //删除
                    $.ajax({
                        type: 'post',
                        dataType: 'text',
                        url: '../../Handlers/Employee.ashx',
                        data: { ac: 'EmpDEl', empinfo: obj.data.ID},
                        cache: false,
                        async: false,
                        success: function (data) {
                            if (data>0) {
                                layer.alert("OOK");
                                table.reload('employeeList', {
                                })
                            }
                            else {
                                layer.alert("ERROR");                                
                            }
                        }
                    });
                }
                break;
            default:
                break;
        }
    });

    //Tree数据源
    function TreeData() {
        var Tdata;
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: '../../Handlers/Department.ashx',
            data: { ac: 'treedata'},
            cache: false,
            async: false,
            success: function (data) {
                Tdata = data;
            }
        });
        return Tdata;
    }

    //Tree重载
    function TreeReload() {
        tree.reload('demoid',{
            elem:"#departTree"
            , data: TreeData()
        });
    }

    //监听Tab切换
    element.on('tab(test)', function (data) {        
        layer.msg(data.elem.context.innerText /*+ data.index*/);
        //表格重载
        table.reload("employeeList", {
            url: "../../Handlers/Employee.ashx?ac=SEL"
            , where: {
                stid: data.index
            }
        })
    });
});