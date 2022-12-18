import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import axios from 'axios';
import {addWarning} from "@angular-devkit/build-angular/src/utils/webpack-diagnostics";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5293',
})
@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  async getReservations(){
    const reservations = await customAxios.get<any>('/api/reservations');
    return reservations.data;
  }
  async getReservationTables(){
    const reservationTables = await customAxios.get<any>('/api/reservationtable');
    return  reservationTables.data
  }

  async createReservation(reservation: { date: string; firstName: string; lastName: string; email: string; reservationTableId: number }) {
    return await customAxios.post('/api/reservations', reservation);
  }

  async deleteReservation(id: number) {
    const deleteReservation = await customAxios.delete(`/api/reservations/${id}`);
    return deleteReservation.data;
  }

  async updateReservation(updatedReservation: { date: string; firstName: string; lastName: string; id: number; email: string; reservationTableId: number}) {
    const reservation = await customAxios.put('/api/reservations', updatedReservation);
    return reservation.data;
  }
}
