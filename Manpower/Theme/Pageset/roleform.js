layui.use(['form', 'tree'], function () {
    var $ = layui.$
        , layer = layui.layer
        , form = layui.form
        , tree = layui.tree;

    RoleMenu();
    //初始化赋值
    form.val("layuiadmin-form-role", {
        "id": getCookie("Editid")
        , "content": getCookie("Editcontent")
        , "name": getCookie("Editname")
    });

    //权限赋值 字符串转数组
    var txtroleid = getCookie('Editroldsid');
    var arrroleid = txtroleid.split(",");
    console.log(arrroleid);
    console.log(txtroleid);

    tree.setChecked('demoid',arrroleid); //批量勾选

    //监听submit按钮 【添加角色】
    form.on('submit(LAY-user-role-submit)', function (data) {        
        var arrchk = [];
        $('input[type=checkbox]:checked').each(function () {
            arrchk.push($(this).val());
        });
        var name = data.field.name;
        var content = data.field.content;
        var id = data.field.id;
        console.log(name);
        console.log(content);
        console.log(arrchk);
        console.log(id);
        RoleEditInfo(id, name, content, arrchk.join(','));
        return false;
  });    
    //添加OR修改
    function RoleEditInfo(roleinfo_id,roleinfo_name,roleinfo_content,expower) {
    $.ajax({
      type: 'post',
      dataType: 'text',
      url: '../../Handlers/RoleEdit.ashx',
        data: { action: "RoleEditInfo", roleinfo_id: roleinfo_id, roleinfo_name: roleinfo_name, roleinfo_content: roleinfo_content ,expower:expower},
      cache: false,
      async: false,
      success: function (data) {
        //成功提示并重载表格
        if (data == 1)//修改成功
        {
          layer.alert("Edit OK!");
        }
        if (data == 2) //添加成功
        {
          layer.alert("Add OK!");
        }
        if (data == 0) //操作失败
        {
          layer.alert("ERROR!");
        }
      }
    });
  }
    //权限树 
    function RoleMenu() {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: '../../Handlers/RoleEdit.ashx',
            data: { action: "Treeview" },
            cache: false,
            async: false,
            success: function (data) {
                //权限
                tree.render({
                    elem: '#test1'
                    , showCheckbox: true
                    , accordion: true
                    , data: data
                    , isJump: true
                    , text: {
                        defaultNodeName: '未命名' //节点默认名称
                        , none: '无数据' //数据为空时的提示文本
                    }
                    //节点被点击的回调
                    , click: function (obj) {
                        //console.log(JSON.stringify(obj.data));
                    }
                    //复选框被点击的回调
                    , oncheck: function (obj) {
                        //console.log(JSON.stringify(obj.data));
                    }
                    , id: 'demoid'
                }); 
            }
        });
    }
});