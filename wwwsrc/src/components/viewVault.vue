<template>
  <div class="viewVault col-12">
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
  methods: {},
  components: {},
};
</script>

<style scoped></style>
