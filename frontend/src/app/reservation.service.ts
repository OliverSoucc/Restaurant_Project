import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import axios from 'axios';


export const customAxios = axios.create({
  baseURL: 'https://restaurantdotnetapp.azurewebsites.net/api',
})
@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  async getReservations(){
    const reservations = await customAxios.get<any>('/reservations');
    return reservations.data;
  }

  async getReservationTables(){
    const reservationTables = await customAxios.get<any>('/reservationtable');
    return  reservationTables.data
  }

  async createReservation(reservation: { date: string; firstName: string; lastName: string; email: string; reservationTableId: number }) {
    return await customAxios.post('/reservations', reservation);
  }

  async deleteReservation(id: number) {
    const deleteReservation = await customAxios.delete(`/reservations/${id}`);
    return deleteReservation.data;
  }

  async updateReservation(updatedReservation: { date: string; firstName: string; lastName: string; id: number; email: string; reservationTableId: number}) {
    const reservation = await customAxios.put('/reservations', updatedReservation);
    return reservation.data;
  }
}
