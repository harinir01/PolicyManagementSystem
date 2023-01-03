import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyformComponent } from './policyform.component';

describe('PolicyformComponent', () => {
  let component: PolicyformComponent;
  let fixture: ComponentFixture<PolicyformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolicyformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PolicyformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
