import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent {
  isOpen: boolean = false;
  @Input() item: {
    id:number,
    firstName:string,
    lastName:string,
    date: number,
    email:string,
    tableNumber: number,
    tableNumOfSeats: number,
    tableLocation:string
  } = {
    id:0,
    firstName:"",
    lastName:"",
    date: Date.now(),
    email:"",
    tableNumber: 0,
    tableNumOfSeats: 0,
    tableLocation:""
  }

  openForm(){
    this.isOpen = !this.isOpen;
  }
}
