<template>
  <div class="openVault">
    <div class="col-9 mb-1 mt-3 mx-auto d-flex justify-content-between">
      <h1>{{ activeVault.name }}</h1>
      <button class="btn btn-outline-danger btn-sm" @click="DeleteVault()">
        Delete Vault
      </button>
    </div>
    <div class="col-9 mb-1 mt-3 mx-auto d-flex justify-content-between">
      <h4>{{ activeVault.description }}</h4>
    </div>
    <!-- view vaulKeeps -->
    <div class="col-11 mx-auto card-deck">
      <viewVaultKeep v-for="keep in vaultKeeps" :keepData="keep" :key="keep.id">
      </viewVaultKeep>
    </div>
  </div>
</template>

<script>
import viewVaultKeep from "../components/viewVaultKeep";
export default {
  name: "openVault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.activeVaultKeeps;
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
  components: {
    viewVaultKeep,
  },
};
</script>

<style scoped></style>
