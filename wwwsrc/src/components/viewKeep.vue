<template>
  <div class="viewKeep">
    <div class="card ">
      <img :src="keepData.img" class="card-img-top" />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <p class="card-text">
          <button class="btn btn-danger btn-sm" @click="Delete()">
            Delete
          </button>

<!-- test -->
<div class="dropdown">
      <button
        class="btn btn-sm btn-success dropdown-toggle"
        type="button"
        id="dropdownMenuButton"
        data-toggle="dropdown"
        aria-haspopup="true"
        aria-expanded="false"
      >
        Keep
      </button>
      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a
          class="dropdown-item "
          @click.prevent="AddToVault(this.Vault.id)"
          v-for="Vault in Vaults"
          :key="Vault.id"
          href="#"
          >{{ Vault.name }}</a
        >
      </div>
    </div>
          <button class="btn btn-danger btn-sm" @click="OpenKeep()">
            View
          </button>

          <!-- <button
            data-toggle="modal"
            data-target="#editVault"
            class="btn btn-sm btn-info"
          >
            Keep
          </button>
          <modal title="Add to Vault" id="editVault">
            <editVault></editVault>
          </modal> -->

          <small class="text-muted">add buttons here later</small>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "viewKeep",
  props: ["keepData"],
  data() {
    return {};
  },
  mounted(){
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    Vaults() {
      return this.$store.state.userVaults;
    },
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    },
    AddToVault() {
      this.$store.dispatch("addVaultKeep", this.keepdata.id, this.vault.id)
    },
    OpenKeep() {
      this.$store.commit("setActiveKeep", this.keepData),
        this.$router.push({
          name: "openKeep",
          params: { keepId: this.keepData.id },
        });
    },
  },
  components: {

  },
};
</script>

<style scoped></style>
