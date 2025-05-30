import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { MenuComponent } from '../../../common/menu/menu.component';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { DxDrawerModule, DxListModule, DxToolbarModule } from 'devextreme-angular';
import { AuthService } from '../../../../_services/auth.service';
import { take } from 'rxjs';
import { User } from '../../../../_models/auth/user';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [CommonModule, DxDrawerModule, DxListModule, DxToolbarModule, RouterOutlet, RouterModule, MenuComponent],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent implements OnInit {
  menuItems: any[] = [];
  drawerOpened = true;
  navigation = [
  {
    text: 'Mantenimientos',
    icon: 'preferences',
    items: [
      { text: 'Tipos de Gasto', path: 'expense-types' },
      { text: 'Fondo Monetario', path: 'monetary-funds' },
    ]
  },
  {
    text: 'Movimientos',
    icon: 'money',
    items: [
      { text: 'Presupuesto por Tipo de Gasto', path: 'budget' },
      { text: 'Registros de Gastos', path: 'expenses' },
      { text: 'Depósitos', path: 'deposits' },
    ]
  },
  {
    text: 'Consultas y Reportes',
    icon: 'chart',
    items: [
      { text: 'Consulta de Movimientos', path: 'movements' },
      { text: 'Gráfico Comparativo', path: 'budget-vs-executed' },
    ]
  }
];

  buttonOptions = {
    icon: 'menu',
    onClick: () => {
      this.drawerOpened = !this.drawerOpened;
    }
  };

  ngOnInit(): void {
      this.authService.currentUser$.pipe(take(1)).subscribe((user: User | null) => {
        if (!user) return;
  
        // Base menu (visible para todos)
        this.menuItems = [
          {
            text: 'Movimientos',
            items: [
              { text: 'Presupuesto tipo de gasto', path: '/budget' },
              { text: 'Registros de gastos', path: '/expenses' },
              { text: 'Registros de depósitos', path: '/deposits' }
            ]
          }
        ];
  
        // Solo para Admin
        if (user.roles.includes('Admin')) {
          this.menuItems.unshift({
            text: 'Mantenimientos',
            items: [
              { text: 'Tipos de Gasto', path: '/expense-types' },
              //{ text: 'Usuarios', path: '/users' },
              { text: 'Fondo Monetario', path: '/monetary-funds' }
            ]
          });
        }
      });
  
      this.menuItems.push({
            text: 'Consultas y Reportes',
            items: [
              { text: 'Presupuesto por usuario y tipo de gasto', path: '/budget-vs-executed' }
            ]
          });
    }

  toggleDrawer() {
    this.drawerOpened = !this.drawerOpened;
  }

  navigate(path: string) {
    this.router.navigate([path]);
  }

  constructor(@Inject(PLATFORM_ID) private platformId: Object, public router: Router,
      private authService: AuthService){
  }
  
  isLoginPage(): boolean {
    return this.router.url === '/auth/login';
  }

}
