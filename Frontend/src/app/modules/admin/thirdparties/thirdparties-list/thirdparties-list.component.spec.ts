import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThirdpartiesListComponent } from './thirdparties-list.component';

describe('ThirdpartiesListComponent', () => {
  let component: ThirdpartiesListComponent;
  let fixture: ComponentFixture<ThirdpartiesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ThirdpartiesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ThirdpartiesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
