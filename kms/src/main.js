import Vue from 'vue'
import App from './App.vue'
import Vuesax from 'vuesax'
import cors from 'cors'

Vue.config.productionTip = false
import 'vuesax/dist/vuesax.css' //Vuesax styles
import router from './router'
import store from './store/store.js'
Vue.use(Vuesax, {
  // options here
})
Vue.use(cors)
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
