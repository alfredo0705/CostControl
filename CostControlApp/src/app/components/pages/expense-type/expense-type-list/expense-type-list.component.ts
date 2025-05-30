import { Component, OnInit } from '@angular/core';
import { ExpenseType } from '../../../../_models/expense-type';
import { ExpenseTypeService } from '../../../../_services/expense-type.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-expense-type-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './expense-type-list.component.html',
  styleUrl: './expense-type-list.component.scss'
})
export class ExpenseTypeListComponent implements OnInit {

  expenseTypes: ExpenseType[]=[];

  constructor(private expenseTypeService: ExpenseTypeService, private toast: ToastrService){}

  ngOnInit(): void {
    this.loadExpensetypes();
  }

  loadExpensetypes(){
    this.expenseTypeService.getExpenseTypes().subscribe({
      next: (response) =>{
        this.expenseTypes = response;
      }
    })
  }

  deleteExpenseType(id: number){
    const confirmDelete = window.confirm("¿Está seguro que desea eliminar este registro?");

    if (confirmDelete) {
      this.expenseTypeService.deleteExpenseType(id).subscribe({
        next:() =>{
          this.loadExpensetypes();
          this.toast.success("Se elimino exitosamente el registro");
        },
        error: () =>{
          this.toast.error("Error eliminando el registro");
        }
      })
    }
  }

}
