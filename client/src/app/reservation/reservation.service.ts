import {Injectable} from '@angular/core';
import {Reservation} from '../models/reservation';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private readonly url = "https://localhost:3000";


  private readonly reservations: Reservation[] = [];

  constructor(private http: HttpClient) {
  }

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(`${this.url}/Reservations`);
  }

  getReservation(id: string): Observable<Reservation> {
    return this.http.get<Reservation>(this.url + "/Reservations/" + id);
  }

  addReservation(reservation: Reservation): Observable<void> {

    return this.http.post<void>(this.url + "/Reservations", reservation);
  }

  updateReservation(id: string, reservation: Reservation): Observable<void> {
    return this.http.put<void>(this.url + "/Reservations/" + id, reservation);
  }

  deleteReservation(id: string): Observable<void> {

    return this.http.delete<void>(this.url + "/Reservations/" + id);
  }


}
