import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillsOfMaterialsListComponent } from './bills-of-materials-list.component';

describe('BillsOfMaterialsListComponent', () => {
  let component: BillsOfMaterialsListComponent;
  let fixture: ComponentFixture<BillsOfMaterialsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BillsOfMaterialsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BillsOfMaterialsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
