<template>
  <div class="card d-flex align-items-center">
    <img class="img-fluid recipe-img " :src="recipe.img" alt="">
    <p>Title: {{ recipe.title }}</p>
    <p>Category: {{ recipe.category }}</p>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe";

export default {

  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },

  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.recipe-img {
  height: 30vh;
  width: 100%;
  object-fit: cover;
}
</style>