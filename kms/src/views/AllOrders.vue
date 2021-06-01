<template>
  <div class="home">
    <head>
        <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
    </head>
  
    <h1>All orders</h1>
    <div class="center">
   <EditOrderDialog :dialogactive='this.active' :Order='this.EditOrder'/>
      <vs-table v-model="selected">
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th>
              <vs-checkbox
                :indeterminate="selected.length == $store.state.Orders.length"
                v-model="allCheck"
                @change="selected = $vs.checkAll(selected, $store.state.Orders)"
              />
            </vs-th>
            <vs-th>
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'orderNumber'
                )
              "
            >
              ORDER NO.
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'hullNr'
                )
              "
            >
              HULL NO.
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'vessel_name'
                )
              "
            >
              VESSEL´S NAME
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'shipyard'
                )
              "
            >
              Shipyard
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'owner'
                )
              "
            >
              Owner
            </vs-th>
            <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'deliveryDate'
                )
              "
            >
              Port Loadingdate
            </vs-th>
             <vs-th
              sort
              @click="
                $store.state.Orders = $vs.sortData(
                  $event,
                  $store.state.Orders,
                  'delivery'
                )
              "
            >
              Delivery date
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in $vs.getSearch($store.state.Orders, search)"
            :data="tr"
            :is-selected="!!selected.includes(tr)"
            v-bind:id="tr.deliveryIsClose"
          >
            <vs-td checkbox>
              <vs-checkbox :val="tr" v-model="selected" />
            </vs-td>
            <vs-td>
              <p>
              <i v-if="tr.deliveryIsClose != ''" class="material-icons-outlined" v-bind:class="tr.deliveryIsClose"> access_alarm </i></p>
            </vs-td>
            <vs-td>
              {{ tr.orderNumber }}
            </vs-td>
            <vs-td>
              {{ tr.hullNr }}
            </vs-td>
            <vs-td>
              {{ tr.vessel_name }}
            </vs-td>
            <vs-td>
              {{ tr.shipyard }}
            </vs-td>
            <vs-td>
              {{ tr.owner }}
            </vs-td>
            <vs-td>
              {{ tr.deliveryDate }}
            </vs-td>
            <vs-td>
              {{ tr.delivery }}
            </vs-td>

            <template #expand>
              <div class="con-content">
                <div>
                  <h3>Order information</h3>
                  <p>Sales ID: {{ tr.salesId }}</p>
                  <p>PRODUCT DELIVERED:</p>
                  <b></b>
                  <ul>
                    <li v-for="part in tr.partsOrdered" :key="part.partId">
                      <p>{{ part.name }}: {{ part.spec }}</p>
                    </li>
                  </ul>
                </div>
                <div style="float: right">
                   <vs-button @click="OpenDialog(tr.orderId)" >
                    Edit Order
                  </vs-button>
 
                </div>
              </div>
            </template>
          </vs-tr>
        </template>
      </vs-table>
      <vs-button @click="test()">Export selected</vs-button>
    </div>
  </div>
</template>
<script>
import 'material-icons/iconfont/material-icons.css';
import EditOrderDialog from '../components/EditOrderDialog'
export default {
  name: "AllOrders",
  components:{
    EditOrderDialog
  },
  data() {
    return { 
      active: false,
      allCheck: false,
      selected: [],
      search: "",
      users: this.$store.state.Orders,
      EditOrder: {},
    };
  },
  mounted: async function () {
    await this.$store.commit("GetOrders");
  },
  methods: {
     OpenDialog: function(orderid) {
       this.$store.state.dialogactive =! this.$store.state.dialogactive;
       console.log(this.users);
       var selectedrow = this.$store.state.Orders.find(a => a.orderId == orderid);
       console.log(selectedrow)
       this.$store.state.UpdateOrder = selectedrow;
       console.log(this.$store.state.UpdateOrder)
       console.log(orderid)

    },
    Edit: function(Order) {
       this.$store.commit("EditOrder",Order)
    },
    test: function () {
      var csvContent = "data:text/csv;charset=utf-8,";
      const columndata = Object.keys(this.selected[0])
        .map((key) => `${key}`)
        .join(",");
      csvContent += columndata + "\n";
      console.log(this.selected);
      this.selected.forEach((element) => {
        csvContent += element.orderId + ",";
        csvContent += element.vessel_name + ",";
        csvContent += element.shipyard + ",";
        csvContent += element.owner + ",";
        csvContent += element.hullNr + ",";
        csvContent += element.salesId + ",";
        csvContent += element.buyer + ",";
        csvContent += element.deliveryDate + ",";
        var parts = [];
        var OrderParts = "";
        if (element.partsOrdered.length > 0) {
          OrderParts += '"';
          element.partsOrdered.forEach((part) => {
            if (part.name.length > 0) {
              OrderParts += part.name;
              console.log(OrderParts);
            }
            if (part.spec.length > 0) {
              OrderParts += part.spec;
              console.log(OrderParts);
            }
            OrderParts += "\r\n";
            parts.push(OrderParts);
            OrderParts = "";
          });
          parts.forEach((part) => {
            console.log(part);
            csvContent += part + "\n";
          });
          csvContent += '"' + "\n";
        }
      });

      console.log(csvContent);
      var encodedUri = encodeURI(csvContent);
      var link = document.createElement("a");
      link.setAttribute("href", encodedUri);
      link.setAttribute("download", "Orders.xlsx");
      document.body.appendChild(link); // Required for FF

      link.click();
    },
  },
};
</script>
<style >
</style>
