import { isPlatformBrowser } from "@angular/common";
import { User } from "../_models/auth/user";
import { BehaviorSubject, map, Observable, ReplaySubject } from "rxjs";
import { Inject, Injectable, PLATFORM_ID } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  
  constructor(private http: HttpClient, private router: Router, @Inject(PLATFORM_ID) private platformId: Object) { 
    this.loadUser(); 
  }

  loadUser(){
    const userJson = localStorage.getItem('user');
    if (userJson) {
      const user = JSON.parse(userJson);
      this.currentUserSource.next(user);
    }
  }

  register(model: any): Observable<any> {
    return this.http.post(`${this.baseUrl}account/register`, model);
  }

  authEmail(model: any): Observable<any> {
    return this.http.post<User>(`${this.baseUrl}account/login`, model).pipe(
      map((response: User) =>{
        const user = response;
        if (user){
          this.setCurrentUser(user);
          //this.presence.createHubConnection(user);
        }
      })
    )
  }

  setCurrentUser(user: User){
    if (user === null){
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
      return;
    }
    
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  getCurrentUser(): User | null {
    const userJson = localStorage.getItem('user');
    return userJson ? JSON.parse(userJson) : null;
  }

  getDecodedToken(token: string){
    return JSON.parse(atob(token.split('.')[1]));
  }

  logout() {
        localStorage.removeItem('user');
        this.currentUserSource.next(null);
  }
  
}
