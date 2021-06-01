
  <template>
  <div>
    <vs-dialog blur v-model="$store.state.dialogactive">
      <template #header>
        <h4 class="not-margin">Update order</h4>
       <!-- <h4 class="not-margin">{{}}</h4> -->
      </template>
        <div class="center grid">
          <vs-row>
            <vs-col vs-type="flex" vs-justify="center"  vs-align="center" w="5">
              <vs-input
                type="text"
                label="Order number:"
                :placeholder="this.Order.orderNumber"
                v-model="$store.state.UpdateOrder.orderNumber"
              />
              <vs-input type="text"  :placeholder="this.Order.hullNr" label="Hullnr:" v-model="$store.state.UpdateOrder.hullNr" />
              <vs-input
                :placeholder="this.Order.vessel_name"
                type="text"
                label="Vessel name:"
                v-model="$store.state.UpdateOrder.vessel_name"
              />
              <vs-input  type="text"  :placeholder="this.Order.shipyard" v-model="$store.state.UpdateOrder.shipyard" label="Shipyard:" />
              <vs-input  type="text" label="Owner:"  :placeholder="this.Order.owner" v-model="$store.state.UpdateOrder.owner" />
              <vs-input :placeholder="Order.buyer" type="text" label="Buyer:" v-model="$store.state.UpdateOrder.buyer" />
              <vs-input
                type="date"
                label="Port loading date"
                 :placeholder="this.Order.deliveryDate"
                 v-model="$store.state.UpdateOrder.deliveryDate"
              />
              <vs-input
                type="date"
                label="DeliveryDate"
                 :placeholder="this.Order.delivery"
                 v-model="$store.state.UpdateOrder.delivery"
              />
              <vs-button @click="test()">Update</vs-button>
            </vs-col>
          </vs-row>
            
        </div>
    
      </vs-dialog>
  </div>
</template>
        
    
    <script>
    export default {
      name:'EditOrderDialog',
    props:{
        dialogactive: Boolean,
        Order: {},
    },
    data (){
        return{
            active: this.dialogactive,
             UpdateOrder:{
               orderId:0,
        orderNumber:'',
        hullNr: '',
        vessel_name: '',
        shipyard: '',
        owner: '',
        buyer: '',
        deliveryDate: '',
        delivery:'',
        PartsOrdered:[],
  },
       EditOrder:{
         orderId:0,
        orderNumber:'',
        hullNr: '',
        vessel_name: '',
        shipyard: '',
        owner: '',
        buyer: '',
        deliveryDate: '',
        delivery:'',
        PartsOrdered:[],
  },
        }
    },
    methods:{
      test: async function() {
       await this.$store.commit("EditOrder",this.$store.state.UpdateOrder);
       window.location.reload(false);
      }
    },
    mounted: async function (){
            console.log("test");
    }
};
</script>
 
  
  <style>
</style>