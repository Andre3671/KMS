<template>
  <vs-dialog blur v-model="active">
      <div id="AddPart">

      </div>
      <div id="PartsList"></div>
  
</vs-dialog>
</template>

<script>
export default {
    props:{
        active:{
            type:Boolean,
            default:false,
        },
        Parts:{
            type:Array
        }
    },
data:() =>({
    PartList :[]
})
}
</script>

<style>
.vs-dialog{
width:700px;
height: 600px;
}
</style>