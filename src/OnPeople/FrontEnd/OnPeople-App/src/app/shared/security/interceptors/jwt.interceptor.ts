import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';

import { catchError, Observable, take, throwError } from 'rxjs';

import { Constants } from '../../models/constants/constants';

import { Users } from 'src/app/users/models';

import { LoginLogoutService } from 'src/app/users/services';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private loginLogoutService: LoginLogoutService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let userCurrent: Users;

    this.loginLogoutService.currentUser$
      .pipe(take(1))
      .subscribe (
        user => {
          userCurrent = user

          if (userCurrent) {
            request = request.clone({
              setHeaders: {
                Authorization: `Bearer ${userCurrent.token}`
              }
            });
          }
        }
      );

    return next.handle(request)
      .pipe(catchError(
        error => {
          if (error) {
//            localStorage.removeItem(Constants.LOCAL_STORAGE_NAME);
          }
          return throwError(error);
        }
      ));
  }
}
