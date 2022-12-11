import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  reservations = [
    {id: "1", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "2", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "3", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "4", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "5", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "6", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
    {id: "7", firstName:"Matej", lastName: "Kuka", date: Date.now(), email:"loptos@hhh.com", tableNumber: 5,  tableNumOfSeats: 4, tableLocation: 'window'},
  ];

  lunchMenus = [
    {price:"11,99$",
      dayInWeek:"monday",
      description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
      ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', ],
      homePage: false
    },
    {price:"9,44$",
      dayInWeek:"tuesday",
      description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
      ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', 'ingredients 6 | 50g'],
      homePage: false
    },
  ]
}
