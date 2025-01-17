import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberTypeDetailsComponent } from './member-type-details.component';

describe('MemberTypeDetailsComponent', () => {
  let component: MemberTypeDetailsComponent;
  let fixture: ComponentFixture<MemberTypeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberTypeDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MemberTypeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
