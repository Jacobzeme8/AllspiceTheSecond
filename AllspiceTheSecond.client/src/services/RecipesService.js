import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService{

  async getAllrecipes(){
    const res = await api.get('api/recipes')
    // logger.log(res.data)
    AppState.recipes = res.data.map(m => new Recipe(m))
    AppState.allRecipes = res.data.map(m => new Recipe(m))
    return AppState.recipes
  }

  async getMyRecipes(){
    const res = await api.get('api/recipes')
    const recipes = res.data.filter(d => d.creatorId = AppState.account.id)

    logger.log()
    AppState.recipes = recipes.map(d => new Recipe(d))
  }

  async getMyFavoriteRecipes(){
    const res = await api.get('account/favorites')
    // logger.log(res.data)
    AppState.recipes = res.data.map(m => new Recipe(m))
  }

  setActiveRecipe(recipeId){
    AppState.acitiveRecipe = AppState.recipes.find(r => r.id == recipeId)
    logger.log(AppState.acitiveRecipe)
  }

  async getRecipeIngredients(recipeId){
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    AppState.ingredients = res.data
    // logger.log(AppState.ingredients)
  }

  async deleteRecipe(recipeId){
    const index = AppState.recipes.findIndex( r=> r.id == recipeId)
    AppState.recipes.splice(index, 1)
    const res = await api.delete(`api/recipes/${recipeId}`)
    logger.log(res.data)
  }

  async favoriteRecipe(favoriteData){
    const res = await api.post('api/favorites', favoriteData)
    logger.log(res.data)
  }

  async createRecipe(recipeData){
    const res = await api.post('api/recipes', recipeData)
    logger.log(res.data)
    AppState.recipes.push(res.data)

  }


}

export const recipesService = new RecipesService()