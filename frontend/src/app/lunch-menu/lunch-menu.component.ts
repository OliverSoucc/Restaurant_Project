import {Component, Input} from '@angular/core';
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-lunch-menu',
  templateUrl: './lunch-menu.component.html',
  styleUrls: ['./lunch-menu.component.css']
})
export class LunchMenuComponent {
  isOpen: boolean = false;
  toppings = new FormControl('');
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];

  @Input() item: {price:string, dayInWeek:string, description:string, ingredients: string[], homePage?:boolean} = {price:"" ,dayInWeek:"", description:"", ingredients: [], homePage:true};

  openForm(){
    this.isOpen = !this.isOpen;
  }
}
