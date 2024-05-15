import { APP_INITIALIZER, ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient } from '@angular/common/http';
import { Store, provideState, provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { CountryReducer } from './store/countries/countries.reducer';
import { CountryEffect } from './store/countries/countries.effects';
import { initializeApp } from './app.component';
import { CountryApiService } from './services/countries-api.service';
//import { provideToastr } from 'ngx-toastr';
import { MatNativeDateModule } from '@angular/material/core';

export const appConfig: ApplicationConfig = {

  providers: [
    provideRouter(routes),
    provideAnimationsAsync(),
    provideHttpClient(),
    provideStore(),
   // provideToastr(),
    importProvidersFrom(MatNativeDateModule),
    provideState({ name: 'countries', reducer: CountryReducer }),
    provideEffects(CountryEffect),
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [CountryApiService, Store],
      multi: true
    },
  ],
};
