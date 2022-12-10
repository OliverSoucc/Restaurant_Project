import {Component, OnInit, ViewChild} from '@angular/core';
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('picker') picker: any;
  public minDate: Date | undefined;
  public dateControl = new FormControl(null);
   min() {
    const now = new Date();
    this.minDate = new Date();
    return this.minDate.setDate(now.getDate() - 1);
  }





  features = [
    {title: "Never cook again!", description:"We offer healthiest food with friendly price to everyone, do not hesitate and visit us every day"},
    {title: "Local and organic", description:"All our partners are from town and local villages, everything you eat will taste like home"},
    {title: "No waste", description:"All our partners are using reusable packages for vegetables and meat that they deliver to us"},
    {title: "Always welcome", description:"Our restaurant is open evey day included weekends and holidays"},
  ];

  cards = [
    {imgPath:"assets/images/meal-1.jpg",span:'Vegetarian', heading:"Japanese Gyozas", bullet1:"650 calories", bullet2: "NutriScore ® 74", bullet3: "4.9 rating (537)"},
    {imgPath:"assets/images/meal-2.jpg",span:'Vegan', heading:"Avocado Salad", bullet1:"400 calories", bullet2: "NutriScore ® 92", bullet3: "4.8 rating (441)"}
  ];

  bulletPoints = [
    {title: 'Vegetarian'},
    {title: 'Vegan'},
    {title: 'Pescatarian'},
    {title: 'Gluten-free'},
    {title: 'Lactose-free'},
    {title: 'Keto'},
    {title: 'Paleo'},
  ];

  //change to dynamic later
  lunchMenus = [
    {price:"11,99$",
      dayInWeek:"monday",
      description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
      ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', ]
    },
    {price:"9,44$",
      dayInWeek:"tuesday",
      description:"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid consequatur dolorum earum eum, ex fugiat, id illo impedit ipsum laboriosam maxime nam natus odit officia pariatur quas ratione veniam, vero?Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid animi ducimus ea eos esse exercitationem mollitia nam nisi odit officia porro provident quae reiciendis sunt suscipit ut, voluptatem? Consectetur, nisi.\n",
      ingredients: ['ingredients 2 | 50g', 'ingredients 2 | 50g', 'ingredients 3 | 50g', 'ingredients 4 | 50g', 'ingredients 5 | 50g', 'ingredients 6 | 50g']
    },
  ]

}
