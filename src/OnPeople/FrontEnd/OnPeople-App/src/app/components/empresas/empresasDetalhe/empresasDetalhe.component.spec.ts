import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpresasDetalheComponent } from './empresasDetalhe.component';

describe('EmpresasDetalheComponent', () => {
  let component: EmpresasDetalheComponent;
  let fixture: ComponentFixture<EmpresasDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpresasDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpresasDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
