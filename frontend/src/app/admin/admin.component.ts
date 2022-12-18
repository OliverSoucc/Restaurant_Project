import {Component, OnInit} from '@angular/core';
import {FormControl} from "@angular/forms";
import {DishService} from "../dish.service";
import {ReservationService} from "../reservation.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit{
  messageCreateIngredient: string = "";
  messageCreateDish: string = "";

  toppings = new FormControl('');
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
  allReservations: any;
  allDishes: any;
  allIngredients: any

  //ingredints form
  ingredientName: string = "";
  ingredientAmount: number = 0;

  //dish form
  dishPrice: number = 0;
  dishWeekDay: string = "";
  dishName: string = "";
  dishIngredients: any[] = [];
  dishDescription: string = "";

  constructor(private httpDishService: DishService, private httpReservationService: ReservationService) { }

  async ngOnInit() {
    //read all reservations
    this.allReservations = await this.httpReservationService.getReservations();

    //read all dishes
    this.allDishes = await this.httpDishService.getDishes();
    //add to each element in dish list attribute homePage true
    this.allDishes.forEach(function (element: { homePage: boolean; weekDay: any}) {
      element.homePage = false;
      // element.weekDay = element.weekDay.getDay();
    });

    //read all ingredients
    this.allIngredients = await this.httpDishService.getIngredients();
  }

  async createIngredient() {
    let ingredient = {
      name: this.ingredientName,
      amount: this.ingredientAmount,
    }
    try {
      await this.httpDishService.createIngredient(ingredient);
      this.allIngredients = await this.httpDishService.getIngredients();
      this.messageCreateIngredient = "Ingredient was created :)"
    }catch (e){
      this.messageCreateIngredient = "Can not create ingredient :("
      console.log(e)
    }
  }

  //////////////////////////////////////////////////////////////////////////////////
  //PO PULLE OD JANA ZMENIT WEEKDAY NA STRING
  ////////////////////////////////////////////////////////////////////////////////////

  async createDish() {
    let dish = {
      price: this.dishPrice,
      name: this.dishName,
      description: this.dishDescription,
      weekDay: this.dishWeekDay,
    }
    try {
      const newDishWithoutIngredients = await this.httpDishService.createDish(dish);
      this.dishIngredients.map(async ingredientId => {
        let ingredientToDish = {
          dishId: newDishWithoutIngredients.id,
          ingredientId: ingredientId
        }
        await this.httpDishService.createDishIngredient(ingredientToDish);
      })
      this.allDishes = await this.httpDishService.getDishes();
      this.messageCreateDish = "Dish was created :)"
    }catch (e){
      this.messageCreateDish = "Can not create dish :("
      console.log(e);
    }
  }




  //MOCK DATA

  //changed to dynamic
  // reservations = [
  //   {id: 1, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 2, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 3, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 4, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 5, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 6, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  //   {id: 7, firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  // ];

  //changed to dynamic
  // lunchMenus = [
  //   {price:11.99,
  //     name:"pele",
  //     weekDay:new Date(),
  //     description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
  //     ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', ],
  //     homePage: true
  //   },
  //   {price:11.99,
  //     name:"pele",
  //     weekDay:new Date(),
  //     description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
  //     ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', ],
  //     homePage: true
  //   },
  // ]
}
