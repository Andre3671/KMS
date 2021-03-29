<template>
  <div id="app">
   <vs-navbar color="#7d33ff" text-white square center-collapsed v-model="active">
        <template #left>
          <!-- logo -->
        </template>
        <vs-navbar-item :active="active == 'guide'" @click="Routerpush('/')" id="guide">
          All orders
        </vs-navbar-item>
        <vs-navbar-item :active="active == 'docs'" @click="Routerpush('/myorders')" id="docs">
         My orders
        </vs-navbar-item>
        <vs-navbar-item :active="active == 'components'" @click="Routerpush('/addorder')" id="components">
          Add order
        </vs-navbar-item>
        <vs-navbar-item :active="active == 'license'" @click="Routerpush('/import')" id="license">
          Import order
        </vs-navbar-item>
        <template #right>
          <vs-button color="#fff" flat >Login</vs-button>
        </template>
      </vs-navbar>
  <div>
      <router-view style="margin-top:3%"/>
  </div>
     
  </div>
</template>
  <script>
  export default {
    data:() => ({
      active: 0
    }),
     methods:{
    Routerpush: function(nav){
      this.$router.push(nav);
    }
    }
  }
  </script>