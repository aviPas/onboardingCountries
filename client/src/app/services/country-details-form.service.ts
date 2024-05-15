import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Country } from "../models/country.model";
import { ActivatedRoute } from "@angular/router";
import { CountryApiService } from "./countries-api.service";

@Injectable({
  providedIn: 'root',
})
export class CountryFormService {


  getErrorMsg = (fieldKey: string,myForm:FormGroup): string => {
    const field = myForm.get(fieldKey);
  
    if (field?.hasError('required')) {
      return 'This field is required.';
    }
    if (field?.hasError('max')) {
      return 'Value exceeds maximum limit.';
    }
    if (field?.hasError('min')) {
      return 'Value is below minimum limit.';
    }
    if (field?.hasError('maxlength')) {
      return 'Length exceeds maximum characters.';
    }
    
    return '';
  }
  buildForm = (fb: FormBuilder, data?: Country): FormGroup => {
    const formGroup = {
      name: [data?.name || '', Validators.required],
      capital: [data?.capital || '', Validators.required],
      region: [data?.region || '', Validators.required],
      subregion: [data?.subregion || '', Validators.required],
      population: [
        data?.population || '',
        [Validators.required, Validators.max(2147483647) ,Validators.min(0) ],
      ],
      timezones: [data?.timezones || '', Validators.required],
    };

    return fb.group(formGroup);
  };

  getSelectedCountryNameBasedOnCountryNameInURL = (route: ActivatedRoute)=>{

    return new Promise((resolve, reject) => {
      route.params.subscribe((params) => {
        const url = decodeURIComponent(params['countryName']); //common constans??
        resolve(url);
      });
    });
    
  }

  getDataByCountryName = async (countryTableService:CountryApiService,route: ActivatedRoute) => {
    var countryName :string | unknown = await this.getSelectedCountryNameBasedOnCountryNameInURL(route);
    return new Promise((resolve, reject) => {
      countryTableService.getCountryByName(countryName as string).subscribe((data: any) => {
        resolve(data.value);
      });
    });
  }

}


