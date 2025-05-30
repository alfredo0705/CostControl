import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { DepositCreate } from '../_models/deposit-create';

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addDeposit(model: DepositCreate){
    return this.http.post(`${this.baseUrl}deposits/addDeposit`, model);
  }
}
