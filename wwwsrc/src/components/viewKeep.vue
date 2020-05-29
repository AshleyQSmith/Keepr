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

      <div
        v-if="$auth.isAuthenticated"
        class="card-footer d-flex justify-content-center"
      >
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
    </div>
  </div>
</template>

<script>
export default {
  name: "viewKeep",
  props: ["keepData"],
  data() {
    return {
      newVaultKeep: {
        vaultId: "",
        keepId: this.keepData.id,
      },
      countUpKeeps: {
        id: this.keepData.id,
        isPrivate: this.keepData.isPrivate,
        views: this.keepData.views,
        keeps: this.keepData.keeps + 1,
        shares: this.keepData.shares,
      },
      countUpViews: {
        id: this.keepData.id,
        isPrivate: this.keepData.isPrivate,
        views: this.keepData.views + 1,
        keeps: this.keepData.keeps,
        shares: this.keepData.shares,
      },
      countUpShares: {
        id: this.keepData.id,
        isPrivate: this.keepData.isPrivate,
        views: this.keepData.views,
        keeps: this.keepData.keeps,
        shares: this.keepData.shares + 1,
      },
    };
  },
  mounted() {
    if (this.$auth.isAuthenticated) {
      this.$store.dispatch("getVaultsByUser");
    }
  },
  computed: {
    Vaults() {
      if (this.$auth.isAuthenticated) {
        return this.$store.state.userVaults;
      }
    },
  },
  methods: {
    AddToVault(vaultID) {
      this.$store.dispatch("createVaultKeep", this.newVaultKeep);
      this.$store.dispatch("increaseKeepCount", this.countUpKeeps);
    },
    OpenKeep() {
      this.$store.commit("setActiveKeep", this.keepData),
        this.$router.push({
          name: "openKeep",
          params: { keepId: this.keepData.id },
        });
      this.$store.dispatch("increaseViewCount", this.countUpViews);
    },
    Share() {
      this.$store.dispatch("increaseShareCount", this.countUpShares);
    },
  },
  components: {},
};
</script>

<style scoped></style>
