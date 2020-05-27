<template>
  <div class="viewVault col-12" @click="OpenVault()">
    <h2>{{ vaultData.name }}</h2>
    <h4 class="text-muted">{{ vaultData.description }}</h4>
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
