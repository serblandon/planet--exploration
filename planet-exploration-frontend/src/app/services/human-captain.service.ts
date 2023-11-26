import { Injectable } from '@angular/core';
import { GenericRestApi } from '../infrastructure/generic-rest-api';
import { IHumanCaptain } from '../interfaces/human-captain';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HumanCaptainService extends GenericRestApi<IHumanCaptain>{

  constructor(protected override http: HttpClient) {
    super(http, "api/HumanCaptain");
  }
}
