<template>
  <div class="openKeep my-5 col-10 mx-auto text-center">
    <img :src="activeKeep.img" class="img-fluid" />
    <h1>{{ activeKeep.name }}</h1>
    <h4>{{ activeKeep.description }}</h4>
    <p class="text-muted">
      Views {{ activeKeep.views }} | Keeps {{ activeKeep.keeps }} | Shares
      {{ activeKeep.shares }}
    </p>

    <!-- keep button -->
    <div class="d-flex justify-content-center">
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
            @click.prevent="AddToVault((newVaultKeep.vaultId = Vault.id))"
            v-for="Vault in Vaults"
            :key="Vault.id"
            href="#"
            >{{ Vault.name }}</a
          >
        </div>
      </div>

      <!-- share button -->
      <button class="btn btn-info btn-sm mx-3" @click="Share()">
        Share
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "openKeep",
  data() {
    return {
      newVaultKeep: {
        vaultId: "",
        keepId: this.$store.state.activeKeep.id,
      },
      countUpKeeps: {
        id: this.$store.state.activeKeep.id,
        isPrivate: this.$store.state.activeKeep.isPrivate,
        views: this.$store.state.activeKeep.views,
        keeps: this.$store.state.activeKeep.keeps + 1,
        shares: this.$store.state.activeKeep.shares,
      },
      countUpShares: {
        id: this.$store.state.activeKeep.id,
        isPrivate: this.$store.state.activeKeep.isPrivate,
        views: this.$store.state.activeKeep.views,
        keeps: this.$store.state.activeKeep.keeps,
        shares: this.$store.state.activeKeep.shares + 1,
      },
    };
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
    this.$store.dispatch("getVaultsByUser");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    Vaults() {
      return this.$store.state.userVaults;
    },
  },
  methods: {
    AddToVault(vaultId) {
      this.$store.dispatch("createVaultKeep", this.newVaultKeep);
      this.$store.dispatch("increaseKeepCount", this.countUpKeeps);
    },
    Share() {
      this.$store.dispatch("increaseShareCount", this.countUpShares);
    },
  },
  components: {},
};
</script>

<style scoped></style>
