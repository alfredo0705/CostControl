import { ResolveFn } from '@angular/router';
import { MonetaryFund } from '../_models/monetary-fund';
import { inject } from '@angular/core';
import { MonetaryFundService } from '../_services/monetary-fund.service';

export const monetaryFundResolver: ResolveFn<MonetaryFund> = (route, state) => {
  return inject(MonetaryFundService).getMonetaryFundById(route.paramMap.get('id') as string);
};
