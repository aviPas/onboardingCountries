import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryDetailsFormComponent } from './country-details-form.component';

describe('CountryDetailsFormComponent', () => {
  let component: CountryDetailsFormComponent;
  let fixture: ComponentFixture<CountryDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CountryDetailsFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CountryDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
