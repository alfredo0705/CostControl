import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Component, Inject, NgZone, OnInit, PLATFORM_ID } from '@angular/core';
import { AuthService } from '../../../_services/auth.service';
import { Router } from '@angular/router';
import { DxFormModule, DxButtonModule, DxTextBoxModule } from 'devextreme-angular';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [CommonModule, DxFormModule, DxButtonModule, DxTextBoxModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent{
  loginModel = {
    username: '',
    password: ''
  };

  constructor(
    private router: Router,
    private ngZone: NgZone,
    private authServiceAPI: AuthService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) 
  {
  }

  loginByEmail() {
    this.authServiceAPI.authEmail(this.loginModel).subscribe({
      next: () => this.ngZone.run(() => this.router.navigate(['/home'])),
      error: (error) => console.error('Error en la autenticación:', error)
    });
  }

}
