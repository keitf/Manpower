layui.use(['form', 'tree'], function () {
    var $ = layui.$
        , layer = layui.layer
        , form = layui.form
        , tree = layui.tree;

    RoleMenu();
    //��ʼ����ֵ
    form.val("layuiadmin-form-role", {
        "id": getCookie("Editid")
        , "content": getCookie("Editcontent")
        , "name": getCookie("Editname")
    });

    //Ȩ�޸�ֵ �ַ���ת����
    var txtroleid = getCookie('Editroldsid');
    var arrroleid = txtroleid.split(",");
    console.log(arrroleid);
    console.log(txtroleid);

    tree.setChecked('demoid',arrroleid); //������ѡ

    //����submit��ť ����ӽ�ɫ��
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
    //���OR�޸�
    function RoleEditInfo(roleinfo_id,roleinfo_name,roleinfo_content,expower) {
    $.ajax({
      type: 'post',
      dataType: 'text',
      url: '../../Handlers/RoleEdit.ashx',
        data: { action: "RoleEditInfo", roleinfo_id: roleinfo_id, roleinfo_name: roleinfo_name, roleinfo_content: roleinfo_content ,expower:expower},
      cache: false,
      async: false,
      success: function (data) {
        //�ɹ���ʾ�����ر��
        if (data == 1)//�޸ĳɹ�
        {
          layer.alert("Edit OK!");
        }
        if (data == 2) //��ӳɹ�
        {
          layer.alert("Add OK!");
        }
        if (data == 0) //����ʧ��
        {
          layer.alert("ERROR!");
        }
      }
    });
  }
    //Ȩ���� 
    function RoleMenu() {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: '../../Handlers/RoleEdit.ashx',
            data: { action: "Treeview" },
            cache: false,
            async: false,
            success: function (data) {
                //Ȩ��
                tree.render({
                    elem: '#test1'
                    , showCheckbox: true
                    , accordion: true
                    , data: data
                    , isJump: true
                    , text: {
                        defaultNodeName: 'δ����' //�ڵ�Ĭ������
                        , none: '������' //����Ϊ��ʱ����ʾ�ı�
                    }
                    //�ڵ㱻����Ļص�
                    , click: function (obj) {
                        //console.log(JSON.stringify(obj.data));
                    }
                    //��ѡ�򱻵���Ļص�
                    , oncheck: function (obj) {
                        //console.log(JSON.stringify(obj.data));
                    }
                    , id: 'demoid'
                }); 
            }
        });
    }
});