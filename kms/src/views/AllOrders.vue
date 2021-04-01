<template>
  <div class="home">
     <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <h1> All orders</h1>
<div class="center">
      <vs-table >
        <template #thead>
          <vs-tr>
            <vs-th>
              OrderId
            </vs-th>
            <vs-th>
              Customer
            </vs-th>
            <vs-th>
              Expiration
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
            {{ tr.Customer }}
            </vs-td>
            <vs-td>
            {{ tr.Expiration }}
            </vs-td>

            <template #expand>
              <div class="con-content">
                <div>
                  <h3>Order information</h3>
                  <p>Hull number: {{tr.Hullnr}}</p>
                  <p>Sales Id: {{tr.SalesId}}</p>
                  <p>Order: {{tr.Order}}</p>
                  <p>Hull number: {{tr.Cycle}}</p>
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
       users:[
      {
        "Orderid": 1,
        "Customer": "Leanne Graham",
        "Hullnr": "Bret",
        "SalesId": "Sincere@april.biz",
        "Order": "hildegard.org",
        "Expiration":"2021-08-05",
        "Cycle":"2"
      },
      {
        "Orderid": 2,
        "Customer": "Ervin Howell",
        "Hullnr": "Antonette",
        "SalesId": "Shanna@melissa.tv",
        "Order": "anastasia.net",
        "Expiration":"2021-08-05",
        "Cycle":"2"
      }
       ],
    }
  },
  methods:{
    GetDate:function() {
var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
var dateTime = date+' '+time;
return dateTime;
    },
    getVariant:function(status) {
    switch (status) {
      case 1:
        return 'success'
      case 2:
        return 'danger'
      default:
        return 'active'
    }
  }
  },
  computed: {
  formartedItems () {
    console.log("test");
    if (!this.users) return [console.log("kebab")]
    return this.users.map(item => {
      console.log(item);
      item  = this.getVariant(item.Orderid)
      return item
    })
  }
}
}
</script>
<style lang="stylus">
</style>
