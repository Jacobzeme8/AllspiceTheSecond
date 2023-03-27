<template>
  <div v-if="recipe" class="modal-content">
    <div class="modal-header">
      <h1 class="modal-title text-dark fs-5" id="exampleModalLabel">
        {{ recipe.title }}
      </h1>
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
    </div>
    <div class="modal-body">
      <div class="component">
        <div class="container-fluid">
          <div class="row">
            <div class="col-6">
              <p>{{ recipe.title }}</p>
            </div>
            <div class="col-6">
              <img class="img-fluid" :src="recipe.img" alt="">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe";
import { onMounted, computed } from "vue";
import { AppState } from "../AppState";

export default {
  // props: {
  //   recipe: {
  //     type: Object,
  //     required: true
  //   }
  // },


  setup() {
    return {
      recipe: computed(() => AppState.acitiveRecipe),
    }
  }
}
</script>


<style lang="scss" scoped></style>