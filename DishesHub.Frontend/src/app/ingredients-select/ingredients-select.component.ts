import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { Ingredient } from '../../models/ingredient';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ingredients-selector',
  standalone: true,
  templateUrl: './ingredients-select.component.html',
  styleUrls: ['./ingredients-select.component.scss'],
  imports: [CommonModule]
})
export class IngredientsSelectorComponent implements OnInit {
  availableIngredients: Ingredient[] = [];
  filteredIngredients: Ingredient[] = [];
  selectedInclude: Ingredient[] = [];
  selectedExclude: Ingredient[] = [];
  
  currentPage: number = 1;
  batchSize: number = 20;
  loading: boolean = false;

  constructor(private recipeService: RecipeService, private router: Router) {}

  ngOnInit(): void {
    this.loadIngredients();
  }

  private loadIngredients(): void {
    if (this.loading) return;
    this.loading = true;

    this.recipeService.getIngredientPage(this.currentPage, this.batchSize).subscribe(
      (ingredients) => {
        this.availableIngredients.push(...ingredients);
        this.filteredIngredients = [...this.availableIngredients];
        this.currentPage++;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching ingredients:', error);
        this.loading = false;
      }
    );
  }

  filterIngredients(event: Event): void {
    const searchText = (event.target as HTMLInputElement).value.toLowerCase();
    this.filteredIngredients = this.availableIngredients.filter(ingredient =>
      ingredient.name.toLowerCase().includes(searchText)
    );
  }

  addToInclude(ingredient: Ingredient) {
    if (!this.selectedInclude.includes(ingredient)) {
      this.selectedInclude.push(ingredient);
      this.removeIngredientFromAvailable(ingredient);
    }
  }

  addToExclude(ingredient: Ingredient) {
    if (!this.selectedExclude.includes(ingredient)) {
      this.selectedExclude.push(ingredient);
      this.removeIngredientFromAvailable(ingredient);
    }
  }

  removeFromInclude(ingredient: Ingredient) {
    this.selectedInclude = this.selectedInclude.filter(item => item !== ingredient);
    this.availableIngredients.push(ingredient);
    this.filteredIngredients.push(ingredient);
  }

  removeFromExclude(ingredient: Ingredient) {
    this.selectedExclude = this.selectedExclude.filter(item => item !== ingredient);
    this.availableIngredients.push(ingredient);
    this.filteredIngredients.push(ingredient);
  }

  private removeIngredientFromAvailable(ingredient: Ingredient) {
    this.availableIngredients = this.availableIngredients.filter(item => item !== ingredient);
    this.filteredIngredients = this.filteredIngredients.filter(item => item !== ingredient);
  }

  onScroll(event: Event): void {
    const target = event.target as HTMLElement;
    if (target.scrollTop + target.clientHeight >= target.scrollHeight - 10) {
      this.loadIngredients();
    }
  }

  findRecipes(): void {
    this.recipeService.getMatchingRecipes(this.selectedInclude, this.selectedExclude)
      .subscribe((recipes) => {
        this.router.navigate(['/matching-recipes'], {
          queryParams: { recipes: JSON.stringify(recipes) }
        });
      }, (error) => {
        console.error('Error fetching matching recipes:', error);
      });
  }
}
