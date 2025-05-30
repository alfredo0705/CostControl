import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ExpenseCreate } from '../_models/expense-create';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addExpense(model: ExpenseCreate){
    return this.http.post(`${this.baseUrl}expenses/addExpense`, model);
  }
}
