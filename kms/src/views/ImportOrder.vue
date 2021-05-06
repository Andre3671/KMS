<template>
<div>
  <h1>Import Order/Orders</h1>
  <input type="file" @change="uploadfilesave" ref="files"  id="file">
  <vs-button color="#3252a8" @click="upload()">Ladda upp</vs-button>

  <!-- <vs-alert v-if="uploadsuccess" success>
      <template #title>
        Orders Uploaded
      </template>
     All the orders were successfully upoaded.
    </vs-alert>  -->
</div>
</template>

<script>
export default {
data(){
  return{
    files:[],
uploadsuccess:false,
  }
  
},
methods:{
uploadfilesave: function(){
  console.log('changed');
  this.files = this.$refs.files.files
  console.log(this.files);
},
upload: function() {
   console.log('changed2');
  const fd = new FormData();
  fd.append('file',this.files[0])
   this.$store.commit("UploadFile",fd)
     this.$vs.notification({
            color:"success",
            title: 'Imported!',
            text: `The document was succesfully imported`
          })
},
},
}
</script>

<style>

</style>