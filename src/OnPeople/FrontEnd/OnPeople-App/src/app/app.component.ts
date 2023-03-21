import { Component } from '@angular/core';
import { Constants } from './shared/models/constants/constants';

import { Users } from './users/models';

import { LoginLogoutService } from './users/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {
  constructor(
    private loginLogoutService: LoginLogoutService
  ) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  public setCurrentUser(): void {
    let user = {} as Users;

    if (localStorage.getItem(Constants.LOCAL_STORAGE_NAME))
      user = JSON.parse(localStorage.getItem(Constants.LOCAL_STORAGE_NAME) ?? '{}');

    if (user)
      this.loginLogoutService.setCurrentUser(user);
  }
}
