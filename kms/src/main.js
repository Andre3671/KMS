import Vue from 'vue'
import App from './App.vue'
import Vuesax from 'vuesax'

Vue.config.productionTip = false
import 'vuesax/dist/vuesax.css' //Vuesax styles
import router from './router'
import Vuex from 'vuex'
Vue.use(Vuesax, {
  // options here
})
new Vue({
  router,
  Vuex,
  render: h => h(App)
}).$mount('#app')
