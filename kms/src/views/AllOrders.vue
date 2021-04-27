<template>
  <div class="home">
     <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <h1> All orders</h1>
<div class="center">
      <vs-table >
        <template #header>
          <vs-input v-model="search" border placeholder="Search" />
        </template>
        <template #thead>
          <vs-tr>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'OrderId')">
              ORDER NO.
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'HullNr')">
              HULL NO.
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'Vessel_name')">
              VESSEL´S NAME
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'Shipyard')">
              Shipyard
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'Owner')">
              Owner
            </vs-th>
            <vs-th sort @click="$store.state.Orders = $vs.sortData($event ,$store.state.Orders, 'DeliveryDate')">
              Delivery date
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
            :key="i"
            v-for="(tr, i) in  $vs.getSearch($store.state.Orders, search)"
          >
            <vs-td>
              {{ tr.OrderId }}
            </vs-td>
            <vs-td>
            {{ tr.HullNr }}
            </vs-td>
            <vs-td>
            {{ tr.Vessel_name }}
            </vs-td>
            <vs-td>
            {{ tr.Shipyard }}
            </vs-td>
            <vs-td>
            {{ tr.Owner }}
            </vs-td>
            <vs-td>
            {{ tr.DeliveryDate }}
            </vs-td>

            <template #expand>
              <div class="con-content">
                <div>
                  <h3>Order information</h3>
                  <p>Sales ID: {{tr.SalesId}}</p>
                  <p>Hull number: {{tr.Hullnr}}</p>
                  <p>Sales Id: {{tr.SalesId}}</p>
                  <p>PRODUCT DELIVERED:</p><b></b>
                  <ul>
                  <li v-for="part in tr.PartsOrdered" :key="part.PartId">
                  <p>{{part.Name}}: {{part.Spec}}</p>
                  </li>
                  </ul>
                  <p>Cycle: {{tr.Cycle}}</p>
                </div>
                <div style="float:right">
                  <vs-button flat icon>
                    Send Email
                  </vs-button>
                  <vs-button border danger>
                    Reset Expiration
                  </vs-button>
                </div>
              </div>
            </template>
          </vs-tr>
        </template>
      </vs-table>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AllOrders',
  data() {
    return {
         search: '',
       users: this.$store.state.Orders,
    }
  },
  mounted: async function () {
   await this.$store.commit("GetOrders");
    console.log(this.users)
  },


}
</script>
<style lang="stylus">
</style>
