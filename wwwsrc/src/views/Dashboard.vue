<template>
  <div class="dashboard ">
    <div class="col-9 mb-1 mt-3 mx-auto d-flex justify-content-between">
      <h2>
        My Vaults
      </h2>
      <!-- add vault -->
      <button
        data-toggle="modal"
        data-target="#createVault"
        class="btn btn-sm btn-info text-secondary"
      >
        Add Vault
      </button>
      <modal title="New Vault" id="createVault">
        <createVault></createVault>
      </modal>
    </div>
    <!-- view vaults -->
    <div class="col-10 mx-auto">
      <viewVault
        v-for="vault in vaults"
        :vaultData="vault"
        :key="vault.id"
      ></viewVault>
    </div>

    <div class="col-9 mb-1 mt-5 mx-auto d-flex justify-content-between">
      <h2>My Keeps</h2>
      <!-- add keep -->
      <button
        data-toggle="modal"
        data-target="#createKeep"
        class="btn btn-sm btn-info text-secondary"
      >
        Add Keep
      </button>
      <modal title="New Keep" id="createKeep">
        <createKeep></createKeep>
      </modal>
    </div>
    <!-- view keeps -->
    <div class="col-11 mx-auto card-deck justify-content-center">
      <viewMyKeep
        v-for="keep in keeps"
        :keepData="keep"
        :key="keep.id"
      ></viewMyKeep>
    </div>
  </div>
</template>

<script>
import modal from "../components/modal";
import createKeep from "../components/createKeep";
import createVault from "../components/createVault";
import viewMyKeep from "../components/viewMyKeep";
import viewVault from "../components/viewVault";
export default {
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    // user() {
    //   return this.$store.state.user;
    // },
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
    viewMyKeep,
    viewVault,
  },
};
</script>

<style></style>
