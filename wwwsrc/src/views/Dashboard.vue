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

    <h3>
      This is where users can create new vaults AND keeps (prop 2 buttons or
      forms)
    </h3>
    <h3>
      This is where the users's vaults display, ONLY PLACE THESE DISPLAY -
      PRIVATE TO USER, on click, opens vault to show all keeps inside
    </h3>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import modal from "../components/modal";
import createKeep from "../components/createKeep";
import createVault from "../components/createVault";
export default {
  mounted() {
    this.$store.dispatch("getAllKeeps");
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.getters.usersKeeps;
    },
  },
  components: {
    modal,
    createKeep,
    createVault,
  },
};
</script>

<style></style>
