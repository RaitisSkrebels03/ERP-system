import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateThirdpartyComponent } from './update-thirdparty.component';

describe('UpdateThirdpartyComponent', () => {
  let component: UpdateThirdpartyComponent;
  let fixture: ComponentFixture<UpdateThirdpartyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateThirdpartyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateThirdpartyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
