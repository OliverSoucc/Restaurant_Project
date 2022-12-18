import {Component, Input, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import * as stream from "stream";
import {ReservationService} from "../reservation.service";
import {DishService} from "../dish.service";

@Component({
  selector: 'app-lunch-menu',
  templateUrl: './lunch-menu.component.html',
  styleUrls: ['./lunch-menu.component.css']
})
export class LunchMenuComponent implements OnInit{
  isDeleted: boolean = false
  isOpen: boolean = false;
  messageUpdateDish: string = "";

  allIngredients: any
  //dish form
  dishPrice: number = 0;
  dishWeekDay: string = "";
  dishName: string = "";
  dishIngredients: any[] = [];
  dishDescription: string = "";

  @Input() item: {
    id:number
    price:number,
    name:string,
    weekDay:string,
    description:string,
    ingredients: any[],
    homePage?:boolean
  } = {
    id:0,
    price:0 ,
    name: "",
    weekDay: "",
    description:"",
    ingredients: [],
    homePage:true
  };

  constructor(private httpDishService: DishService) { }

  async ngOnInit() {
    //read all ingredients
    this.allIngredients = await this.httpDishService.getIngredients();
  }

  async deleteReservation(id: number) {
    await this.httpDishService.deleteDish(id);
    this.isDeleted = true
  }
  openForm(){
    this.isOpen = !this.isOpen;
  }

  async updateDish() {
    let updatedDish = {
      id: this.item.id,
      name: this.dishName,
      price: this.dishPrice,
      description: this.dishDescription,
      weekDay: this.dishWeekDay
    }
    try {
      const dish = await this.httpDishService.updateDish(updatedDish);
      this.dishIngredients.map(async ingredientId => {
        let ingredientToDish = {
          dishId: dish.id,
          ingredientId: ingredientId
        }
        await this.httpDishService.createDishIngredient(ingredientToDish);
      })
      this.messageUpdateDish = "Dish was updated :)"
    }catch (e) {
      this.messageUpdateDish = "Dish can not be updated :("
      console.log(e)
    }
  }

  // async editReservation() {
  //   let updatedReservation = {
  //     id:this.item.id,
  //     firstName:this.firstName,
  //     lastName:this.lastName,
  //     date: this.date,
  //     email:this.email,
  //     // reservationTableId: this.table
  //   }
  //   console.log(updatedReservation)
  //   await this.httpReservationService.updateReservation(updatedReservation);
  // }
}

