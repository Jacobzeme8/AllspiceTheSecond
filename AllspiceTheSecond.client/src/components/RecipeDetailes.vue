<template>
  <div v-if="activeRecipe" class="component">
    <p>tests</p>
    <p>{{ activeRecipe.name }}</p>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe";
import { onMounted, computed } from "vue";
import { AppState } from "../AppState";

export default {
  props: {
    activeRecipe: {
      type: Object,
      required: true
    }
  },


  setup() {
    return {

    }
  }
}
</script>


<style lang="scss" scoped></style>