import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  @Input() item: {imgPath:string, span:string, heading:string, bullet1:string, bullet2:string, bullet3:string} = {imgPath:"" ,span:"", heading:"", bullet1:"", bullet2:"", bullet3:""};
}
