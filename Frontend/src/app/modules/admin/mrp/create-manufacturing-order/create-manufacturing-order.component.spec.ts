import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateManufacturingOrderComponent } from './create-manufacturing-order.component';

describe('CreateManufacturingOrderComponent', () => {
  let component: CreateManufacturingOrderComponent;
  let fixture: ComponentFixture<CreateManufacturingOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateManufacturingOrderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateManufacturingOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
