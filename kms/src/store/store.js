import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
/* eslint-disable no-unused-vars */
export default new Vuex.Store({
  state: {
    Orders: [],
    Order:{}
  },
  mutations: {
   async GetOrders(state, payload){
      let response = await fetch('https://localhost:44347/api/Orders');
      let data = await response.json();
      console.log(data);
      this.state.Orders = data;
          },
   async PostOrder(state, payload){
            await fetch("https://localhost:44347/api/Orders", {
              method: "POST",
              headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify(payload),
            });
             
          },
  }
})