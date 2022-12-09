import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  @Component({
    selector: 'form-field-overview-example',
    templateUrl: 'form-field-overview-example.html',
    styleUrls: ['form-field-overview-example.css'],
  })
  //features
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
  ]
}
