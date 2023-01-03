import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewpolicyinformComponent } from './viewpolicyinform.component';

describe('ViewpolicyinformComponent', () => {
  let component: ViewpolicyinformComponent;
  let fixture: ComponentFixture<ViewpolicyinformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewpolicyinformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewpolicyinformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
