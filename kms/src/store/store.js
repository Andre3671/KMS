import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)
/* eslint-disable no-unused-vars */
export default new Vuex.Store({
  state: {
    Orders: [],
    Order: {},
    file: []
  },
  mutations: {
    async GetOrders(state, payload) {
      let response = await fetch('https://localhost:44305/Orders');
      let data = await response.json();
      this.state.Orders = data;
    },
    async PostOrder(state, payload) {
      console.log(JSON.stringify(payload));
      await fetch("https://localhost:44305/Orders/", {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'

        },
        body:JSON.stringify(payload)
    });
      
    },
    async UploadFile(state, payload) {
      axios.post('https://localhost:44305/api/Orders/file/', payload).then(res => {

      }
      )
    }
      
    }
    
   

  },
)