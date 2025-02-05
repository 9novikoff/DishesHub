import { AfterViewInit, Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { RecipeService } from '../recipe.service';
import { CommonModule } from '@angular/common';
import { DetailedRecipe } from '../../models/detailed-recipe';
import { RecipeListComponent } from '../recipe-list/recipe-list.component';
import { Recipe } from '../../models/recipe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, RecipeListComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements AfterViewInit {
  recipes: Recipe[] = [];

  constructor(public authService: AuthService, private recipeService: RecipeService, private router: Router) {}

  ngAfterViewInit(): void {
    this.loadUserRecipes();
  }

  loadUserRecipes(): void {
    this.recipeService.getUserRecipes(this.authService.getUserId()).subscribe((recipes) => {
      this.recipes = recipes;
    });
  }

  addRecipe(): void {
    this.router.navigate(['/add-recipe'])
  }
}
