import { Component } from '@angular/core';
import {  RouterOutlet } from '@angular/router';
import { CountriesTableComponent } from './components/countries/countries-table/countries-table.component';
import { Store } from '@ngrx/store';
import { AppState } from './store/app.state';
import { initializeNgRxStore } from './services/ngrx-initialization.service';
import { CountryApiService } from './services/countries-api.service';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CountriesTableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'OnboardingCountries';
}


export function initializeApp(appInitializerService: CountryApiService, store: Store<AppState>) {
  return () => initializeNgRxStore(store); 
}



