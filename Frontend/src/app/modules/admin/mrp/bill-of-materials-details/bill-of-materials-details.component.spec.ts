import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillOfMaterialsDetailsComponent } from './bill-of-materials-details.component';

describe('BillOfMaterialsDetailsComponent', () => {
  let component: BillOfMaterialsDetailsComponent;
  let fixture: ComponentFixture<BillOfMaterialsDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BillOfMaterialsDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BillOfMaterialsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
