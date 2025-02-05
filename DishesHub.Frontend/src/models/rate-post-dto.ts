export class RatePostDto{
    constructor(recipeId: number, rating: number, comment: string) {
        this.recipeId = recipeId;
        this.rating = rating;
        this.comment = comment;
    }

    recipeId: number
    rating: number
    comment: string
}

