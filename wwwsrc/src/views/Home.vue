<template>
  <div class="home ">
    <!-- displays keeps -->
    <div class="col-12 card-deck justify-content-center">
      <viewKeep
        v-for="keep in keeps"
        :keepData="keep"
        :key="keep.id"
      ></viewKeep>
    </div>
  </div>
</template>

<script>
import viewKeep from "../components/viewKeep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    viewKeep,
  },
};
</script>

<style scoped></style>
