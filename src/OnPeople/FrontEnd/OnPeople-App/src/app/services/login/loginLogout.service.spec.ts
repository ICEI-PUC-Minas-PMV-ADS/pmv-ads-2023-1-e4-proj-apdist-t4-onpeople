/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LoginLogoutService } from './loginLogout.service';

describe('Service: Login', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LoginLogoutService]
    });
  });

  it('should ...', inject([LoginLogoutService], (service: LoginLogoutService) => {
    expect(service).toBeTruthy();
  }));
});
