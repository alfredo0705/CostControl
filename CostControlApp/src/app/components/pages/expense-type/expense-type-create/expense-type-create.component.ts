import { Component } from '@angular/core';
import { DxButtonModule, DxFormModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';
import { ExpenseTypeCreate } from '../../../../_models/expense-type-create';
import { ExpenseTypeService } from '../../../../_services/expense-type.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-expense-type-create',
  standalone: true,
  imports: [
    DxFormModule,
    DxTextBoxModule,
    DxTextAreaModule,
    DxButtonModule],
  templateUrl: './expense-type-create.component.html',
  styleUrl: './expense-type-create.component.scss'
})
export class ExpenseTypeCreateComponent {

  constructor(private expenseTypeService: ExpenseTypeService, private router: Router){}

   // Modelo inicial vacío
  expenseType: ExpenseTypeCreate = {
    name: '',
    description: ''
  };

  onSubmit() {
    this.expenseTypeService.addExpenseType(this.expenseType).subscribe({
      next: () =>{
        this.router.navigate(['/expense-types']);
      }
    })
  }

  goBack(){
    this.router.navigate(['/expense-types']);
  }

}
