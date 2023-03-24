import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService{

  async getAllrecipes(){
    const res = await api.get('api/recipes')
    // logger.log(res.data)
    AppState.recipes = res.data.map(m => new Recipe(m))
    return AppState.recipes
  }

  async getMyRecipes(gottenRecipes){
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


}

export const recipesService = new RecipesService()