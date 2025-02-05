import { Component, Input } from '@angular/core';
import { Recipe } from '../../models/recipe';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-recipe-list',
  standalone: true,
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
  imports: [CommonModule]
})
export class RecipeListComponent {
  @Input() recipes: Recipe[] = [];

  constructor(private router: Router) {}

  viewRecipe(recipe: Recipe): void {
    this.router.navigate(['recipe/' + recipe.id]);
  }
}
