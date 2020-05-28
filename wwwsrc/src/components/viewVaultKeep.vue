<template>
  <div class="viewVaultKeep justify-content-center">
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

      <div class="card-footer d-flex justify-content-center">
        <!-- view button -->
        <button class="btn btn-danger btn-sm mx-auto" @click="OpenKeep()">
          View
        </button>
        <!-- keep button -->
        <div class="dropdown mx-auto">
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
              v-for="Vault in Vaults"
              :key="Vault.id"
              href="#"
              @click.prevent="AddToVault((newVaultKeep.vaultId = Vault.id))"
              >{{ Vault.name }}</a
            >
          </div>
        </div>

        <!-- share button -->
        <button class="btn btn-info btn-sm mx-auto" @click="Share()">
          Share
        </button>
      </div>

      <!-- remove button -->
      <button class="btn btn-outline-danger btn-sm" @click="RemoveFromVault()">
        Remove From Vault
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "viewVaultKeep",
  props: ["keepData"],
  data() {
    return {
      newVaultKeep: {
        vaultId: "",
        keepId: this.keepData.id,
      },
      // vaultKeepData: {
      //   vaultKeepId: this.keepData.vaultKeepId,
      //   vaultId: this.keepdata.vaultId,
      // },
    };
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
    AddToVault(vaultID) {
      this.$store.dispatch("createVaultKeep", this.newVaultKeep);
    },
    OpenKeep() {
      this.$store.commit("setActiveKeep", this.keepData),
        this.$router.push({
          name: "openKeep",
          params: { keepId: this.keepData.id },
        });
    },
    RemoveFromVault() {
      this.$store.dispatch("deleteVaultKeep", this.keepData.vaultKeepId);
    },
    Share() {},
  },
  components: {},
};
</script>

<style scoped></style>
