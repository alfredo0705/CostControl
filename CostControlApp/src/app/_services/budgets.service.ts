import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Budget } from '../_models/budget';
import { BudgetCreate } from '../_models/budget-create';
import { BudgetExecutionFilter } from '../_models/budget-execution-filter';
import { BudgetVsExecuted } from '../_models/budget-vs-executed';

@Injectable({
  providedIn: 'root'
})
export class BudgetsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getBudgets(year: number, month: number){
    return this.http.get<Budget[]>(`${this.baseUrl}budgets/getBudgets?year=${year}&month=${month}`)
  }

  getBudget(id: number){
    return this.http.get<Budget>(`${this.baseUrl}budgets/getBudget?id=${id}`)
  }

  addBudget(model:BudgetCreate[]){
    return this.http.post(`${this.baseUrl}budgets/addBudget`, model)
  }

  updateBudget(model:Budget){
    return this.http.put(`${this.baseUrl}budgets/updateBudget`, model);
  }

  deleteBudget(id: number){
    return this.http.delete(`${this.baseUrl}budgets/deleteBudget?id=${id}`)
  }
}
