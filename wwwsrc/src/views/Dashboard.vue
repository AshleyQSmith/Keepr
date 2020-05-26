<template>
  <div class="dashboard ">
    <div class="col-12 ">
      <h1>WELCOME TO THE DASHBOARD</h1>
      <!-- add keep -->
      <button
        data-toggle="modal"
        data-target="#createKeep"
        class="btn btn-sm btn-success"
      >
        Add Keep
      </button>
      <modal title="New Keep" id="createKeep">
        <createKeep></createKeep>
      </modal>
      <!-- add vault -->
      <button
        data-toggle="modal"
        data-target="#createVault"
        class="btn btn-sm btn-info"
      >
        Add Vault
      </button>
      <modal title="New Vault" id="createVault">
        <createVault></createVault>
      </modal>
    </div>

    <h2>
      My Vaults
    </h2>
    <viewVault
      v-for="vault in vaults"
      :vaultData="vault"
      :key="vault.id"
    ></viewVault>
    <h2>My Keeps</h2>
    <viewKeep v-for="keep in keeps" :keepData="keep" :key="keep.id"> </viewKeep>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import modal from "../components/modal";
import createKeep from "../components/createKeep";
import createVault from "../components/createVault";
import viewKeep from "../components/viewKeep";
import viewVault from "../components/viewVault";
export default {
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.userVaults;
    },
  },
  components: {
    modal,
    createKeep,
    createVault,
    viewKeep,
    viewVault,
  },
};
</script>

<style></style>
