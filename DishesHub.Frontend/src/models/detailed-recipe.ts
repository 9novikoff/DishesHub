import { Ingredient } from "./ingredient"

export class DetailedRecipe{
    id!: number
    name!: string
    picture!: string
    description!: string
    videoRefference!: string
    authorEmail!: string
    ingredients!: Ingredient[]
}