<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <h3>
      this is where all of the keeps are displayed (not behind auth). Should be
      imported from a vue compotent that displays each keep in it's own card
    </h3>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
