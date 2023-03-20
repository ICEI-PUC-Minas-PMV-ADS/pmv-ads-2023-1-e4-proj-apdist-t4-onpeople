import { Component, Input, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { faBuilding, faUsersViewfinder } from '@fortawesome/free-solid-svg-icons'
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { UserLoged } from 'src/app/models/users/UserLoged';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';
import { LoginLogoutService } from 'src/app/services/users/login/loginLogout.service';
@Component({
  selector: 'app-cabecalhoTela',
  templateUrl: './cabecalhoTela.component.html',
  styleUrls: ['./cabecalhoTela.component.scss']
})
export class CabecalhoTelaComponent implements OnInit {
  public codEmpresa: number = 0;
  public nomeEmpresa: string = "";

  public userLoged = false;
  public visao: string = "Not Loged";

  public userActive = {} as UserLoged;

  @Input() titulo: string | undefined;
  @Input() subTitulo = 'Usuário sem empresa';
  @Input() iconCabecalho = faBuilding;
  @Input() iconVisao = faUsersViewfinder;
  @Input() botaoListar = false;


  constructor(
    public empresasService: EmpresasService,
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
                this.codEmpresa = userActive.codEmpresa;
                this.nomeEmpresa = userActive.nomeEmpresa;
                this.subTitulo = (this.nomeEmpresa != "") ? this.nomeEmpresa :  this.subTitulo;
                if (this.userActive.visao == "Master")
                  this.visao = "Gerencial";
                else
                  if (this.userActive.visao == "Golde")
                    this.visao = "Adminstrativa";
                  else
                    this.visao = 'Operacional';
              }
            )
      }
    )
   }

  ngOnInit() {
    this.userLoged = this.userActive !== null;
    this.codEmpresa = this.userActive.codEmpresa;
    this.nomeEmpresa =this.userActive.nomeEmpresa;
    this.subTitulo = (this.nomeEmpresa != "") ? this.nomeEmpresa :  this.subTitulo;
    if (this.userActive.visao == "Master")
      this.visao = "Gerencial";
    else
      if (this.userActive.visao == "Golde")
        this.visao = "Adminstrativa";
      else
        this.visao = 'Operacional';
  }

  public listar(): void {
    this.router.navigate([`/${this.titulo?.toLocaleLowerCase()}/lista`])
  }

  public showCabecalho(): boolean {
    return this.router.url !== '/users/login' && this.userLoged
  }

}
