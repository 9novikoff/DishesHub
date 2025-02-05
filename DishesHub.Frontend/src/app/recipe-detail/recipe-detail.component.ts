import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailedRecipe } from '../../models/detailed-recipe';
import { RecipeService } from '../recipe.service';
import { CommonModule } from '@angular/common';
import { RateSectionComponent } from "../rate-section/rate-section.component";
import { RateGetDto } from '../../models/rate-get-dto';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css'],
  standalone: true,
  imports: [CommonModule, RateSectionComponent]
})
export class RecipeDetailComponent implements OnInit {
  recipe!: DetailedRecipe;
  rates: RateGetDto[] = [];

  constructor(private route: ActivatedRoute, private recipeService: RecipeService) { }

  ngOnInit(): void {
    const recipeId = Number(this.route.snapshot.paramMap.get('id'));
    this.recipeService.getDetailedRecipeById(recipeId).subscribe(recipe => {
      this.recipe = recipe;
      this.recipeService.getAllRatesForRecipeId(this.recipe?.id).subscribe(rates => this.rates = rates);
    } );
  }

}
