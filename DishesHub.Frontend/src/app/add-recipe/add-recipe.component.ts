import { Component } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { AddRecipeDto } from '../../models/add-recipe-dto';
import { FormGroup, FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Ingredient } from '../../models/ingredient';
import { Dish } from '../../models/dish';
import { routes } from '../app.routes';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-recipe',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.css']
})
export class AddRecipeComponent {
  recipe: AddRecipeDto = {
    name: '',
    picture: '', 
    description: '',
    videoRefference: '',
    authorId: '',
    ingredients: [],
    dishId: 0
  };

  dishes: Dish[] = [];
  ingredients: Ingredient[] = [];
  selectedIngredientsList: Ingredient[] = [];
  filteredIngredients: Ingredient[] = [];
  ingredientSearch: string = '';
  imagePreview: string | ArrayBuffer | null = null;

  constructor(private recipeService: RecipeService, private router: Router) {}

  ngOnInit(): void {
    this.recipeService.getDishes().subscribe((dishes) => {
      this.dishes = dishes;
    });

    this.recipeService.getIngredients().subscribe((ingredients) => {
      this.ingredients = ingredients;
      this.filteredIngredients = ingredients;
    });
  }

  filterIngredients(): void {
    if (this.ingredientSearch) {
      this.filteredIngredients = this.ingredients.filter(ingredient =>
        ingredient.name.toLowerCase().includes(this.ingredientSearch.toLowerCase())
      );
    } else {
      this.filteredIngredients = this.ingredients;
    }
  }


  toggleIngredientSelection(ingredient: Ingredient): void {
    this.selectedIngredientsList.push(ingredient);
    this.filteredIngredients.splice(this.filteredIngredients.indexOf(ingredient), 1)
  }

  removeIngredient(ingredient: Ingredient): void {
    this.selectedIngredientsList = this.selectedIngredientsList.filter(i => i.id !== ingredient.id);
    this.filteredIngredients.push(ingredient);
  }

  onImageChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.convertImageToBase64(file);
    }
  }

  convertImageToBase64(file: File): void {
    const reader = new FileReader();
    reader.onload = () => {
      const base64Image = reader.result as string;
      this.recipe.picture = base64Image;
      this.createImagePreview(file);
    };
    reader.readAsDataURL(file);
  }

  createImagePreview(file: File): void {
    const reader = new FileReader();
    reader.onload = () => {
      this.imagePreview = reader.result;
    };
    reader.readAsDataURL(file);
  }

  onSubmit(): void {
    this.recipe.ingredients = this.selectedIngredientsList;

    this.recipeService.addRecipe(this.recipe).subscribe(
      (response) => {
        this.router.navigate(["/profile"]);
      }
    );
  }
}
