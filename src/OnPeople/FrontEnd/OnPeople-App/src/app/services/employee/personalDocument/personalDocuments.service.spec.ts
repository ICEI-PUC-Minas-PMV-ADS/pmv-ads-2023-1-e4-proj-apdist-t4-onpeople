/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PersonalDocumentsService } from './personalDocuments.service';

describe('Service: PersonalDocuments', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonalDocumentsService]
    });
  });

  it('should ...', inject([PersonalDocumentsService], (service: PersonalDocumentsService) => {
    expect(service).toBeTruthy();
  }));
});
