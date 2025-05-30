import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { AuthService } from "../_services/auth.service";
import { catchError, Observable, throwError } from "rxjs";
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  isRefreshing = false;
  constructor(
    private router: Router,
    private toastr: ToastrService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        // Manejo de otros errores
        switch (error.status) {
          case 400:
            if (error.error.errors) {
              const modalStateErrors = [];
              for (const key in error.error.errors) {
                if (error.error.errors[key]) {
                  modalStateErrors.push(error.error.errors[key]);
                }
              }
              throw modalStateErrors.flat();
            } else if (typeof error.error === 'object') {
              this.toastr.error(error.error.message || error.statusText, error.status.toString());
            } else {
              this.toastr.error(error.error, error.status.toString());
            }
            break;
            case 401:
              this.router.navigateByUrl('/auth/login');
              break;
          case 403:
            this.toastr.error('No está autorizado para realizar esta acción');
            this.router.navigateByUrl('/');
            break;
          case 404:
            this.toastr.error('Ocurrió un error');
            //this.router.navigateByUrl('/');
            break;
          case 500:
            const navigationExtras: NavigationExtras = { state: { error: error.error } };
            this.router.navigateByUrl('/server-error', navigationExtras);
            break;
          default:
            //this.toastr.error('Ocurrió un error');
            break;
        }
  
        return throwError(error);
      })
    );
  }  
}
