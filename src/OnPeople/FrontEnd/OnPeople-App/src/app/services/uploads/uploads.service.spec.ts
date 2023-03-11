/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UploadsService } from './uploads.service';

describe('Service: Uploads', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UploadsService]
    });
  });

  it('should ...', inject([UploadsService], (service: UploadsService) => {
    expect(service).toBeTruthy();
  }));
});
