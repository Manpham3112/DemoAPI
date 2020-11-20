
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Room } from '../models/room.model';
import { MessageService } from './message.service';




@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private hostApi = 'https://localhost:44393/';
  httpOptions = {
    headers: new HttpHeaders({
      'Cache-control': 'no-cache',
      'Pragma': 'no-cache',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
      'Access-Control-Allow-Headers': 'Access-Control-Allow-Headers, Origin,Accept, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers',
      'Access-Control-Allow-Credentials': 'true',
      'Source': 'Web-portal',
      'Content-Type': "application/json"
    })
  };
  constructor(private http: HttpClient, private messageService: MessageService) { }
  getRoom(): Observable<any> {
    return this.http.get(this.hostApi + "api/room", { withCredentials: true }).pipe();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add(`RoomService: ${message}`);
  }

  createRoom(room: Room): Observable<Room> {
    return this.http.post<Room>(this.hostApi + "api/room", room, this.httpOptions).pipe(
      tap((newRoom: Room) => this.log(`create room w/ id=${newRoom.id}`)),
      catchError(this.handleError<Room>('createRoom'))
    );
  }

  deleteRoom(room: Room): Observable<Room> {
    const id = typeof room === 'number' ? room : room.id;
    const url = `${this.hostApi + "api/room"}/${id}`;

    return this.http.delete<Room>(url, this.httpOptions).pipe(tap(_ => this.log(`deleted room id=${id}`)),
      catchError(this.handleError<Room>('deleteRoom')));
  }

  getRoomDetail(id: string): Observable<Room> {
    const url = `${this.hostApi + "api/room"}/${id}`;
    return this.http.get<Room>(url).pipe(
      tap(_ => this.log(`fetched room id=${id}`)),
      catchError(this.handleError<Room>(`getRoomDetail id=${id}`))
    );
  }

  updateRoom(room: Room): Observable<any> {
    return this.http.put(this.hostApi + "api/room/" + room.id, room, this.httpOptions).pipe(
      tap(_ => this.log(`updated room id=${room.id}`)),
      catchError(this.handleError<any>('updateRoom'))
    );
  }

  insertRoom(room: Room): Observable<any> {
    return this.http.post(this.hostApi + "api/room", room, this.httpOptions).pipe(
      tap(_ => this.log(`insert room id=${room.id}`)),
      catchError(this.handleError<any>('insert room'))
    );
  }
}

