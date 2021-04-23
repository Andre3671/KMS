import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
/* eslint-disable no-unused-vars */
export default new Vuex.Store({
  state: {
    Orders: [
        {
          "Orderid": 1,
          "Vessel_name": "KNOCK NALLING",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NB708",
          "Parts":{
            "part1":{
              "name":"Slang",
              "spec":"lång",
            },
            "part2":{
              "name":"Slang",
              "spec":"kort",
            },
          },
          "SalesId": 12,
          "Order": "hildegard.org",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NB790",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NB800",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NB810",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NB820",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NA830",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        },
        {
          "Orderid": 2,
          "Vessel_name": "SYRA",
          "Shipyard":"UDDEVALLA SHIPYARD",
          "Owner":"JENSEN",
          "Hullnr": "NC590",
              "Parts":{
            "part1":{
              "name":"Mutter",
              "spec":"Liten",
            },
            "part2":{
              "name":"Svänghjul",
              "spec":"3m diameter",
            },
          },
          "SalesId": 13,
          "Order": "anastasia.net",
          "Expiration":"2021-08-05",
          "Cycle":"2"
        }
         ],
  },
  mutations: {
    GetOrders(state, payload){
          },
  }
})