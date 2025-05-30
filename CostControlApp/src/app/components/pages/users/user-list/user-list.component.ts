import { Component, OnInit } from '@angular/core';
import { User } from 'devextreme/ui/chat';
import { UserService } from '../../../../_services/user.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule,
    RouterModule
  ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit {
  users:User[];

  constructor(private userService: UserService){}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(){
    this.userService.getUsers().subscribe({
      next: (response) =>{
        this.users = response;
      }
    })
  }

}
