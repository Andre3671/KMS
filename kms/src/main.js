import Vue from 'vue'
import App from './App.vue'
import Vuesax from 'vuesax'
import VueRouter from 'vue-router'
Vue.config.productionTip = false


import 'vuesax/dist/vuesax.css' //Vuesax styles
Vue.use(Vuesax, {
  // options here
})
Vue.use(VueRouter)
new Vue({
  render: h => h(App),
}).$mount('#app')
