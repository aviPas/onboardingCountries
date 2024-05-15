import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as CountriesActions from './countries.action';
import { catchError, map, of, switchMap } from 'rxjs';
import { CountryApiService } from '../../services/countries-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarComponent } from '../../components/snackbar/snackbar.component';
import { DURATION, SERVER_ERROR_COUNTRIES, UPDATE_COUNTRY_FAILED, UPDATE_COUNTRY_SUCCEDD } from '../../components/countries/constans';

@Injectable()
export class CountryEffect {
  loadCountries$ = createEffect(() =>
    this.action$.pipe(
      ofType(CountriesActions.loadCountries),
      switchMap(() =>
        this.api.getCountries().pipe(
          map((res :any) => CountriesActions.loadCountriesSuccess({ countries: res  })),
          catchError((error: { message: string }) =>
            { this._snackBar.openFromComponent(SnackbarComponent, {
              duration: DURATION * 1000, data: { message: SERVER_ERROR_COUNTRIES }
            });
              return of(
              CountriesActions.loadCountriesFailure({
                errorMessage: 'Fail to load',
              })
            )}
          )
        )
      )
    )
  );

   updateData$ = createEffect(() => this.action$.pipe(
    ofType(CountriesActions.updateCountry),
    switchMap((action: any) => this.api.updateDetails(action.name,action.updatedProps).pipe(
      map((res) => {
        this._snackBar.openFromComponent(SnackbarComponent, {
          duration: DURATION * 1000, data: { message: UPDATE_COUNTRY_SUCCEDD }
        });
        return CountriesActions.updateCountrySuccess({ country: res  })}),
          catchError((error: { message: string }) =>{
            this._snackBar.openFromComponent(SnackbarComponent, {
              duration: DURATION * 1000, data: { message: UPDATE_COUNTRY_FAILED }
            });

           return of(
              CountriesActions.updateCountryFailure({
                errorMessage: 'Fail to load',
              })
            );          
    }))
  )));
  constructor(private api: CountryApiService, private action$: Actions,private _snackBar: MatSnackBar) {}
}
