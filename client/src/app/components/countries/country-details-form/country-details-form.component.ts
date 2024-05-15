import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import {  Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Country } from '../../../models/country.model';
import { CountryApiService } from '../../../services/countries-api.service';
import { AppState } from '../../../store/app.state';
import { updateCountry } from '../../../store/countries/countries.action';
import { CountryFormService } from '../../../services/country-details-form.service';
import { FIELDS } from '../constans';

@Component({
  selector: 'app-country-details-form',
  standalone: true,
  imports: [
    AsyncPipe,
    ReactiveFormsModule,
    MatInputModule,
    MatInputModule,
    MatButtonModule,
    NgIf,
    NgFor
  ],
  templateUrl: './country-details-form.component.html',
  styleUrl: './country-details-form.component.scss',
})
export class CountryDetailsFormComponent {
  selectedCountryData$: Country | undefined; //observable??
  fields = FIELDS;
  countryDetailsForm!: FormGroup;

  constructor(
    private countryTableService: CountryApiService,
    private store: Store<AppState>,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private countryFormService: CountryFormService
  ) {
    this.countryDetailsForm = this.countryFormService.buildForm(this.fb);
  }
  

  
  async ngOnInit(): Promise<void> {
    
      this.selectedCountryData$ = await this.countryFormService.getDataByCountryName(this.countryTableService, this.route) as Country;
      this.countryDetailsForm = this.countryFormService.buildForm(this.fb, this.selectedCountryData$);
    
  }

  onSubmit() {
    if (this.countryDetailsForm?.valid) {
  
          this.store.dispatch(
            updateCountry({
              name: this.selectedCountryData$?.name ?? '',
              updatedProps: {
                population: this.countryDetailsForm.value.population,
                capital: this.countryDetailsForm.value.capital,
              },
            })
          );
       
    }
  }

  getErrorMsg = (fieldKey: string) =>{
    return this.countryFormService.getErrorMsg(fieldKey,this.countryDetailsForm);
}

}