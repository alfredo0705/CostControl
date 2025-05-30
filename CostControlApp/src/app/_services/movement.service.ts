import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { BudgetExecutionFilter } from '../_models/budget-execution-filter';
import { BudgetVsExecuted } from '../_models/budget-vs-executed';
import { Movement } from '../_models/movement';

@Injectable({
  providedIn: 'root'
})
export class MovementService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  budgetVsExecuted(model: BudgetExecutionFilter){
    return this.http.post<BudgetVsExecuted[]>(`${this.baseUrl}movements/budget-vs-executed`, model);
  }

  getMovements(model: BudgetExecutionFilter){
    return this.http.post<Movement[]>(`${this.baseUrl}movements/get-movements`, model);
  }
}
