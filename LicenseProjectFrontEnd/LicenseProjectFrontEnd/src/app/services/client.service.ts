import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import {Client} from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private readonly url = "Client";

  constructor(private http : HttpClient) { }

  public getClient(): Observable<Client[]>{
    return this.http.get<Client[]>(`${environment.apiUrl}/${this.url}`)
  }

  public createClient(client : Client): Observable<Client[]>{
    return this.http.post<Client[]>(`${environment.apiUrl}/${this.url}`, client)
  }

  public deleteClient(client : Client): Observable<Client[]>{
    return this.http.delete<Client[]>(`${environment.apiUrl}/${this.url}/${client.id}`)
  }
}
