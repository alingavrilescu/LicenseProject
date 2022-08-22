import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { License } from '../models/license';
import {LicenseToSend} from '../models/licenseToSend';

@Injectable({
  providedIn: 'root'
})
export class LicenseService {
  private readonly url ="License";

  constructor(private http : HttpClient) { }

  public getLicense(): Observable<License[]>{
    return this.http.get<License[]>(`${environment.apiUrl}/${this.url}`)
  }

  public createLicense(license : LicenseToSend): Observable<LicenseToSend[]>{
    return this.http.post<LicenseToSend[]>(`${environment.apiUrl}/${this.url}`, license)
  }

  public deleteLicense(license : License): Observable<License[]>{
    return this.http.delete<License[]>(`${environment.apiUrl}/${this.url}/${license.id}`)
  }
}
