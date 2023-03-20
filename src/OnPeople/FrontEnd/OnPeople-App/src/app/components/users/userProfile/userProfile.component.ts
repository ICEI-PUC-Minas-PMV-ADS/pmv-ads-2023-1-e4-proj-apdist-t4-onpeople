import { Component, OnInit } from '@angular/core';

import { faIdCard, faKey } from '@fortawesome/free-solid-svg-icons'
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { UserLoged } from 'src/app/models/users/UserLoged';
import { Users } from 'src/app/models/users/Users';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';
import { UploadsService } from 'src/app/services/uploads/uploads.service';
import { UserService } from 'src/app/services/users/user/user.service';
import { environment } from 'src/assets/environments/environments';

@Component({
  selector: 'app-userProfile',
  templateUrl: './userProfile.component.html',
  styleUrls: ['./userProfile.component.scss']
})
export class UserProfileComponent implements OnInit {

  public iconTab1 = faIdCard;
  public iconTab2 = faKey;

  public fotoUpload: string = 'Image_not_available.png';
  public fotoURL: string = "../../../../assets/img/upload1-325x300-1.jpg";
  public file: File[];

  public users = {} as Users;
  public empresa: Empresa;

  public email: string;

  constructor(
    public empresasService: EmpresasService,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    public uploadsService: UploadsService,
    public userService: UserService,
  ) { }

  ngOnInit() {
    this.carregarUserLoged();
  }

  public carregarUserLoged(): void {
    this.spinnerService.show();

    this.userService
      .getUserByUserName()
      .subscribe(
        (users: Users) => {
          this.users = { ... users}
          this.fotoURL = (this.users.foto !== '' && this.users.foto !== null)
            ? environment.resourcesFotosURL + this.users.foto
            : "../../../../assets/img/upload1-325x300-1.jpg";
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.log(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public recuperarDadosConta(userLoged: Users): void {
    this.users = userLoged
  }

  public alterarFoto(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.fotoUpload = event.target.result;

    this.file = ev.target.files;

    reader.readAsDataURL(this.file[0]);

    this.uplodaFoto();
  }

  public uplodaFoto(): void {
    this.spinnerService.show();

    this.uploadsService
      .salvarFotoUser(this.file)
      .subscribe(
        () => {
          this.toastrService.success("Foto atualizada!", "Sucesso!"),
          this.carregarUserLoged();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}

