import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSalesOrderComponent } from './update-sales-order.component';

describe('UpdateSalesOrderComponent', () => {
  let component: UpdateSalesOrderComponent;
  let fixture: ComponentFixture<UpdateSalesOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateSalesOrderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateSalesOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
