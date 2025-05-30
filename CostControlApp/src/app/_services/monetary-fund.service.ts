import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { MonetaryFund } from '../_models/monetary-fund';
import { MonetaryFundCreate } from '../_models/monetary-fund-create';

@Injectable({
  providedIn: 'root'
})
export class MonetaryFundService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMonetaryFunds(){
    return this.http.get<MonetaryFund[]>(`${this.baseUrl}MonetaryFunds/getMonetaryFunds`)
  }

  getMonetaryFundById(id: string){
    return this.http.get<MonetaryFund>(`${this.baseUrl}MonetaryFunds/getMonetaryFundById?id=${id}`)
  }

  getMonetaryFund(name: string){
    return this.http.get<MonetaryFund>(`${this.baseUrl}MonetaryFunds/getMonetaryFund?monetaryFoundName=${name}`)
  }

  addMonetaryFund(model: MonetaryFundCreate){
    return this.http.post(`${this.baseUrl}MonetaryFunds/addMonetaryFund`, model);
  }
  
  updateMonetaryFund(model: MonetaryFund){
    return this.http.put(`${this.baseUrl}MonetaryFunds/updateMonetaryFund`, model);
  }

  deleteMonetaryFund(id: number){
    return this.http.delete(`${this.baseUrl}MonetaryFunds/deleteMonetaryFund?id=${id}`);
  }
}
