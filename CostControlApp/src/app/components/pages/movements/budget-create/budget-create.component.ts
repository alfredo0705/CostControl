import { Component } from '@angular/core';
import { AuthService } from '../../../../_services/auth.service';
import { ExpenseTypeService } from '../../../../_services/expense-type.service';
import { BudgetsService } from '../../../../_services/budgets.service';
import { BudgetCreate } from '../../../../_models/budget-create';
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxFormModule, DxSelectBoxModule, DxTextBoxModule } from 'devextreme-angular';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-budget-create',
  standalone: true,
  imports: [
      DxFormModule,
      DxTextBoxModule,
      DxSelectBoxModule,
      DxDateBoxModule,
      DxDataGridModule,
      DxButtonModule
  ],
  templateUrl: './budget-create.component.html',
  styleUrl: './budget-create.component.scss'
})
export class BudgetCreateComponent {

  constructor(
    private authService: AuthService, 
    private expenseTypeService: ExpenseTypeService, 
    private budgetService: BudgetsService,
    private toast: ToastrService){}

form = {
  month: new Date() 
};

budgetByExpenseType = [];

ngOnInit() {
  this.loadBudgetForMonth(this.form.month.getFullYear(), this.form.month.getMonth() + 1);
}

onMonthChanged(e: any) {
  const selectedDate = e.value;
  if (selectedDate) {
    const month = selectedDate.getMonth() + 1;
    const year = selectedDate.getFullYear();

    this.loadBudgetForMonth(year, month);
  }
}

loadBudgetForMonth(year: number, month: number) {
  this.expenseTypeService.getExpenseTypes().subscribe((types) => {
    this.budgetService.getBudgets(year, month).subscribe({
      next: (response) =>{
        this.budgetByExpenseType = types.map(type => {
          let budget = response.find(b => b.expenseTypeId === type.id);
          return {
            id: budget ? budget.id : 0,
            expenseTypeName: type.name,
            amount: budget ? budget.amount : 0,
            expenseTypeId: type.id
          };
        });
      }
    });
  });
}

onSave() {

  const body: BudgetCreate[] = this.budgetByExpenseType.map(p => ({
    id: p.id,
    expenseTypeId: p.expenseTypeId,
    period: this.form.month,
    amount: Number(p.amount) || 0
  }));

  this.budgetService.addBudget(body).subscribe({
    next: () =>{
      this.toast.success('Presupuesto guardado')
    }
  });
}
}
