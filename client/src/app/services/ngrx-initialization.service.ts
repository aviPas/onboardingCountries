import { Store } from "@ngrx/store";
import { AppState } from "../store/app.state";
import * as CountriesSelector from '../store/countries/countries.selector';
import * as CountriesActions from '../store/countries/countries.action';
import { firstValueFrom } from "rxjs";


export const initializeNgRxStore = async (
  store: Store<AppState>
) => {
 
  const dataInStore = store.select(CountriesSelector.selectAllCountries);
  dataInStore.subscribe((val) => {
    if (val?.length > 0) return;
  });

  try {
    const data = await firstValueFrom(dataInStore);
    if (!data.length) {
      store.dispatch(CountriesActions.loadCountries());
      return true;
    }
    return data;
  } catch (error) {
    console.error(error);
    return error;
  }
};