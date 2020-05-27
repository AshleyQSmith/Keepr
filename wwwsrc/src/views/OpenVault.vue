<template>
  <div class="openVault">
    <h1>{{ activeVault.name }}</h1>
    <h4>{{ activeVault.description }}</h4>
    <button class="btn btn-outline-danger btn-sm" @click="DeleteVault()">
      Delete Vault
    </button>
    <!-- not sure if this will work, since have to pull in keeps for jsut this vault? -->
    <!-- <viewKeep v-for="keep in keeps" :keepData="keep" :key="keep.id"> </viewKeep> -->
  </div>
</template>

<script>
export default {
  name: "openVault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
  },
  methods: {
    DeleteVault() {
      this.$store.dispatch("deleteVault", this.activeVault.id);
      this.$router.push({
        name: "dashboard",
      });
    },
  },
  components: {},
};
</script>

<style scoped></style>
