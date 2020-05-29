<template>
  <div class="viewMyKeep ">
    <div class="card my-3 " style="max-width: 18rem;">
      <img :src="keepData.img" class="card-img-top" />

      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <small class="text-muted" v-if="!keepData.isPrivate"
          >Views: {{ keepData.views }} | Keeps: {{ keepData.keeps }} | Shares:
          {{ keepData.shares }}</small
        >
      </div>

      <div
        v-if="!keepData.isPrivate"
        class="card-footer d-flex justify-content-center"
      >
        <!-- view button -->
        <button
          class="btn btn-danger text-secondary btn-sm mx-auto"
          @click="OpenKeep()"
        >
          View
        </button>
        <!-- keep button -->
        <div class="dropdown mx-auto">
          <button
            class="btn btn-sm text-secondary btn-success dropdown-toggle"
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

      <div v-if="keepData.isPrivate" class="justify-content-center mb-2 mx-3">
        <!-- make public button -->
        <button
          class="btn btn-primary border-0 text-secondary mx-auto btn-block"
          @click="setKeepPublic()"
        >
          Make Public
        </button>

        <!-- delete button -->
        <button
          class="btn btn-outline-danger mx-auto btn-block"
          @click="Delete()"
        >
          Delete
        </button>
      </div>

      <!-- </div> -->
    </div>
  </div>
</template>

<script>
export default {
  name: "viewMyKeep",
  props: ["keepData"],
  data() {
    return {
      newVaultKeep: {
        vaultId: "",
        keepId: this.keepData.id,
      },
      publicKeep: {
        id: this.keepData.id,
        isPrivate: false,
        views: this.keepData.views,
        keeps: this.keepData.keeps,
        shares: this.keepData.shares,
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
    setKeepPublic() {
      this.$store.dispatch("setKeepPublic", this.publicKeep);
    },
    AddToVault(vaultID) {
      this.$store.dispatch("createVaultKeep", this.newVaultKeep);
      this.$store.dispatch("increaseKeepCount", this.countUpKeeps);
    },

    OpenKeep() {
      this.$store.dispatch("increaseViewCount", this.countUpViews);
      this.$store.commit("setActiveKeep", this.keepData),
        this.$router.push({
          name: "openKeep",
          params: { keepId: this.keepData.id },
        });
    },
    Share() {
      this.$store.dispatch("increaseShareCount", this.countUpShares);
    },
  },
  components: {},
};
</script>

<style scoped></style>
