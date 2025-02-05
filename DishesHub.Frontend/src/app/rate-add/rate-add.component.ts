import { Component, Input } from '@angular/core';
import { StarRatingComponent } from "../star-rating/star-rating.component";
import { FormsModule } from '@angular/forms';
import { RecipeService } from '../recipe.service';
import { AddRecipeDto } from '../../models/add-recipe-dto';
import { RatePostDto } from '../../models/rate-post-dto';
@Component({
  selector: 'app-rate-add',
  standalone: true,
  imports: [StarRatingComponent, FormsModule],
  templateUrl: './rate-add.component.html',
  styleUrl: './rate-add.component.css'
})
export class RateAddComponent {
  @Input() recipeId: number | undefined;
  comment: string = "";
  rating?: number;
  errorMessage?: string;

  constructor(private recipeService: RecipeService){
  }

  add_comment(){
    if(this.recipeId && this.rating){
      this.recipeService.addRate(new RatePostDto(this.recipeId, this.rating, this.comment)).subscribe({error: (value) => this.errorMessage = value});
    }
  }

  update_rating(rating: number){
    this.rating = rating;
  }
}
