import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Recipe } from '../../models/recipe';
import { RecipeListComponent } from "../recipe-list/recipe-list.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-matching-recipes',
  templateUrl: './matching-recipes.component.html',
  styleUrls: ['./matching-recipes.component.css'],
  standalone: true,
  imports: [RecipeListComponent, CommonModule]
})
export class MatchingRecipesComponent implements OnInit {
  recipes: Recipe[] = [];         

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.recipes = JSON.parse(params['recipes']);
    });
  }


  viewRecipe(recipe: Recipe): void {
    this.router.navigate(['/recipe/' + recipe.id]);
  }
}
