import { Routes } from '@angular/router';
import { MatchingRecipesComponent } from './matching-recipes/matching-recipes.component';
import { RecipeDetailComponent } from './recipe-detail/recipe-detail.component';
import { IngredientsSelectorComponent } from './ingredients-select/ingredients-select.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProfileComponent } from './profile/profile.component';
import { AddRecipeComponent } from './add-recipe/add-recipe.component';

export const routes: Routes = [
    { path: '', component: IngredientsSelectorComponent },
    { path: 'recipe/:id', component: RecipeDetailComponent },
    { path: 'matching-recipes', component: MatchingRecipesComponent },
    { path: 'login', component: SignInComponent },
    { path: 'register', component: SignUpComponent },
    { path: 'profile', component: ProfileComponent},
    { path: 'add-recipe', component: AddRecipeComponent}
];
