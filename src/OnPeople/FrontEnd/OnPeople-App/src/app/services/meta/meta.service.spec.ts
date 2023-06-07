/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { JobRoleService } from './meta.service';

describe('Service: JobRole', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JobRoleService]
    });
  });

  it('should ...', inject([JobRoleService], (service: JobRoleService) => {
    expect(service).toBeTruthy();
  }));
});
