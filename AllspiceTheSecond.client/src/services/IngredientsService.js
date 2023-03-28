import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService{

  async addIngredient(ingredientData){
    // logger.log(ingredientData)
    const res = await api.post('api/ingredients', ingredientData)
    AppState.ingredients.push(res.data)
  }

  async deleteIngredient(ingredientId){

    const res = await api.delete(`api/ingredients/${ingredientId}`)
    const index = AppState.ingredients.findIndex(i => i.id == ingredientId)
    AppState.ingredients.splice(index, 1)
    logger.log(res.data)
  }

}

export const ingredientsService = new IngredientsService()