export interface Country {
  name?: string;
  capital?: string;
  region?: string;
  population?: number;
  continents?: string;
  flags?: Flags;
  subregion?: string;
  timezones?: string[];
}

interface Flags{
  svg:string;
  png:string;
  alt:string
}