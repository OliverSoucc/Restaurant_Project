import {Component, Input, OnInit, Output} from '@angular/core';
import {ReservationService} from "../reservation.service";

@Component({
  selector: 'app-create-reservation-form',
  templateUrl: './create-reservation-form.component.html',
  styleUrls: ['./create-reservation-form.component.css']
})
export class CreateReservationFormComponent implements OnInit{
  submissionFormFeedback : string | undefined;

  //tables in form dropdown
  allReservationTables: any;

//form for reservations
  firstName: string = "";
  lastName: string = "";
  date: string = "";
  table: number = 0;
  email: string = "";

  constructor(private httpReservationService: ReservationService) { }

  @Input() item: {homePage:boolean} = {homePage:true};

  async ngOnInit(){
    //read all reservation tables
    this.allReservationTables = await this.httpReservationService.getReservationTables();
  }

  //onSubmit reservation form
  async createReservation() {
    let reservation = {
      date: this.date,
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      reservationTableId: this.table
    }
    try {
      const result = await this.httpReservationService.createReservation(reservation);
      this.submissionFormFeedback = "Successfully create reservation :)"
    }catch (e){
      this.submissionFormFeedback = "Can not submit form :( Probably because table you have selected is already occupied"
      console.log(e);
    }
  }
}

