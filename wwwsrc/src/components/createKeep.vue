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

        <div class="custom-control mt-3 m-1 custom-checkbox">
          <input
            type="checkbox"
            @click="save = !save"
            class="custom-control-input"
            id="customCheck1"
          />
          <label class="custom-control-label" for="customCheck1"
            >Share As Public Keep</label
          >
        </div>
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
      newKeep: {},
      save: false,
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    createKeep() {
      if (this.save) {
        this.newKeep.isPrivate = false;
      } else {
        this.newKeep.isPrivate = true;
      }
      this.$store.dispatch("createKeep", this.newKeep);
    },
  },
  components: {},
};
</script>

<style scoped></style>
