import {Component, Input, OnInit} from '@angular/core';
import {ReservationService} from "../reservation.service";

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit{
  isOpen: boolean = false;
  isDeleted: boolean = false

  messageUpdateReservation: string = "";

  allReservationTables: any;

//form for reservations
  firstName: string = "";
  lastName: string = "";
  date: string = "";
  table: number = 0;
  email: string = "";

  @Input() item: {
    id:number,
    firstName:string,
    lastName:string,
    date: string,
    email:string,
    reservationTable: {
      number: number,
      numberOfSeats: number,
      location: string
    }
  } = {
    id:0,
    firstName:"",
    lastName:"",
    date: "",
    email:"",
    reservationTable: {
      number: 0,
      numberOfSeats: 0,
      location: ''
    }
  }

  constructor(private httpReservationService: ReservationService) { }

  async ngOnInit() {
    this.allReservationTables = await this.httpReservationService.getReservationTables();
  }

  openForm(){
    this.isOpen = !this.isOpen;
  }

  async deleteReservation(id: number) {
    await this.httpReservationService.deleteReservation(id);
    this.isDeleted = true
  }

  async editReservation() {
    let updatedReservation = {
      id:this.item.id,
      firstName:this.firstName,
      lastName:this.lastName,
      date: this.date,
      email:this.email,
      reservationTableId: this.table
    }
    try {
      await this.httpReservationService.updateReservation(updatedReservation);
      this.messageUpdateReservation = "Reservation was updated :)";
    }catch (e) {
      this.messageUpdateReservation = "Reservation can not be updated :( you probably selected already reserved tables "
      console.log(e)
    }
  }

  // async createIngredient() {
  //   let ingredient = {
  //     name: this.ingredientName,
  //     amount: this.ingredientAmount,
  //   }
  //   await this.httpDishService.createIngredient(ingredient);
  // }
}
