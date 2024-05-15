export const DISPLAYED_COLUMNS: string[] = [
    'flag',
    'name',
    'capital',
    'region',
    'subregion',
    'population',
    'details',
  ];

  export const FIELDS = [
    { key: 'name', label: 'Name', readOnly: true },
    { key: 'capital', label: 'Capital'},
    { key: 'region', label: 'Region', readOnly: true },
    { key: 'subregion', label: 'Subregion', readOnly: true },
    { key: 'timezones', label: 'Timezones', readOnly: true },
    { key: 'population', label: 'Population',type:'number' }
  ];

  export const UPDATE_COUNTRY_SUCCEDD = 'successfully updated !'
  export const UPDATE_COUNTRY_FAILED ='failed to update'
  export const SERVER_ERROR_COUNTRIES = 'error accured when trying to fetch countries'
  export const SERVER_ERROR_SINGLE_COUNTRY = 'error accured when trying to fetch country details'

  export const DURATION = 3;