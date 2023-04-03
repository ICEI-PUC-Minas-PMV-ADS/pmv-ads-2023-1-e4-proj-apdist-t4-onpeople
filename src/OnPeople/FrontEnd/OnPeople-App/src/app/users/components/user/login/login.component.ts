import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { FormValidator } from 'src/app/shared/models';

import { UserLogin } from 'src/app/users/models';

import { LoginLogoutService } from 'src/app/users/services';


@Component({
  selector: 'app-userLogin',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public formLogin: FormGroup;

  public userLogin = {} as UserLogin;

  public get ctrF(): any {
    return this.formLogin.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private loginLogoutService: LoginLogoutService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.spinner.show();
    this.formValidator();
  }

  public formValidator(): void {
    this.formLogin = this.formBuilder.group({
      userName: ['', [ Validators.required, Validators.minLength(4) ]],
      password: ['', [ Validators.required, Validators.minLength(4) ]],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public login(): void {
    this.spinner.show();

    this.userLogin = { ...this.formLogin.value }

    this.loginLogoutService
      .login(this.userLogin)
      .subscribe(
        () => {
          this.router.navigateByUrl('dashboards/empresa');
          location.replace('dashboards/empresa');
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinner.hide())
  }
}
