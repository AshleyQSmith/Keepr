<template>
  <div class="dashboard ">
    <div class="col-12 ">
      <h1>WELCOME TO YOUR DASHBOARD</h1>
    </div>
    <div class="col-12 ">
      <h2>
        My Vaults
      </h2>
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
      <!-- view vaults -->
      <viewVault
        v-for="vault in vaults"
        :vaultData="vault"
        :key="vault.id"
      ></viewVault>
    </div>

    <div class="col-12">
      <h2>My Keeps</h2>
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
      <!-- view keeps -->
      <viewKeep v-for="keep in keeps" :keepData="keep" :key="keep.id">
      </viewKeep>
    </div>
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
