<template>
  <div class="createKeep">
    <form>
      <div class="form-group">
        <input
          required
          type="text"
          v-model="newKeep.name"
          class="form-control"
          placeholder="Name"
        />
        <input
          required
          type="text"
          v-model="newKeep.description"
          class="form-control"
          placeholder="Description"
        />
        <input
          required
          type="text"
          v-model="newKeep.img"
          class="form-control"
          placeholder="Image URL"
        />
      </div>

      <button
        type="submit"
        @click.prevent="createKeep"
        class="btn btn-success btn-small"
        data-dismiss="modal"
      >
        Submit
      </button>
    </form>
  </div>
</template>

<script>
export default {
  name: "createKeep",
  data() {
    return {
      newKeep: {
        // may need to change this to 0 to match c# bool
        isPrivate: false,
      },
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    },
  },
  components: {},
};
</script>

<style scoped></style>
