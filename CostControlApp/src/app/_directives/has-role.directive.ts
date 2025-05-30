import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { take } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/auth/user';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {
  @Input() set appHasRole(allowedRoles: string[]) {
    this.authService.currentUser$.pipe(take(1)).subscribe({
      next: (user: User | null) => {
        if (!user || !user.roles) {
          this.viewContainerRef.clear();
          return;
        }

        const hasRole = user.roles.some(role => allowedRoles.includes(role));
        if (hasRole) {
          this.viewContainerRef.createEmbeddedView(this.templateRef);
        } else {
          this.viewContainerRef.clear();
        }
      }
    });
  }

  constructor(
    private viewContainerRef: ViewContainerRef,
    private templateRef: TemplateRef<any>,
    private authService: AuthService
  ) {}
}
