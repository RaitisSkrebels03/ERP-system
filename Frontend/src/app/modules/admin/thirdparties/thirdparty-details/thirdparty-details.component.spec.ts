import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThirdpartyDetailsComponent } from './thirdparty-details.component';

describe('ThirdpartyDetailsComponent', () => {
  let component: ThirdpartyDetailsComponent;
  let fixture: ComponentFixture<ThirdpartyDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ThirdpartyDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ThirdpartyDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
