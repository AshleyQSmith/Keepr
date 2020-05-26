<template>
  <div class="createVault">
    <form>
      <div class="form-group">
        <input
          required
          type="text"
          v-model="newVault.name"
          class="form-control"
          placeholder="Name"
        />
        <input
          required
          type="text"
          v-model="newVault.description"
          class="form-control"
          placeholder="Description"
        />
      </div>

      <button
        type="submit"
        @click.prevent="createVault"
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
  name: "createVault",
  data() {
    return {
      newVault: {},
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
    },
  },
  components: {},
};
</script>

<style scoped></style>
