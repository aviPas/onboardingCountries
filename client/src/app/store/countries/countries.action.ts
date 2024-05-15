import { createAction, props } from "@ngrx/store";
import { Country } from "../../models/country.model";

export const loadCountries = createAction('[Country] load countries ');
export const loadCountriesSuccess = createAction(
  '[Country] load loadCountriesSuccess ',
  props<{ countries: Country[] }>()
);
export const loadCountriesFailure = createAction(
  '[Country] load loadCountriesFailure ',
  props<{ errorMessage: string }>()
);

export const updateCountry = createAction(
  '[Country] update country',
  props<{name:string, updatedProps: Partial<Country> }>()
);

export const updateCountrySuccess = createAction(
  '[Country] update updateCountrySuccess ',
  props<{ country: Country }>()
);
export const updateCountryFailure = createAction(
  '[Country] update updateCountryFailure ',
  props<{ errorMessage: string }>()
);
