import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMembersTypeComponent } from './create-members-type.component';

describe('CreateMembersTypeComponent', () => {
  let component: CreateMembersTypeComponent;
  let fixture: ComponentFixture<CreateMembersTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateMembersTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateMembersTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
