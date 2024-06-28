import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateThirdpartyComponent } from './create-thirdparty.component';

describe('CreateThirdpartyComponent', () => {
  let component: CreateThirdpartyComponent;
  let fixture: ComponentFixture<CreateThirdpartyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateThirdpartyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateThirdpartyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
