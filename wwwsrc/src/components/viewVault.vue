<template>
  <div class="viewVault " @click="OpenVault()">
    <!-- <h4>{{ vaultData.name }}</h4>
    <h6 class="text-muted">{{ vaultData.description }}</h6> -->

    <!-- test -->

    <div class="list-group ">
      <a
        href="#"
        class="list-group-item list-group-item-action bg-primary my-1 border-secondary"
      >
        <div class="d-flex w-100 justify-content-between ">
          <h5 class="mb-1">{{ vaultData.name }}</h5>
          <!-- <small class="text-muted">x</small> -->
        </div>
        <p class="mb-1">{{ vaultData.description }}</p>
      </a>
    </div>

    <!-- end test -->
  </div>
</template>

<script>
export default {
  name: "viewVault",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    OpenVault() {
      this.$store.commit("setActiveVault", this.vaultData),
        this.$router.push({
          name: "openVault",
          params: { vaultId: this.vaultData.id },
        });
    },
  },
  components: {},
};
</script>

<style scoped></style>
