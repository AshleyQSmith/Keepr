<template>
  <div class="home ">
    <div class="col-12 ">
      <!-- displays keeps -->
      <div class="card-group ">
        <viewKeep
          v-for="keep in keeps"
          :keepData="keep"
          :key="keep.id"
          class="card-group"
        ></viewKeep>
      </div>
    </div>
    <h1>Welcome Home</h1>
    <h3>
      this is where all of the keeps are displayed (not behind auth). Should be
      imported from a vue compotent that displays each keep in it's own card
    </h3>
  </div>
</template>

<script>
import viewKeep from "../components/viewKeep";
export default {
  name: "home",
  // data(){
  //   return {}
  // },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
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
