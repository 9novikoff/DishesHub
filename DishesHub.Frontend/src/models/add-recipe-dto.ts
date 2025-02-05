import { Ingredient } from "./ingredient"

export class AddRecipeDto{
    name!: string
    picture!: string
    description!: string
    videoRefference?: string
    authorId?: string
    ingredients!: Ingredient[]
    dishId!: number
}