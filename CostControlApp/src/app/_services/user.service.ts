import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from 'devextreme/ui/chat';
import { RegistrationRequest } from '../_models/auth/registrationRequest';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<User[]>(`${this.baseUrl}users/getUsers`);
  }

  getUser(id: string){
    return this.http.get<User[]>(`${this.baseUrl}users/getUser?id=${id}`);
  }

  addUser(model: RegistrationRequest){
    return this.http.post(`${this.baseUrl}users/addUser`, model);
  }

  updateUser(model: RegistrationRequest){
    return this.http.put(`${this.baseUrl}users/updateUser`, model);
  }

  deleteUser(id: string){
    return this.http.delete(`${this.baseUrl}users/deleteUser?id=${id}`);
  }
}
