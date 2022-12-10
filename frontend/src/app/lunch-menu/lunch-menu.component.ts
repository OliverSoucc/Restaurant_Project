import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-lunch-menu',
  templateUrl: './lunch-menu.component.html',
  styleUrls: ['./lunch-menu.component.css']
})
export class LunchMenuComponent {
  @Input() item: {price:string, dayInWeek:string, description:string, ingredients: string[]} = {price:"" ,dayInWeek:"", description:"", ingredients: []};

}
