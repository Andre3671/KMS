<template>
  <div id="app">
     <vs-button @click="active=!active" color="primary" type="filled">Open Sidebar</vs-button>
      <vs-sidebar parent="body" default-index="1"  color="primary" class="sidebarx" spacer v-model="active">

      <div class="header-sidebar" slot="header">
        <h4>
          User: 2142
        </h4>
      </div>

      <vs-divider icon="View orders" position="left">
        User
      </vs-divider>
      
      <vs-sidebar-item index="1">
        All orders
      </vs-sidebar-item>

      <vs-sidebar-item index="2">
        My Orders
      </vs-sidebar-item>

      <vs-divider icon="Orders" position="left">
        User
      </vs-divider>

      <vs-sidebar-item index="3">
        Create Order
      </vs-sidebar-item>
      <vs-sidebar-item index="4">
        Export order
      </vs-sidebar-item>
      <vs-sidebar-item index="5" >
        Import Order
      </vs-sidebar-item>

      <div class="footer-sidebar" slot="footer">
        <vs-button icon="reply" color="danger" type="flat">log out</vs-button>
        <vs-button icon="settings" color="primary" type="border"></vs-button>
      </div>

    </vs-sidebar>
    <Mainpage msg="wel to Your Vue.js App"/>
  </div>
</template>

<script>
import Mainpage from './components/Mainpage.vue'

export default {
  name: 'App',
  components: {
    Mainpage
  }
  ,
  data:()=>({
    active:false,
  })
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
