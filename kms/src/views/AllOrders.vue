<template>
  <div class="home">
     <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <h1> All orders</h1>
<div class="center">
      <vs-table       
        v-model="selected">
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th>
              <vs-checkbox
                :indeterminate="selected.length == $store.state.Orders.length" v-model="allCheck"
                @change="selected = $vs.checkAll(selected, $store.state.Orders)"
              />
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'orderId')">
              ORDER NO.
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'hullNr')">
              HULL NO.
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'vessel_name')">
              VESSEL´S NAME
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'shipyard')">
              Shipyard
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'owner')">
              Owner
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'deliveryDate')">
              Delivery date
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in  $vs.getSearch($store.state.Orders, search)"
            :data="tr"
              :is-selected="!!selected.includes(tr)"
          >
           <vs-td checkbox>
              <vs-checkbox :val="tr" v-model="selected" />
            </vs-td>
            <vs-td>
              {{ tr.orderId }}
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

            <template #expand>
              <div class="con-content">
                <div>
                  <h3>Order information</h3>
                  <p>Sales ID: {{tr.salesId}}</p>
                  <p>PRODUCT DELIVERED:</p><b></b>
                  <ul>
                  <li v-for="part in tr.partsOrdered" :key="part.partId">
                  <p>{{part.name}}: {{part.spec}}</p>
                  </li>
                  </ul>
                </div>
                <div style="float:right">
                <!--  <vs-button flat icon>
                    Send Email
                  </vs-button>
                  <vs-button border danger>
                    Reset Expiration
                  </vs-button> -->
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
export default {
  name: 'AllOrders',
  data() {
    return {
      allCheck: false,
        selected: [],
         search: '',
       users: this.$store.state.Orders,
    }
  },
  mounted: async function () {
   await this.$store.commit("GetOrders");
    console.log(this.users)
  },
  methods:{
    test:function(){
      var csvContent = "data:text/csv;charset=utf-8,";
      const columndata = Object.keys(this.selected[0]).map(key => `${key}`).join(",");
      csvContent += columndata + "\n";
      this.selected.forEach(element => {
        console.log(element)
        //eslint-disable-next-line
   const printData = Object.keys(element).map(key => `${element[key]}`).join(",   ");
    csvContent += printData + "\n";
      });
      console.log(csvContent)
      var encodedUri = encodeURI(csvContent);
      var link = document.createElement("a");
link.setAttribute("href", encodedUri);
link.setAttribute("download", "Orders.csv");
document.body.appendChild(link); // Required for FF

link.click();
    }
  }
}
</script>
<style lang="stylus">
</style>
