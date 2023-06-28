/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DashJobRoleComponent } from './dashJobRole.component';

describe('DashJobRoleComponent', () => {
  let component: DashJobRoleComponent;
  let fixture: ComponentFixture<DashJobRoleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashJobRoleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashJobRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
