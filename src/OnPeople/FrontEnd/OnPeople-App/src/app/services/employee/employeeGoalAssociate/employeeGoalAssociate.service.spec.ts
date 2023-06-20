/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmployeeGoalAssociateService } from './employeeGoalAssociate.service';

describe('Service: EmployeeGoalAssociate', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmployeeGoalAssociateService]
    });
  });

  it('should ...', inject([EmployeeGoalAssociateService], (service: EmployeeGoalAssociateService) => {
    expect(service).toBeTruthy();
  }));
});
