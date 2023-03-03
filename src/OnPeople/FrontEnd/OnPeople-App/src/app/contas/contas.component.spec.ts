/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ContasComponent } from './contas.component';

describe('ContasComponent', () => {
  let component: ContasComponent;
  let fixture: ComponentFixture<ContasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
