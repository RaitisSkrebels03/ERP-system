import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesOrdersListComponent } from './sales-orders-list.component';

describe('SalesOrdersListComponent', () => {
  let component: SalesOrdersListComponent;
  let fixture: ComponentFixture<SalesOrdersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesOrdersListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalesOrdersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
