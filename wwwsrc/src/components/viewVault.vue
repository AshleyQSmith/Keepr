<template>
  <div class="viewVault " @click="OpenVault()">
    <div class="list-group ">
      <a
        href="#"
        class="list-group-item list-group-item-action bg-primary my-1 border-secondary"
      >
        <div class="d-flex w-100 justify-content-between ">
          <h5 class="mb-1">{{ vaultData.name }}</h5>
        </div>
        <p class="mb-1">{{ vaultData.description }}</p>
      </a>
    </div>
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
