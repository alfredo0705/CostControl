import { Component } from '@angular/core';
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxFormModule } from 'devextreme-angular';
import { BudgetExecutionFilter } from '../../../../_models/budget-execution-filter';
import { BudgetVsExecuted } from '../../../../_models/budget-vs-executed';
import { BudgetsService } from '../../../../_services/budgets.service';
import { Router } from '@angular/router';
import { MovementService } from '../../../../_services/movement.service';
import { Movement } from '../../../../_models/movement';

@Component({
  selector: 'app-movements',
  standalone: true,
  imports: [
      DxFormModule,
      DxDateBoxModule,
      DxButtonModule,
      DxDataGridModule
    ],
  templateUrl: './movements.component.html',
  styleUrl: './movements.component.scss'
})
export class MovementsComponent {
  movements: Movement[];
  constructor(private movementService: MovementService, private router: Router){}

  filter: BudgetExecutionFilter={
    from: new Date(),
    to: new Date()
  }

   onSubmit() {
    this.movementService.getMovements(this.filter).subscribe({
      next: (response) =>{
        this.movements = response;
      }
    })
  }
}
