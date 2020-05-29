<template>
  <div class="createKeep">
    <form>
      <div class="form-group">
        <input
          required
          type="text"
          v-model="newKeep.name"
          class="form-control mb-3"
          placeholder="Name"
        />
        <input
          required
          type="text"
          v-model="newKeep.description"
          class="form-control mb-3"
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
            >Share As Public Keep<br />
            <small
              >Public Keeps are visible to everyone and cannot be deleted. Only
              you can see your Private Keeps on your dashboard, where you can
              also make them public later.</small
            >
          </label>
        </div>
      </div>
      <div class="d-flex justify-content-center">
        <button
          type="submit"
          @click.prevent="createKeep"
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
