import {ComponentFixture, TestBed} from '@angular/core/testing';

import {ReservationFormComponent} from './reservation-form.component';

describe('RestrvationFormComponent', () => {
  let component: ReservationFormComponent;
  let fixture: ComponentFixture<ReservationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ReservationFormComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ReservationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
