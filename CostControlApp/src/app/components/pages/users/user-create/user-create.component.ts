import { Component } from '@angular/core';
import { DxButtonModule, DxDateBoxModule, DxFormModule, DxSelectBoxModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';
import { RegistrationRequest } from '../../../../_models/auth/registrationRequest';
import { UserService } from '../../../../_services/user.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-user-create',
  standalone: true,
  imports: [
        DxFormModule,
        DxTextBoxModule,
        DxTextAreaModule,
        DxButtonModule,
      DxDateBoxModule,
    DxSelectBoxModule],
  templateUrl: './user-create.component.html',
  styleUrl: './user-create.component.scss'
})
export class UserCreateComponent {

  constructor(private userService: UserService, private router: Router){}

  user: RegistrationRequest = {
    address: '',
    birthdate:new Date(),
    documentId: '',
    email: '',
    firstName: '',
    lastName: '',
    password: '',
    rol: '',
    username: ''
  }

  roles = ['Admin', 'User'];

  // Función para manejar la acción de guardar
  onSubmit() {
    this.userService.addUser(this.user).subscribe({
      next: () =>{
        this.router.navigate(['/users']);
      }
    })
  }

}
