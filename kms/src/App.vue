<template>
  <div id="app">
   <vs-navbar color="#3252a8" text-white square center-collapsed v-model="active">
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
          <vs-button color="#fff" flat @click="popup=!popup" >Login</vs-button>
        </template>
      </vs-navbar>
  <div>
      <router-view style="margin-top:3%"/>
  </div>
     <vs-dialog v-model="popup">
        <template #header>
          <h4 class="not-margin">
            <b>Login</b>
          </h4>
        </template>


        <div class="con-form">
          <vs-input v-model="email" placeholder="Email">
            <template #icon>
              @
            </template>
          </vs-input>
          <vs-input type="password" v-model="password" placeholder="Password">
            <template #icon>
              <i class='bx bxs-lock'></i>
            </template>
          </vs-input>
          <div class="flex">
            <vs-checkbox v-model="remember">Remember me</vs-checkbox>
            <a href="#">Forgot Password?</a>
          </div>
        </div>

        <template #footer>
          <div class="footer-dialog">
            <vs-button block>
              Sign In
            </vs-button>

            <div class="new">
              New Here? <a href="#">Create New Account</a>
            </div>
          </div>
        </template>
      </vs-dialog>
  </div>
</template>
  <script>
  export default {
    data:() => ({
      active: 0,
      popup: false,
      email: '',
      password: '',
      remember: false
    }),
     methods:{
    Routerpush: function(nav){
      this.$router.push(nav);
    }
    }
  }
  </script>

  <style>
  .not-margin
    {
      margin: 0px;
      font-weight: normal;
      padding:10px;
    }
  .con-form
    {
      width: 100%;
    }
  .footer-dialog
    {
      display:flex;
      align-items: center;
      justify-content: center;
      flex-direction: column;
      width:calc(100%);
    }
  .new
    {
      margin: 0px;
      margin-top: 20px;
      padding: 0px;
      font-size: .7rem;
    }
  .flex
    { display: flex;
      align-items: center;
      justify-content: space-between;  
    } 
  .vs-checkbox-label
    {
      font-size: .8rem;
    }
  .vs-input-content
    {
      margin: 10px 0px;
      width: calc(100%);
    }
  .vs-input
    {
      width: 100%;
    }
                
  </style>