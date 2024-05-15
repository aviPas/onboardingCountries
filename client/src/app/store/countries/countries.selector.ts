import { createFeatureSelector } from '@ngrx/store';
import { CountriesState } from './countries.reducer';
import { createSelector } from '@ngrx/store';

export const selectCountriesFeature =
  createFeatureSelector<CountriesState>('countries');

export const selectAllCountries = createSelector(
  selectCountriesFeature,
  (state: CountriesState) => state.countries
);

export const selectAllCountriesError = createSelector(
  selectCountriesFeature,
  (state: CountriesState) => state.error
);
