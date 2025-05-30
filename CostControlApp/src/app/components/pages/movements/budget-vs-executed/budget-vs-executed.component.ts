import { Component } from '@angular/core';
import { BudgetsService } from '../../../../_services/budgets.service';
import { BudgetExecutionFilter } from '../../../../_models/budget-execution-filter';
import { DxButtonModule, DxChartModule, DxDataGridModule, DxDateBoxModule, DxFormModule, DxTooltipModule } from 'devextreme-angular';
import { Router } from '@angular/router';
import { BudgetVsExecuted } from '../../../../_models/budget-vs-executed';
import { MovementService } from '../../../../_services/movement.service';

@Component({
  selector: 'app-budget-vs-executed',
  standalone: true,
  imports: [
    DxFormModule,
    DxDateBoxModule,
    DxButtonModule,
    DxDataGridModule,
    DxChartModule,
    DxTooltipModule
  ],
  templateUrl: './budget-vs-executed.component.html',
  styleUrl: './budget-vs-executed.component.scss'
})
export class BudgetVsExecutedComponent {
  budgetVsExecuted: BudgetVsExecuted[];
  constructor(private movementService: MovementService, private router: Router){}

  filter: BudgetExecutionFilter={
    from: new Date(),
    to: new Date()
  }

   onSubmit() {
    this.movementService.budgetVsExecuted(this.filter).subscribe({
      next: (response) =>{
        this.budgetVsExecuted = response;
      }
    })
  }

}
