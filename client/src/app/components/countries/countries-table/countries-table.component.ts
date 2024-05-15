import {  HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import {  RouterModule } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Country } from '../../../models/country.model';
import { AppState } from '../../../store/app.state';
import * as CountriesSelector from '../../../store/countries/countries.selector';
import { CommonModule, AsyncPipe } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { DISPLAYED_COLUMNS } from '../constans';
import { CountryApiService } from '../../../services/countries-table.service';


@Component({
  selector: 'app-countries-table',
  standalone: true,
  imports: [
    MatTableModule,
    HttpClientModule,
    CommonModule,
    RouterModule,
    AsyncPipe,],
  templateUrl: './countries-table.component.html',
  styleUrl: './countries-table.component.scss',

})
export class CountriesTableComponent {
  countriesList$!: Observable<Country[]>; 
  countries$!: Country[];
  displayedColumns: string[] = DISPLAYED_COLUMNS;
  columns :any;

  constructor(
    private store: Store<AppState>,
    private countryTableService: CountryApiService
  ) {
    this.getCountryListFromNgrx(store);
  }


  ngOnInit(): void {
    this.columns = this.countryTableService.initializeTableColumnObjectArr();
  }


  getCountryListFromNgrx = (store: Store<AppState>)=>{
    store.select(CountriesSelector.selectAllCountries).subscribe((countries: any) => {
      if (!!countries && countries.length > 0) {
        this.countries$ = countries;
      }
    }); 
  }

}
