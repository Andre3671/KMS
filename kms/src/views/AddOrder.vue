<template>
<div>
  <h1>Create Order</h1>
   <div class="center grid">
        <vs-row>
      <vs-col  vs-type="flex" vs-justify="center" vs-align="center" w="3">
       <vs-input v-model="Order.OrderNumber" type="text"  label="Order number:" />
    <vs-input v-model="Order.HullNr" type="text" label="Hullnr:" />
  <vs-input v-model="Order.Vessel_name" type="text" label="Vessel name:" />
  <vs-input v-model="Order.Shipyard" type="text" label="Shipyard:" />
  <vs-input v-model="Order.Owner" type="text" label="Owner:" />
    <vs-input v-model="Order.Buyer" type="text" label="Buyer:" />
<vs-input v-model="Order.DeliveryDate" type="date" label="DeliveryDate" />
    <!-- <vs-select placeholder="Cycle" label="Cycle:" v-model="Order.Cycle">
        <vs-option label="5 Years" value="5">
          5 Years
        </vs-option>
        <vs-option label="2 Years" value="2">
          2 Years
        </vs-option>
      </vs-select> -->
      </vs-col>
      <vs-col  vs-type="flex" vs-justify="center" vs-align="center" w="4">
        <h3>Parts:</h3>
<vs-table>
    <template #thead>
      <vs-tr>
        <vs-th>
          Partname
        </vs-th>
        <vs-th>
          Specifications
        </vs-th>
      </vs-tr>
    </template>
    <template #tbody>
      <vs-tr
        :key="i"
        v-for="(tr, i) in Order.PartsOrdered"
        :data="tr"
      >
        <vs-td>
          {{ tr.Name }}
        </vs-td>
        <vs-td>
         {{ tr.Spec }}
        </vs-td>
      </vs-tr>
    </template>
  </vs-table>
      </vs-col>
    </vs-row>

  <vs-button @click="active=!active">Add Part</vs-button>
  <vs-button @click="AddOrder()">Add order</vs-button>
   </div>
<vs-dialog blur v-model="active" >
     <vs-input v-model="Part.Name" label="Part Name"></vs-input>
     <p for="spec">Specifications</p>
     <textarea v-model="Part.Spec" id="spec"></textarea>
    <vs-button @click="AddPart()">Add</vs-button>
</vs-dialog>
</div>
</template>

<script>
export default {
  components:{

  },
data:() => ({
  active:false,
  Order:{
    OrderNumber:'',
        HullNr: '',
        Vessel_name: '',
        Shipyard: '',
        Owner: '',
        Buyer: '',
        DeliveryDate: '',
        Cycle: "",
        PartsOrdered:[],
  },
  Part:{
    Name:"",
    Spec:"",
  }
      }),
      methods:{
        AddOrder:function(){
          console.log(JSON.stringify(this.Order))
         var result = this.$store.commit("PostOrder",this.Order)
          this.$vs.notification({
            color:"success",
            title: 'Saved!',
            text: `The order was succesfully saved`
          })
         console.log(result)
        },
        AddPart:function(){
          this.Order.PartsOrdered.push(this.Part);
          this.Part = {Name:"",Spec:"",}
          console.log(this.Order.PartsOrdered);
        }
      }
}
</script>

<style>
#spec{
      width: 359px;
    height: 271px;
    resize: none;
}
</style>