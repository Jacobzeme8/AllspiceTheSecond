<template>
  <div class="card d-flex align-items-center">
    <img @click="setActiveRecipe(recipe.id), getRecipeIngredients(recipe.id)" class="img-fluid recipe-img selectable "
      :src="recipe.img" data-bs-toggle="modal" data-bs-target="#recipe-modal" alt="">
    <p>Title: {{ recipe.title }}</p>
    <p>Category: {{ recipe.category }}</p>
    <i @click="favoriteRecipe(account.id, recipe.id)" class="mdi mdi-star text-warning selectable fs-3"></i>
  </div>
  <Modal id="recipe-modal">
    <RecipeDetailes />
  </Modal>
</template>


<script>
import { Recipe } from "../models/Recipe";
import { recipesService } from "../services/RecipesService";
import RecipeDetailes from "./RecipeDetailes.vue";
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";

export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup() {
    return {
      account: (() => AppState.account),
      activeRecipe: computed(() => AppState.acitiveRecipe),
      setActiveRecipe(recipeId) {
        recipesService.setActiveRecipe(recipeId)
      },
      async getRecipeIngredients(recipeId) {
        try {
          await recipesService.getRecipeIngredients(recipeId)
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      },

      async favoriteRecipe(accountId, recipeId) {
        try {
          const favoriteData = {
            accountId: accountId,
            recipeId: recipeId
          }
          await recipesService.favoriteRecipe(favoriteData)
        } catch (error) {

        }
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