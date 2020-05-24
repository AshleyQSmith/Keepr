<template>
  <div class="viewKeep">
    <div class="card">
      //TODO - figure out how to draw in img url
      <!-- <img src="{{keepData.img}}" class="card-img-top" /> -->
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <p class="card-text">
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
  methods: {},
  components: {},
};
</script>

<style scoped></style>
