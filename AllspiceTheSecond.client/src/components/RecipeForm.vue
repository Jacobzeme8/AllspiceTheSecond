<template>
  <div class="component">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title text-dark fs-5" id="exampleModalLabel">
          Recipe Form
        </h1>
      </div>
      <div class="modal-body">

        <form @submit.prevent="createRecipe()">
          <label class="form-label">Recipe Name</label>
          <input v-model="editable.title" required type="text" class="form-control">
          <label class="form-label">Recipe Image</label>
          <input v-model="editable.img" required type="text" class="form-control">
          <label class="form-label">Instructions</label>
          <textarea v-model="editable.instructions" required class="w-100 rounded mt-2" name="instructions"
            id="instructions" cols="30" rows="10"></textarea>
          <select v-model="editable.category" required class="form-select" aria-label="Default select example">
            <option selected value="Soup">Soup</option>
            <option value="Italian">Italian</option>
            <option value="Cheese">Cheese</option>
            <option value="Mexican">Mexican</option>
            <option value="Specialty Coffee">Specialty Coffee</option>
          </select>
          <button type="submit" class="btn btn-primary mt-2">Conjure Recipe</button>
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";

export default {
  setup() {

    const editable = ref({})

    return {
      editable,
      async createRecipe() {
        try {
          const recipeData = editable.value
          await recipesService.createRecipe(recipeData)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>