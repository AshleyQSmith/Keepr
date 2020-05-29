<template>
  <div class="createVault">
    <form>
      <div class="form-group">
        <input
          required
          type="text"
          v-model="newVault.name"
          class="form-control mb-3"
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
      <div class="d-flex justify-content-center">
        <button
          type="submit"
          @click.prevent="createVault"
          class="btn btn-success btn-small"
          data-dismiss="modal"
        >
          Submit
        </button>
      </div>
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
