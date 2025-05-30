import { Component, OnInit } from '@angular/core';
import { MonetaryFundService } from '../../../../_services/monetary-fund.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MonetaryFund } from '../../../../_models/monetary-fund';
import { DxButtonModule, DxFormModule, DxNumberBoxModule, DxSelectBoxModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';

@Component({
  selector: 'app-monetary-fund-update',
  standalone: true,
  imports: [
    DxFormModule,
    DxTextBoxModule,
    DxTextAreaModule,
    DxButtonModule,
    DxNumberBoxModule,
    DxSelectBoxModule],
  templateUrl: './monetary-fund-update.component.html',
  styleUrl: './monetary-fund-update.component.scss'
})
export class MonetaryFundUpdateComponent implements OnInit {
  types = ['Caja Menor', 'Cuenta Bancaria'];
  monetaryFund: MonetaryFund;
  constructor(private monetaryFundService: MonetaryFundService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.monetaryFund = data['monetaryFund'];
    })
  }

  onSubmit() {
    this.monetaryFundService.updateMonetaryFund(this.monetaryFund).subscribe({
      next: () => {
        this.router.navigate(['/monetary-funds']);
      }
    })
  }
  goBack() {
    this.router.navigate(['/monetary-funds']);
  }
}
