import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ExpenseTypeService } from '../../../../_services/expense-type.service';
import { ExpenseType } from '../../../../_models/expense-type';
import { DxButtonModule, DxFormModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-expense-type-update',
  standalone: true,
  imports: [
      CommonModule,
      DxFormModule,
      DxTextBoxModule,
      DxTextAreaModule,
      DxButtonModule],
  templateUrl: './expense-type-update.component.html',
  styleUrl: './expense-type-update.component.scss'
})
export class ExpenseTypeUpdateComponent implements OnInit {

  expenseType: ExpenseType;

  constructor(private expenseTypeService: ExpenseTypeService, private router: Router, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.data.subscribe(data =>{
      this.expenseType = data['expenseType'];
  })
}

onSubmit() {
    this.expenseTypeService.updateExpenseType(this.expenseType).subscribe({
      next: () =>{
        this.router.navigate(['/expense-types']);
      }
    })
  }

  goBack(){
    this.router.navigate(['/expense-types']);
  }
}
