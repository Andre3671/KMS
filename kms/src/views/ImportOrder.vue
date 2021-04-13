<template>
<div>
  <h1>Import Order/Orders</h1>
  <input type="file">
  <vs-button color="#3252a8"  v-on:click="uploadsuccess =! uploadsuccess">Ladda upp</vs-button>

  <vs-alert v-if="uploadsuccess" success>
      <template #title>
        Orders Uploaded
      </template>
     All the orders were successfully upoaded.
    </vs-alert> 
</div>
</template>

<script>
export default {
data(){
  return{
uploadsuccess:false
  }
  
}
}
</script>

<style>

</style>