<template>
  <div class="home">
     <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <h1> All orders</h1>
<div class="center">
      <vs-table >
        <template #thead>
          <vs-tr>
            <vs-th>
              ORDER NO.
            </vs-th>
            <vs-th>
              HULL NO.
            </vs-th>
            <vs-th>
              VESSEL´S NAME
            </vs-th>
            <vs-th>
              Shipyard
            </vs-th>
            <vs-th>
              Owner
            </vs-th>
            <vs-th>
              Delivery date
            </vs-th>
          </vs-tr>
        </template>
        <template #tbody>
          <vs-tr
          :items="formartedItems"
            :key="i"
            v-for="(tr, i) in users"
          >
            <vs-td>
              {{ tr.Orderid }}
            </vs-td>
            <vs-td>
            {{ tr.Hullnr }}
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
            {{ tr.Expiration }}
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
                  <li v-for="part in tr.Parts" :key="part.spec">
                  <p>{{part.name}}: {{part.spec}}</p>
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
       users:[],
    }
  },
  mounted: function () {
    console.log(this.$store.state.Orders);
  },


}
</script>
<style lang="stylus">
</style>
