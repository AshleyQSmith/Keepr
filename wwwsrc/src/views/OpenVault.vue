<template>
  <div class="openVault">
    <h1>{{ activeVault.name }}</h1>
    <h4>{{ activeVault.description }}</h4>

    <!-- not sure if this will work, since have to pull in keeps for jsut this vault? -->
    <!-- <viewKeep v-for="keep in keeps" :keepData="keep" :key="keep.id"> </viewKeep> -->
  </div>
</template>

<script>
export default {
  name: "openVault",
  props: ["activeVault"],
  data() {
    return {};
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
  },
  methods: {},
  components: {},
};
</script>

<style scoped></style>
