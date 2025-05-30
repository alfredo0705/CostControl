import { ResolveFn } from '@angular/router';
import { ExpenseType } from '../_models/expense-type';
import { inject } from '@angular/core';
import { ExpenseTypeService } from '../_services/expense-type.service';

export const expenseTypeResolver: ResolveFn<ExpenseType> = (route, state) => {
  return inject(ExpenseTypeService).getExpenseType(route.paramMap.get('id') as string);
};
