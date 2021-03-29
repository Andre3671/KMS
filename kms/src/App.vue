<template>
  <div id="app">
     <div id="app">
  <vs-navbar  class="nabarx"
     active-text-color="rgba(245,152,66,1)"
          v-model="indexActive">
      <div slot="title">
        <vs-navbar-title>
          Kms
        </vs-navbar-title>
      </div>
      <vs-navbar-item index="0">
        <a @click="Routerpush('/')">All orders</a>
      </vs-navbar-item>
      <vs-navbar-item index="1">
        <a @click="Routerpush('/myorders')">My orders</a>
      </vs-navbar-item>
      <vs-navbar-item index="2">
        <a @click="Routerpush('/addorder')">Add Order</a>
      </vs-navbar-item>
      <vs-navbar-item index="3">
        <a @click="Routerpush('/import')">Import Order</a>
      </vs-navbar-item>
       <vs-spacer></vs-spacer>
       <vs-navbar-item >
        <a @click="popupActivo=true">Login</a>
      </vs-navbar-item>
    </vs-navbar>
     <vs-popup class="holamundo" style=""  title="Login" :active.sync="popupActivo">
       <p style="text-align:center;">Username</p>
       <vs-input style="margin:0 auto"></vs-input>
       <p style="text-align:center;">Username</p>
       <vs-input style="margin:0 auto"></vs-input>
       <div style="margin:0 auto">
          <vs-button style="margin-left:45%">Login</vs-button>
       </div>
      
    </vs-popup>
    <router-view/>
  </div>
      
  </div>
</template>
<script>
export default {
  data:()=>({
    popupActivo:false,
    indexActive:0,
  }),
  methods:{
    Routerpush: function(nav){
      this.$router.push(nav);
    }
  }
}
</script>
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
