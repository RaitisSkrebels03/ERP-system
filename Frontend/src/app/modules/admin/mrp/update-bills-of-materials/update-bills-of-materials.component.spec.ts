import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBillsOfMaterialsComponent } from './update-bills-of-materials.component';

describe('UpdateBillsOfMaterialsComponent', () => {
  let component: UpdateBillsOfMaterialsComponent;
  let fixture: ComponentFixture<UpdateBillsOfMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateBillsOfMaterialsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateBillsOfMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
