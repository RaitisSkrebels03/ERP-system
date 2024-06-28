import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateManufacturingOrderComponent } from './update-manufacturing-order.component';

describe('UpdateManufacturingOrderComponent', () => {
  let component: UpdateManufacturingOrderComponent;
  let fixture: ComponentFixture<UpdateManufacturingOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateManufacturingOrderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateManufacturingOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
