<template>
  <div class="openKeep col-10 mx-auto text-center">
    <img :src="activeKeep.img" class="img-fluid" />
    <h1>{{ activeKeep.name }}</h1>
    <h4>{{ activeKeep.description }}</h4>
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
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {},
  components: {},
};
</script>

<style scoped></style>
