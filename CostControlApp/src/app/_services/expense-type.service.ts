import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import {ExpenseType} from '../_models/expense-type'
import { ExpenseTypeCreate } from '../_models/expense-type-create';

@Injectable({
  providedIn: 'root'
})
export class ExpenseTypeService {
  baseUrl = environment.apiUrl;

  
  constructor(private http: HttpClient) {
   }

  getExpenseTypes(){
    return this.http.get<ExpenseType[]>(`${this.baseUrl}expenseType/getExpenseTypes`)
  }

  getExpenseType(id: string){
    return this.http.get<ExpenseType>(`${this.baseUrl}expenseType/getExpenseType?id=${id}`);
  }

  addExpenseType(model: ExpenseTypeCreate){
    return this.http.post(`${this.baseUrl}expenseType/addExpenseType`, model);
  }

  updateExpenseType(model: ExpenseType){
    return this.http.put(`${this.baseUrl}expenseType/updateExpenseType`, model);
  }

  deleteExpenseType(id: number){
    return this.http.delete(`${this.baseUrl}expenseType/deleteExpenseType?id=${id}`);
  }
}
