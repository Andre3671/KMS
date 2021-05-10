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
      data.forEach(element => {
        element.deliveryDate = element.deliveryDate.split('T')[0];
      });
      this.state.Orders = data;
      console.log(this.state.Orders);
    },
    async PostOrder(state, payload) {
      console.log(JSON.stringify(payload));
     var response = await fetch("https://localhost:44305/Orders/", {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'

        },
        body:JSON.stringify(payload)
    }).then(response => response)
     return(response)
      
    },
    async UploadFile(state, payload) {
      axios.post('https://localhost:44305/api/Orders/file/', payload).then(res => {
      }
      )
    }
      
    }
    
   

  },
)