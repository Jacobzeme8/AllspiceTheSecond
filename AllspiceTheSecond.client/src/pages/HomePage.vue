<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-10 m-auto d-flex justify-content-between my-3">
        <button @click="getAllrecipes()" class="btn btn-primary">All</button>
        <button @click="getMyFavoriteRecipes()" class="btn btn-primary">My Favorites</button>
        <button @click="getMyRecipes()" class="btn btn-primary">My recipes</button>
      </div>
      <div v-for="recipe in recipes" class="col-3 my-2">
        <RecipeCard :recipe="recipe" />
      </div>
    </div>
  </div>
</template>

<script>
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { recipesService } from "../services/RecipesService"
import { onMounted, computed } from "vue";
import { AppState } from "../AppState"

export default {
  setup() {

    async function getAllrecipes() {
      try {
        await recipesService.getAllrecipes()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getAllrecipes();
    })


    return {
      recipes: computed(() => AppState.recipes),
      getAllrecipes,
      async getMyRecipes() {
        try {
          recipesService.getMyRecipes()
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
      },
      async getMyFavoriteRecipes() {
        try {
          AppState.recipes = null
          await recipesService.getMyFavoriteRecipes()
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
      }

    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
