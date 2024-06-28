import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembersTypesListComponent } from './members-types-list.component';

describe('MembersTypesListComponent', () => {
  let component: MembersTypesListComponent;
  let fixture: ComponentFixture<MembersTypesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MembersTypesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MembersTypesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
