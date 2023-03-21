import { Component, OnInit } from '@angular/core';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Users } from 'src/app/users/models';

import { UserService } from 'src/app/users/services';
import { UploadService } from 'src/app/shared/services';

import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  public fotoUpload: string = 'Image_not_available.png';
  public fotoURL: string = "../../../../assets/img/upload1-325x300-1.jpg";
  public file: File[];

  public users = {} as Users;

  public email: string;

  constructor(
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    public uploadService: UploadService,
    public userService: UserService,
  ) { }

  ngOnInit() {
    this.getUserLoged();
  }

  public getUserLoged(): void {
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

  public getDataLoged(userLoged: Users): void {
    this.users = userLoged
  }

  public changePhoto(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.fotoUpload = event.target.result;

    this.file = ev.target.files;

    reader.readAsDataURL(this.file[0]);

    this.uplodaPhoto();
  }

  public uplodaPhoto(): void {
    this.spinnerService.show();

    this.uploadService
      .saveUserPhoto(this.file)
      .subscribe(
        () => {
          this.toastrService.success("Foto atualizada!", "Sucesso!"),
          this.getUserLoged();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}

