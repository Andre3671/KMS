<template>
<div>
  <h1>Create Order</h1>
  <vs-input v-model="value" type="text"  label="Order number:" />
    <vs-input v-model="value" type="date" label="Hullnr:" />
      <vs-input v-model="value" type="date" label="Imo:" />
  <vs-input v-model="value" type="text" label="Vessel name:" />
  <vs-input v-model="value" type="text" label="Shipyard:" />
  <vs-input v-model="value" type="text" label="Owner:" />

    <vs-input v-model="value" type="text" label="Cycle:" />
      <vs-input v-model="value" type="text" label="Parts:" />
      <label for="spec">Specifications:</label>
        <textarea id="spec" />
  <vs-button>Create</vs-button>
</div>
</template>

<script>
export default {

}
</script>

<style>

</style>