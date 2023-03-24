
export class Recipe{

  constructor(data){
    this.id = data.id
    this.title = data.title
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.creator = data.creator || null
    this.favoriteId = data.favoriteId || null
  }

}
