<template>
  <div class="about">
    <h1>My orders</h1>
<vs-table :data="users">
      <template slot="thead">
        <vs-th>
          Email
        </vs-th>
        <vs-th>
          Name
        </vs-th>
        <vs-th>
          Nro1
        </vs-th>
        <vs-th>
          Nro2
        </vs-th>
      </template>

      <template slot-scope="{data}">
        <vs-tr :key="indextr" v-for="(tr, indextr) in data" >
          <vs-td :data="tr.email">
            {{tr.email}}

            <template slot="edit">
              <vs-input v-model="tr.email" class="inputx" placeholder="Email"/>
            </template>
          </vs-td>

          <vs-td :data="tr.username">
            {{tr.username}}

            <template slot="edit">
              <vs-select
                label="Users"
                v-model="tr.username"
                >
                <vs-select-item :key="index" :vs-value="item.name" :vs-text="item.name" v-for="(item,index) in users" />
              </vs-select>
            </template>
          </vs-td>

          <vs-td :data="tr.id">
            {{tr.id}}

            <template slot="edit">
              <vs-input-number v-model="tr.id"/>
            </template>
          </vs-td>

          <vs-td :data="tr.id">
            {{tr.id}}

            <template slot="edit">
              <vs-slider :max="20" v-model="tr.id"/>
            </template>
          </vs-td>

        </vs-tr>
      </template>
    </vs-table>
  </div>
</template>

<script>

export default {
  name: 'AllOrders',
  data() {
    return {
       users:[
      {
        "id": 1,
        "name": "Leanne Graham",
        "username": "Bret",
        "email": "Sincere@april.biz",
        "website": "hildegard.org",
      },
      {
        "id": 2,
        "name": "Ervin Howell",
        "username": "Antonette",
        "email": "Shanna@melissa.tv",
        "website": "anastasia.net",
      },
      {
        "id": 3,
        "name": "Clementine Bauch",
        "username": "Samantha",
        "email": "Nathan@yesenia.net",
        "website": "ramiro.info",
      },
      {
        "id": 4,
        "name": "Patricia Lebsack",
        "username": "Karianne",
        "email": "Julianne.OConner@kory.org",
        "website": "kale.biz",
      },
      {
        "id": 5,
        "name": "Chelsey Dietrich",
        "username": "Kamren",
        "email": "Lucio_Hettinger@annie.ca",
        "website": "demarco.info",
      },
      {
        "id": 6,
        "name": "Mrs. Dennis Schulist",
        "username": "Leopoldo_Corkery",
        "email": "Karley_Dach@jasper.info",
        "website": "ola.org",
      },
      {
        "id": 7,
        "name": "Kurtis Weissnat",
        "username": "Elwyn.Skiles",
        "email": "Telly.Hoeger@billy.biz",
        "website": "elvis.io",
      },
      {
        "id": 8,
        "name": "Nicholas Runolfsdottir V",
        "username": "Maxime_Nienow",
        "email": "Sherwood@rosamond.me",
        "website": "jacynthe.com",
      },
      {
        "id": 9,
        "name": "Glenna Reichert",
        "username": "Delphine",
        "email": "Chaim_McDermott@dana.io",
        "website": "conrad.com",
      },
      {
        "id": 10,
        "name": "Clementina DuBuque",
        "username": "Moriah.Stanton",
        "email": "Rey.Padberg@karina.biz",
        "website": "ambrose.net",
      }
    ]
    }
  },
  methods:{
    GetDate:function() {
var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
var dateTime = date+' '+time;
return dateTime;
    }
  }
}
</script>
<style lang="stylus">
</style>
