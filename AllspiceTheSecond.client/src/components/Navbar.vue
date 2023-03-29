<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="../assets/img/cw-logo.png" height="45" />
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <div v-if="recipes">
        <label for="searchPosts" class="form-label">Search Posts:</label>
        <input v-model="editable.search" type="text" id="searchPosts" class="form-control" aria-describedby="searchPosts"
          name="body">
      </div>
      <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link>
        </li>
        <li>
          <button data-bs-target="#create-recipe" data-bs-toggle="modal" class="btn btn-primary">Create Recipe</button>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
  <Modal id="create-recipe">
    <RecipeForm />
  </Modal>
</template>

<script>
import { ref, watchEffect, computed } from "vue";
import { AppState } from "../AppState";
import Login from './Login.vue'
export default {
  setup() {

    const editable = ref({})

    function searchCategory() {
      if (editable.value == null) { return }
      if (AppState.allRecipes == null) { return }
      AppState.recipes = AppState.allRecipes.filter(r => r.category.toLowerCase().includes(editable.value.search.toLowerCase()))
    }

    watchEffect(() => {
      if (editable.value.search) {
        searchCategory()
      }
    })

    return {
      editable,
      recipes: computed(() => AppState.allRecipes)
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
