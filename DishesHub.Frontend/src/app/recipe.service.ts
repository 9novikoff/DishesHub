// src/app/services/recipe.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ingredient } from '../models/ingredient';
import { Recipe } from '../models/recipe';
import { DetailedRecipe } from '../models/detailed-recipe';
import { AuthService } from './auth.service';
import { Dish } from '../models/dish';
import { AddRecipeDto } from '../models/add-recipe-dto';
import { RatePostDto } from '../models/rate-post-dto';
import { RateGetDto } from '../models/rate-get-dto';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private apiUrl = 'http://localhost:5184';
  
  constructor(private http: HttpClient, private authService: AuthService) {}
  
  getIngredients(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${this.apiUrl}/ingredients`);
  }
  
  getRecipes(include: string[], exclude: string[]): Observable<Recipe> {
    return this.http.post<Recipe>(`${this.apiUrl}/recipes`, { include, exclude });
  }
  
  getIngredientPage(page: number, batchSize: number): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${this.apiUrl}/ingredient-page?page=${page}&size=${batchSize}`);
  }

  getMatchingRecipes(selectedInclude: Ingredient[], selectedExclude: Ingredient[]) {
    const includeIds = selectedInclude.map(ingredient => ingredient.id);
    const excludeIds = selectedExclude.map(ingredient => ingredient.id);
    return this.http.post<Recipe[]>(`${this.apiUrl}/recipe-matches`, {MatchIngredientIds: includeIds, AvoidIngredientIds: excludeIds});
  }

  getUserDetailedRecipes(userId: string): Observable<DetailedRecipe[]> {
    return this.http.get<DetailedRecipe[]>(`${this.apiUrl}/{userId}/recipes`);
  }

  getUserRecipes(userId: string): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.apiUrl}/${userId}/recipes`);
  }

  getDetailedRecipeById(id: number): Observable<DetailedRecipe>{
    return this.http.get<DetailedRecipe>(`${this.apiUrl}/detailed-recipe/${id}`);
  }

  getDishes(): Observable<Dish[]>{
    return this.http.get<Dish[]>(`${this.apiUrl}/dishes`);
  }

  addRecipe(recipe: AddRecipeDto){
    const headers = this.authService.getHeaders();
    return this.http.post(`${this.apiUrl}/recipe`, recipe, {headers: headers});
  }

  addRate(rate: RatePostDto){
    const headers = this.authService.getHeaders();
    return this.http.post(`${this.apiUrl}/rate`, rate, {headers: headers});
  }

  getAllRatesForRecipeId(id: number): Observable<RateGetDto[]>{
    const headers = this.authService.getHeaders();
    return this.http.get<RateGetDto[]>(`${this.apiUrl}/rate/${id}`, {headers: headers});
  }

}
