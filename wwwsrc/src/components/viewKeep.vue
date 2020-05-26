<template>
  <div class="viewKeep">
    <div class="card ">
      <img :src="keepData.img" class="card-img-top" />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <p class="card-text">
          <button class="btn btn-danger btn-small" @click="Delete()">
            Delete
          </button>
          <small class="text-muted">add buttons here later</small>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "viewKeep",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    imgUrl() {
      this.keepData.img = imgUrl;
      return imgUrl;
    },
    Delete() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    },
  },
  components: {},
};
</script>

<style scoped>
.card {
  width: ;
}
</style>
