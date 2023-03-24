<template>
  <div class="card d-flex align-items-center">
    <img @click="setActiveRecipe(recipe.id)" class="img-fluid recipe-img selectable " :src="recipe.img"
      data-bs-toggle="modal" data-bs-target="#recipe-modal" alt="">
    <p>Title: {{ recipe.title }}</p>
    <p>Category: {{ recipe.category }}</p>
  </div>
  <Modal id="recipe-modal">
    <RecipeDetailes :activeRecipe="acitiveRecipe" />
  </Modal>
</template>


<script>
import { Recipe } from "../models/Recipe";
import { recipesService } from "../services/RecipesService";
import RecipeDetailes from "./RecipeDetailes.vue";
import { computed } from "@vue/reactivity";

export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup() {
    return {
      activeRecipe: computed(() => AppState.acitiveRecipe),
      setActiveRecipe(recipeId) {
        recipesService.setActiveRecipe(recipeId)
      }

    };
  },
  components: { RecipeDetailes }
}
</script>


<style lang="scss" scoped>
.recipe-img {
  height: 30vh;
  width: 100%;
  object-fit: cover;
}
</style>