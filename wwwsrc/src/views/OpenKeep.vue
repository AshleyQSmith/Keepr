<template>
  <div class="openKeep mt-3 col-10 mx-auto text-center">
    <img :src="activeKeep.img" class="img-fluid" />
    <h1>{{ activeKeep.name }}</h1>
    <h4>{{ activeKeep.description }}</h4>
    <p class="text-muted">
      Views: {{ activeKeep.views }} | Keeps: {{ activeKeep.keeps }} | Shares:
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
            @click.prevent="AddToVault(this.Vault.id)"
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
    return {};
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
    AddToVault() {
      this.$store.dispatch("addVaultKeep", this.activeKeep.id, this.vault.id);
    },
  },
  components: {},
};
</script>

<style scoped></style>
