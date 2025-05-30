import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DxButtonModule, DxDateBoxModule, DxFormModule, DxNumberBoxModule, DxSelectBoxModule } from 'devextreme-angular';
import { AuthService } from '../../../../_services/auth.service';
import { MonetaryFundService } from '../../../../_services/monetary-fund.service';
import { MonetaryFund } from '../../../../_models/monetary-fund';
import { CommonModule } from '@angular/common';
import { DepositCreate } from '../../../../_models/deposit-create';
import { DepositService } from '../../../../_services/deposit.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-deposit',
  standalone: true,
  imports: [DxFormModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxNumberBoxModule,
    DxButtonModule],
  templateUrl: './deposit.component.html',
  styleUrl: './deposit.component.scss'
})
export class DepositComponent implements OnInit {
  monetaryFunds:MonetaryFund[] = []; 
  deposit: DepositCreate = {
    amount: 0,
    monetaryFundId: 0,
    date: new Date()
  }

  constructor(
    private monetaryFundService: MonetaryFundService, 
    private depositService: DepositService,
    private toastr: ToastrService) {}

  ngOnInit(): void {

    this.loadMonetaryFunds();
  }

  loadMonetaryFunds() {
    this.monetaryFundService.getMonetaryFunds().subscribe({
      next: (response) =>{
        this.monetaryFunds = response;
      }
    })
  }

  onSubmit(): void {
    this.depositService.addDeposit(this.deposit).subscribe({
      next: () =>{
        this.toastr.success("Deposito guardado");
      }
    })

  }
}
