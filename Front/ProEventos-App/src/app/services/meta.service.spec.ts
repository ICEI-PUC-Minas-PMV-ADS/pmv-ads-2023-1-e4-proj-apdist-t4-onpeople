/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MetaService } from './meta.service';

describe('Service: Meta', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MetaService]
    });
  });

  it('should ...', inject([MetaService], (service: MetaService) => {
    expect(service).toBeTruthy();
  }));
});
