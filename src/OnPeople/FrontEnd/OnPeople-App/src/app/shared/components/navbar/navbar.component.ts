import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { UserLoged } from 'src/app/users/models';

import { LoginLogoutService } from 'src/app/users/services';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent implements OnInit {
  public isCollapsed = true;

  public userActive = {} as UserLoged;

  public userLoged = false;

  constructor(
    public loginLogoutService: LoginLogoutService,
    private router: Router
    ) {
      router.events
        .subscribe(
          (verifyUser) => {
            if (verifyUser instanceof NavigationEnd)
              this.loginLogoutService.currentUser$
                .subscribe(
                  (userActive) => {
                    this.userLoged = userActive !== null;
                    this.userActive = { ...userActive};
                  }
                )
          }
        )
    }

  ngOnInit() {
  }

  public showMenu(): boolean {
    return this.router.url !== '/users/login' && this.userLoged
  }

  public logout(): void {
    this.loginLogoutService.logout();
    this.router.navigateByUrl('/users/login')
    this.userLoged = false;
  }
}
