import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import axios from "axios";


export const customAxios = axios.create({
  baseURL: 'https://restaurantdotnetapp.azurewebsites.net/api',
})
@Injectable({
  providedIn: 'root'
})
export class DishService {
  constructor(private http: HttpClient) { }

  async getDishes(){
    const dishes = await customAxios.get<any>('/dishes');
    return  dishes.data;
  }

  async getDish(dishId: number){
    const dish = await customAxios.get<any>(`/dishes/${dishId}`);
    return dish.data;
  }

  async createIngredient(ingredient: { amount: number; name: string }) {
    await customAxios.post('/ingredients', ingredient);
  }

  async getIngredients(){
    const ingredients = await customAxios.get('/ingredients');
    return ingredients.data;
  }

  //change later
  async createDish(dish: { price: number; weekDay: string; name: string; description: string;}) {
    const newDish = await customAxios.post('/dishes', dish);
    return newDish.data
  }

  async createDishIngredient(dishIngredient: {dishId: number, ingredientId: number}){
    await customAxios.post('/dishingredient', dishIngredient);
  }

  async deleteDish(id: number) {
    const deleteDish = await customAxios.delete(`/dishes/${id}`);
    return deleteDish.data;
  }

  async updateDish(dish: {id:number ,price: number; weekDay: string; name: string; description: string;}){
    const updatedDish = await customAxios.put('/dishes', dish)
    return updatedDish.data
  }

  async deleteDishIngredient(id: number){
    const deleteDishIngredient = await customAxios.delete(`/ingredients/${id}`);
  }
}
