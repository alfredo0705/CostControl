import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { take, map, defaultIfEmpty, switchMap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  const userJson = localStorage.getItem('user');
  const user = userJson ? JSON.parse(userJson) : null;

  if (user?.token) {
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${user.token}`
      }
    });
  }

  return next.handle(request);
}
}
