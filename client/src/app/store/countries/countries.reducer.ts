import { createReducer, on } from '@ngrx/store';
import * as CountriesActions from './countries.action';
import { Country } from '../../models/country.model';

export interface CountriesState {
  countries: Country[];
  error: string | null;
}

export const initialProductState: CountriesState = {
  countries: [],
  error: null,
};

export const CountryReducer = createReducer(
  initialProductState,
  on(CountriesActions.loadCountriesSuccess, (state, { countries }) => ({
    ...state,
    countries,
    error: null,
  })),

  on(CountriesActions.loadCountriesFailure, (state, { errorMessage }) => ({
    ...state,
    error: errorMessage,
  })),

  on(CountriesActions.updateCountry, (state, { name, updatedProps  }) => ({
    ...state,
    countries:
      (state?.countries as Country[]).map((element:Country) => 
      element.name === name ? { ...element, ...updatedProps } : element
    )
  })),

  on(CountriesActions.updateCountrySuccess, (state, { country }) => ({
    ...state,
    country,
    error: null,
  })),

  on(CountriesActions.updateCountryFailure, (state, { errorMessage }) => ({
    ...state,
    error: errorMessage,
  })),
);
