import { Component } from '@angular/core';
import { MonetaryFundCreate } from '../../../../_models/monetary-fund-create';
import { MonetaryFundService } from '../../../../_services/monetary-fund.service';
import { Router } from '@angular/router';
import { DxButtonModule, DxFormModule, DxNumberBoxModule, DxSelectBoxModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';

@Component({
  selector: 'app-monetary-fund-create',
  standalone: true,
  imports: [
      DxFormModule,
      DxTextBoxModule,
      DxTextAreaModule,
      DxButtonModule,
      DxNumberBoxModule,
      DxSelectBoxModule],
  templateUrl: './monetary-fund-create.component.html',
  styleUrl: './monetary-fund-create.component.scss'
})
export class MonetaryFundCreateComponent {
  types = ['Caja Menor', 'Cuenta Bancaria'];

  constructor(private monetaryFundService: MonetaryFundService, private router: Router){}

  monetaryFund: MonetaryFundCreate={
    currentBalance: 0,
    initialBalance: 0,
    name:'',
    type:''
  }

  onSubmit() {
    this.monetaryFundService.addMonetaryFund(this.monetaryFund).subscribe({
      next: () =>{
        this.router.navigate(['/monetary-funds']);
      }
    })
  }
  
  goBack(){
    this.router.navigate(['/monetary-funds']);
  }
}
