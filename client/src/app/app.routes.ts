import { Routes } from '@angular/router';
import { NotfoundComponent } from './components/page-not-found/page-not-foundcomponent';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./components/countries/countries-table/countries-table.component').then(
        (m) => m.CountriesTableComponent
      ),
    pathMatch: 'full',
  },
  {
    path: 'details/:countryName',
    loadComponent: () =>
      import('./components/countries/country-details-form/country-details-form.component').then(
        (m) => m.CountryDetailsFormComponent
      ),
  },
  { path: '**', component: NotfoundComponent },
];
