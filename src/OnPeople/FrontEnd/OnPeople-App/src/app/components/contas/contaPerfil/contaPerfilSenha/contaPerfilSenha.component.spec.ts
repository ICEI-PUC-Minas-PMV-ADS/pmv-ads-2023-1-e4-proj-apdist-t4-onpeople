/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ContaPerfilSenhaComponent } from './contaPerfilSenha.component';

describe('ContaPerfilSenhaComponent', () => {
  let component: ContaPerfilSenhaComponent;
  let fixture: ComponentFixture<ContaPerfilSenhaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContaPerfilSenhaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaPerfilSenhaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
