import { Injectable } from "@angular/core";
import { DISPLAYED_COLUMNS } from "../components/countries/constans";

@Injectable({
    providedIn: 'root',
  })
  export class CountryApiService {
    initializeTableColumnObjectArr = ()=>{
        return DISPLAYED_COLUMNS.filter((col)=>col !== 'details' && col !== 'flag')
        .map((col:any)=>{
          return{
            columnDef: col,
            header: col.charAt(0).toUpperCase() + col.slice(1),
            cell: (element: any) => `${element[col]}`,
          }
        })
    
      }



  }