/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { Evento.serviceService } from './evento.service.service';

describe('Service: Evento.service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Evento.serviceService]
    });
  });

  it('should ...', inject([Evento.serviceService], (service: Evento.serviceService) => {
    expect(service).toBeTruthy();
  }));
});
