import { Routes } from '@angular/router';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { AuthLayoutComponent } from './components/layouts/AuthLayout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './components/layouts/MainLayout/main-layout/main-layout.component';
import { ExpenseTypeListComponent } from './components/pages/expense-type/expense-type-list/expense-type-list.component';
import { ExpenseTypeCreateComponent } from './components/pages/expense-type/expense-type-create/expense-type-create.component';
import { ExpenseTypeUpdateComponent } from './components/pages/expense-type/expense-type-update/expense-type-update.component';
import { expenseTypeResolver } from './_resolvers/expense-type.resolver';
import { UserListComponent } from './components/pages/users/user-list/user-list.component';
import { UserCreateComponent } from './components/pages/users/user-create/user-create.component';
import { MonetaryFundListComponent } from './components/pages/monetary-fund/monetary-fund-list/monetary-fund-list.component';
import { MonetaryFundCreateComponent } from './components/pages/monetary-fund/monetary-fund-create/monetary-fund-create.component';
import { MonetaryFundUpdateComponent } from './components/pages/monetary-fund/monetary-fund-update/monetary-fund-update.component';
import { monetaryFundResolver } from './_resolvers/monetary-fund.resolver';
import { BudgetVsExecutedComponent } from './components/pages/movements/budget-vs-executed/budget-vs-executed.component';
import { ExpensesComponent } from './components/pages/movements/expenses/expenses.component';
import { AuthGuard } from './_guards/auth.guard';
import { DepositComponent } from './components/pages/movements/deposit/deposit.component';
import { BudgetCreateComponent } from './components/pages/movements/budget-create/budget-create.component';
import { MovementsComponent } from './components/pages/movements/movements/movements.component';

export const routes: Routes = [{
    path: '',
    runGuardsAndResolvers: 'always',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomePageComponent },
      { path: 'expense-types', component: ExpenseTypeListComponent },
      { path: 'expense-type-create', component: ExpenseTypeCreateComponent},
      { path: 'expense-type-update/:id', component: ExpenseTypeUpdateComponent, resolve: { expenseType: expenseTypeResolver }},
      //{ path: 'users', component: UserListComponent},
      //{ path: 'user-create', component: UserCreateComponent},
      { path: 'monetary-funds', component: MonetaryFundListComponent},
      { path: 'monetary-fund-create', component: MonetaryFundCreateComponent},
      { path: 'monetary-fund-update/:id', component: MonetaryFundUpdateComponent, resolve: {monetaryFund: monetaryFundResolver}},
      { path: 'budget-vs-executed', component: BudgetVsExecutedComponent},
      { path: 'expenses', component: ExpensesComponent},
      { path: 'deposits', component: DepositComponent},
      { path: 'budget', component: BudgetCreateComponent},
      { path: 'movements', component: MovementsComponent}
    ]
  },
{
    path: 'auth',
    component: AuthLayoutComponent,
    children: [
      { path: 'login', component: LoginPageComponent },
    ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];
