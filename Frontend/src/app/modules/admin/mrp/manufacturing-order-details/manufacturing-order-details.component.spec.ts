import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufacturingOrderDetailsComponent } from './manufacturing-order-details.component';

describe('ManufacturingOrderDetailsComponent', () => {
  let component: ManufacturingOrderDetailsComponent;
  let fixture: ComponentFixture<ManufacturingOrderDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufacturingOrderDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManufacturingOrderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
