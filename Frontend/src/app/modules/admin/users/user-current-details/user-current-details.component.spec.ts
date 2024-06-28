import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCurrentDetailsComponent } from './user-current-details.component';

describe('UserCurrentDetailsComponent', () => {
  let component: UserCurrentDetailsComponent;
  let fixture: ComponentFixture<UserCurrentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserCurrentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserCurrentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
