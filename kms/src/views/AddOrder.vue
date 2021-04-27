<template>
<div>
  <h1>Create Order</h1>
  <vs-input v-model="Order.OrderId" type="text"  label="Order number:" />
    <vs-input v-model="Order.HullNr" type="text" label="Hullnr:" />
  <vs-input v-model="Order.Vessel_name" type="text" label="Vessel name:" />
  <vs-input v-model="Order.Shipyard" type="text" label="Shipyard:" />
  <vs-input v-model="Order.Owner" type="text" label="Owner:" />
    <vs-input v-model="Order.Buyer" type="text" label="Buyer:" />
<vs-input v-model="Order.DeliveryDate" type="date" label="DeliveryDate" />
    <vs-select placeholder="Cycle" label="Cycle:" v-model="Order.Cycle">
        <vs-option label="5 Years" value="5">
          5 Years
        </vs-option>
        <vs-option label="2 Years" value="2">
          2 Years
        </vs-option>
      </vs-select>
  <vs-button @click="active=!active">Create</vs-button>
<Dialogtest :PartList="Order" :Parts="Parts" :active="true" > </Dialogtest>

</div>
</template>

<script>
import Dialogtest from '../Components/AddPartDialog'
export default {
  components:{
    Dialogtest
  },
data:() => ({
  Order:{
        OrderId: '',
        HullNr: '',
        Vessel_name: '',
        Shipyard: '',
        Owner: '',
        Buyer: '',
        DeliveryDate: '',
        Cycle: "",
        Parts:[],
  }
      }),
      methods:{
        AddOrder:function(){
          this.$store.commit("PostOrder",this.Part)
        }
      }
}
</script>

<style>

</style>