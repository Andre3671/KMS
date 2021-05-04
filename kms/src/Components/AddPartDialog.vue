<template>
  <vs-dialog blur v-model="active2" v-on:close="test()">
      <div class="center grid">
          <vs-col :key="index" v-for="col,index in 2" vs-type="flex" vs-justify="center" vs-align="center" w="6">
        50%
      </vs-col>
      <vs-col :key="index" v-for="col,index in 2" vs-type="flex" vs-justify="center" vs-align="center" w="6">
        50%
      </vs-col>
      </div>
  
</vs-dialog>
</template>
<script>
export default {
    props:{
        active2:{
            type:Boolean,
            default:false,
        },
        PartList:{
            type:Object,
        }
    },
data:() =>({
}),
methods:{
    test: function(){
        this.$emit('closed')
    }
}
}
</script>

<style>
.vs-dialog{
width:700px;
height: 600px;
}
</style>