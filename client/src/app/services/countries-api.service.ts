import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country.model';
import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root',
})
export class CountryApiService {
  getBaseUrl(): string {
    return environment.apiUrl;
  }
  constructor(private http: HttpClient) {}

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.getBaseUrl());
  }

  getCountryByName(name: string): Observable<Country> {
    return this.http.get<Country>(`${this.getBaseUrl()}/${name}`);
  }

  updateDetails(name: string, updatedFields: Partial<Country>) {
    return this.http.put(`${this.getBaseUrl()}/${name}`, updatedFields);
  }

}
