<template>
  <div class="openVault">
    <h1>{{ activeVault.name }}</h1>
    <h4>{{ activeVault.description }}</h4>
    <button class="btn btn-outline-danger btn-sm" @click="DeleteVault()">
      Delete Vault
    </button>
    <viewVaultKeep v-for="keep in vaultKeeps" :keepData="keep" :key="keep.id">
    </viewVaultKeep>
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
