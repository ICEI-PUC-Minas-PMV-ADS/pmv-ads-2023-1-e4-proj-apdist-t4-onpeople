import { Component, Input, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { UserLoged } from 'src/app/users/models';

import { LoginLogoutService } from 'src/app/users/services';

@Component({
  selector: 'app-titlebar',
  templateUrl: './titlebar.component.html',
  styleUrls: ['./titlebar.component.scss']
})
export class TitlebarComponent implements OnInit {

  @Input() title: string | undefined;
  @Input() buttonList = false;
  @Input() iconTitlebar: string;

  public companyCode: number = 0;
  public companyName: string = "";

  public userLoged = false;
  public vision: string = "Not Loged";

  public userActive = {} as UserLoged;

  public subTitle = 'Usuário sem empresa';


  constructor(
    public loginLogoutService: LoginLogoutService,
    private router: Router,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
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
                this.companyCode = userActive.codEmpresa;
                this.companyName = userActive.nomeEmpresa;
                this.subTitle = (this.companyName != "") ? this.companyName :  this.subTitle;
                if (this.userActive.visao == "Master")
                  this.vision = "Gerencial";
                else
                  if (this.userActive.visao == "Golde")
                    this.vision = "Adminstrativa";
                  else
                    this.vision = 'Operacional';
              }
            )
      }
    )
   }

  ngOnInit() {
    this.userLoged = this.userActive !== null;
    this.companyCode = this.userActive.codEmpresa;
    this.companyName =this.userActive.nomeEmpresa;
    this.subTitle = (this.companyName != "") ? this.companyName :  this.subTitle;
    if (this.userActive.visao == "Master")
      this.vision = "Gerencial";
    else
      if (this.userActive.visao == "Golde")
        this.vision = "Adminstrativa";
      else
        this.vision = 'Operacional';
  }

  public listNavigate(): void {
    this.router.navigate([`/${this.title?.toLocaleLowerCase()}/list`])
  }

  public showCabecalho(): boolean {
    return this.router.url !== '/users/login' && this.userLoged
  }

}
