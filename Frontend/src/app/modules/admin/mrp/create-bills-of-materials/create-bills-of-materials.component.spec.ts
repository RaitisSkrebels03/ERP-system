import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBillsOfMaterialsComponent } from './create-bills-of-materials.component';

describe('CreateBillsOfMaterialsComponent', () => {
  let component: CreateBillsOfMaterialsComponent;
  let fixture: ComponentFixture<CreateBillsOfMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateBillsOfMaterialsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateBillsOfMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
