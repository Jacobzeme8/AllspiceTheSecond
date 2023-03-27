<template>
  <div v-if="recipe" class="modal-content">
    <div class="modal-header">
      <h1 class="modal-title text-dark fs-5" id="exampleModalLabel">
        {{ recipe.title }}
      </h1>
      <i @click="deleteRecipe(recipe.id)" v-if="account.id == recipe.creatorId"
        class="selectable mdi mdi-delete text-danger fs-3 ms-3"></i>
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
    </div>
    <div class="modal-body">
      <div class="component">
        <div class="container-fluid">
          <div class="row">
            <div class="col-6">
              <h3>Ingredients</h3>
              <div v-for="ingredient in ingredients">
                <p>{{ ingredient.quantity }} {{ ingredient.name }}</p>

              </div>
              <h3>Instructions</h3>
              <p>{{ recipe.instructions }}</p>
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
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { recipesService } from "../services/RecipesService";

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
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),

      async deleteRecipe(recipeId) {
        try {
          if (await Pop.confirm("Do you really want to delete this recipe?")) {
            logger.log(recipeId)
            await recipesService.deleteRecipe(recipeId)

          }
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>