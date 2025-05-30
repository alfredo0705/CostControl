import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Component, EventEmitter, Inject, Input, OnInit, Output, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { DxDrawerModule, DxListModule, DxToolbarModule } from 'devextreme-angular';
import { AuthService } from '../../../_services/auth.service';
import { take } from 'rxjs';
import { User } from '../../../_models/auth/user';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, DxDrawerModule, DxListModule, DxToolbarModule, RouterOutlet, RouterModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent implements OnInit {
  @Input() menuItems: any[] = []; // o usa servicio para obtenerlos
  @Output() navigateTo = new EventEmitter<string>();

  navigate(path: string) {
    this.navigateTo.emit(path);
  }
  //menuItems: any[] = [];
  isDrawerOpen = true;
  drawerOpened = true;
  initialized = false;

  constructor(
    private authService: AuthService,
    private router: Router)
  {
  }
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
            { text: 'Usuarios', path: '/users' },
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

  // Toggle para expandir o contraer los grupos
  toggleGroup(group: any) {
    group.expanded = !group.expanded;
  }

onItemClick(e: any) {
  const item = e.itemData;
  if (item?.path) {
    this.router.navigateByUrl(item.path);
    this.isDrawerOpen = false;
  }
}

ngAfterViewInit() {
    // Pequeño retraso para asegurar que el DOM esté listo
    setTimeout(() => this.initialized = true);
  }

  toggleDrawer() {
    this.drawerOpened = !this.drawerOpened;
  }

  /*navigate(path: string) {
    this.drawerOpened = false;
    this.router.navigate([path]);
  }*/

}
