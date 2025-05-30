import { Component, OnInit } from '@angular/core';
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxFormModule, DxSelectBoxModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';
import { DxoGridModule } from 'devextreme-angular/ui/nested';
import { ExpenseCreate } from '../../../../_models/expense-create';
import { MonetaryFundService } from '../../../../_services/monetary-fund.service';
import { MonetaryFund } from '../../../../_models/monetary-fund';
import { ExpenseTypeService } from '../../../../_services/expense-type.service';
import { ExpenseType } from '../../../../_models/expense-type';
import { ExpenseService } from '../../../../_services/expense.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-expenses',
  standalone: true,
  imports: [
    DxFormModule,
    DxTextBoxModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxTextAreaModule,
    DxDataGridModule,
    DxButtonModule
  ],
  templateUrl: './expenses.component.html',
  styleUrl: './expenses.component.scss'
})
export class ExpensesComponent implements OnInit {

  constructor(
    private monetaryFundService: MonetaryFundService,
    private expenseTypeService: ExpenseTypeService,
    private expenseService:ExpenseService,
    private toastr: ToastrService){}

  ngOnInit(): void {
    this.loadMonetaryFunds();
    this.loadExpenseTypes();
  }

  expense: ExpenseCreate = {
    date: new Date(),
    monetaryFundId: null!,
    notes: '',
    storeName: '',
    documentType: '',
    details: []
  };

  monetaryFunds:MonetaryFund[] = []; 
  expenseTypes:ExpenseType[] = []; // Cargar desde API
  documentTypes = ['Comprobante', 'Factura', 'Otro'];

  loadMonetaryFunds() {
    this.monetaryFundService.getMonetaryFunds().subscribe({
      next: (response) =>{
        this.monetaryFunds = response;
      }
    })
  }

  loadExpenseTypes() {
    this.expenseTypeService.getExpenseTypes().subscribe({
      next: (response) =>{
        this.expenseTypes = response;
      }
    })
  }

  async onSave() {
    this.expenseService.addExpense(this.expense).subscribe({
      next: () =>{
        this.toastr.success("Gasto guardado");
      }
    })
  }

}
