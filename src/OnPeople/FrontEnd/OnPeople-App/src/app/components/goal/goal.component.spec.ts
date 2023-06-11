/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GoalComponent } from './goal.component';

describe('MetaComponent', () => {
  let component: GoalComponent;
  let fixture: ComponentFixture<GoalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
