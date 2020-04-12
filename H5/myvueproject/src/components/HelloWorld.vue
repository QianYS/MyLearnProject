<template>
      <div class="hello">
    <el-table
    :data="tableData"
    border>
    <el-table-column
      prop="userName"
      label="姓名">
    </el-table-column>
    <el-table-column
      prop="itemCount"
      label="年龄">
    </el-table-column>
    <el-table-column
      fixed="right"
      label="操作">
      <template slot-scope="scope">
        <el-button @click="opendialog(scope.row,true)" type="text" size="small">查看</el-button>
        <el-button @click="opendialog(scope.row,false)" type="text" size="small">编辑</el-button>
        <el-button @click="deletestudent(scope.row)" type="text" size="small">删除</el-button>
      </template>
    </el-table-column>
  </el-table>

    <el-button type="text" @click="createStudent">新增</el-button>
    <el-dialog
      title="学生信息"
      :visible.sync="dialogVisible"
      width="40%"
      :before-close="handleClose">
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <el-form-item label="姓名">
          <el-input v-model="formInline.name" placeholder="姓名" :disabled="canEdit"></el-input>
        </el-form-item>
        <el-form-item label="年龄">
          <el-input v-model="formInline.age" placeholder="年龄" type="number" :disabled="canEdit"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
      <el-button @click="handleClose">取 消</el-button>
      <el-button type="primary" @click="createOrUpdateStudent" v-if="!canEdit">确 定</el-button>
  </span>
</el-dialog>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data() {
      return {
        dialogVisible: false,
        canEdit:true,
        formInline: {
          id:'',
          name: '',
          age: 0
        },
        tableData: []
      };
    },
    mounted:function(){
      this.getList();
    },
  methods:{
    handleClose:function(){
      var that=this;
      that.formInline.name='';
      that.formInline.age=0;
      that.dialogVisible=false;
    },
    createStudent:function(){
      var that=this;
      that.dialogVisible=true;
      that.formInline.name='';
      that.formInline.age=0;
      that.formInline.id=null;
      that.canEdit=false;
    },
    //加载列表
    getList:function(){
      var that=this;

      this.$axios({
        method:'get',
        url:'https://localhost:44383/api/Order/GetOrderList',
      }).then(res=>{
        that.tableData=res.data;
      }).catch(res=>{
        console.log(res);
        that.$message.error('发生内部错误，请联系管理员');
      });


      /* this.axios.get('https://localhost:44383/api/Order/GetOrderList').then(res=>{
        //console.log(res);
        that.tableData=res.data;
      }).catch(res=>{
        console.log(res);
        that.$message.error('发生内部错误，请联系管理员');
      }); */
    },
    deletestudent:function(row){
      var that=this;
      let data = {
        Id:row.id
      };
      if(row.id!=null){
        this.$axios({
          method:'delete',
          url:'https://localhost:44383/api/Order/DeleteStudent',
          data:data
        }).then(()=>{
          that.$message({
            message: '删除成功',
            type: 'success'
          })
          that.getList();
        }).catch(()=>{
          that.$message.error('发生内部错误，请联系管理员');
        });
        /* this.axios.post('https://localhost:44383/api/Order/DeleteStudent',data).then(res=>{
          console.log(res);
          that.$message({
            message: '删除成功',
            type: 'success'
          })
          that.getList();
        }).catch(res=>{
          console.log(res);
          that.$message.error('发生内部错误，请联系管理员');
        }); */
      }
      
    },
    //打开弹窗
    opendialog:function(row,isEdit){
      var that=this;
      if(row.id!=null){
        //alert(2);
        that.formInline.id=row.id;
        that.formInline.name=row.userName;
        that.formInline.age=row.itemCount;
        that.dialogVisible=true;
        if(isEdit){
          that.canEdit=true;
        }else{
          that.canEdit=false;
        }
      }else{
        that.canEdit=false;
        that.dialogVisible=true;
        that.formInline={name:"ceshi",age:7}
      }
    },
    createOrUpdateStudent:function(){
      var that=this;
      console.log(this.formInline.name);
      console.log(typeof(that.formInline.age));
      let data = {
        //Id:that.formInline.id,
        userName:that.formInline.name,
        itemCount:parseInt(that.formInline.age)
      }
      if(that.formInline.id){
         data.Id=that.formInline.id;
      }
      this.axios.post('https://localhost:44383/api/Order/CreateOrUpdate',data).then(res=>{
        console.log(res);
          this.$message({
            message: '保存成功',
            type: 'success'
          });
          that.formInline.name='';
          that.formInline.age=0;
          that.dialogVisible=false;
          that.getList();
        }).catch(res=>{
          console.log(res);
          that.$message.error('发生内部错误，请联系管理员');
        });
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.holle{
  width:80%;
  margin:0 auto;
}
</style>
