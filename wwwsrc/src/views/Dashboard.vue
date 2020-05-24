<template>
  <div class="dashboard row m-0">
    <div class="col-12 ">
      <h1>WELCOME TO THE DASHBOARD</h1>
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
export default {
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.getters.keeps;
    },
  },
  components: {
    modal,
    createKeep,
  },
};
</script>

<style></style>
