/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MetasListaComponent } from './metas-lista.component';

describe('MetasListaComponent', () => {
  let component: MetasListaComponent;
  let fixture: ComponentFixture<MetasListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetasListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetasListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
