import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { Constants } from '../../models';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private toatrService: ToastrService
  ) {}

  canActivate(): boolean {

    if (localStorage.getItem(Constants.LOCAL_STORAGE_NAME) !== null)
      return true;

    this.toatrService.info("Conta não autenticada!", "Info!")
    this.router.navigate(['/users/login'])

    return false;
  }


}
