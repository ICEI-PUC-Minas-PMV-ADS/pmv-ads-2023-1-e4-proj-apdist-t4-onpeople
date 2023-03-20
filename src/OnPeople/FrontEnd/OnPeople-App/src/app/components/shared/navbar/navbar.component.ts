import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { UserLoged } from 'src/app/models/users/UserLoged';
import { LoginLogoutService } from 'src/app/services/users/login/loginLogout.service';
import { UserService } from 'src/app/services/users/user/user.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public isCollapsed = true;

  public userActive = {} as UserLoged;

  public userLoged = false;
  public visao: string;
  public visaoGold = false;
  public visaoMaster = false;


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
                    this.visao = this.userActive.visao;
                    this.visaoGold = this.visao === "Gold"
                    this.visaoMaster = this.visao === "Master"
                  }
                )
          }
        )
    }

  ngOnInit() {
    console.log("User Loged ", this.userLoged)
  }

  public showMenu(): boolean {
    return this.router.url !== '/users/login' && this.userLoged
  }

  public logout(): void {
    console.log("logout")
    this.loginLogoutService.logout();
    this.router.navigateByUrl('/users/login')
    this.userLoged = false;
  }
}
