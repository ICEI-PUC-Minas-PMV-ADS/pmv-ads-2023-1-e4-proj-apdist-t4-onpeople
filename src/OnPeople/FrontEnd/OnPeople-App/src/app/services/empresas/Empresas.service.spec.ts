/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmpresasService } from './Empresas.service';


describe('Service: Empresa', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmpresasService]
    });
  });

  it('should ...', inject([EmpresasService], (service: EmpresasService) => {
    expect(service).toBeTruthy();
  }));
});
