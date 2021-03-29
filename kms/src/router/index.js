import Vue from 'vue'
import VueRouter from 'vue-router'
import AllOrders from '../views/AllOrders.vue'
import MyOrders from '../views/MyOrders.vue'
import AddOrder from '../views/AddOrder.vue'
import ImportOrder from '../views/ImportOrder.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'AllOrders',
    component: AllOrders
  },
  {
    path: '/myorders',
    name: 'MyOrders',
    component: MyOrders
  },
  {
    path: '/addorder',
    name: 'AddOrder',
    component: AddOrder
  },
  {
    path: '/import',
    name: 'ImportOrder',
    component: ImportOrder
  }
]

const router = new VueRouter({
  routes
})

export default router
