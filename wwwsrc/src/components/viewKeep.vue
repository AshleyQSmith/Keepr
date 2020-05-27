<template>
  <div class="viewKeep justify-content-center">
    <div class="card my-3" style="max-width: 18rem;">
      <img :src="keepData.img" class="card-img-top" />

      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <small class="text-muted"
          >Views: {{ keepData.views }} | Keeps: {{ keepData.keeps }} | Shares:
          {{ keepData.shares }}</small
        >
      </div>

      <div class="card-footer d-flex">
        <!-- view button -->
        <button class="btn btn-danger btn-sm" @click="OpenKeep()">
          View
        </button>
        <!-- keep button -->
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

        <!-- share button -->
        <button class="btn btn-info btn-sm" @click="Share()">
          Share
        </button>

        <!-- delete until it's moved -->
        <button class="btn btn-danger btn-sm" @click="Delete()">
          Delete
        </button>
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
  mounted() {
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
      this.$store.dispatch("addVaultKeep", this.keepdata.id, this.vault.id);
    },
    OpenKeep() {
      this.$store.commit("setActiveKeep", this.keepData),
        this.$router.push({
          name: "openKeep",
          params: { keepId: this.keepData.id },
        });
    },
    Share() {},
  },
  components: {},
};
</script>

<style scoped>
/* .card {
  max-width: 35vw;
} */
</style>
