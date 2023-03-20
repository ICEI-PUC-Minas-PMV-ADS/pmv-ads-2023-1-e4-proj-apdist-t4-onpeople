import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios/ValidadorFormularios';
import { UserLogin } from 'src/app/models/users/UserLogin';
import { LoginLogoutService } from 'src/app/services/users/login/loginLogout.service';

import { faUserLock, faUser, faKey, IconDefinition,} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-userLogin',
  templateUrl: './userLogin.component.html',
  styleUrls: ['./userLogin.component.scss']
})
export class UserLoginComponent implements OnInit {
  public form: FormGroup;

  public iconUserLock: IconDefinition = faUserLock;
  public faUser: IconDefinition = faUser;
  public faKey: IconDefinition = faKey;

  public userLogin = {} as UserLogin;

  public get ctrF(): any {
    return this.form.controls;
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
    this.validarFormulario();
  }

  public validarFormulario(): void {
    this.form = this.formBuilder.group({
      userName: ['', [ Validators.required, Validators.minLength(4) ]],
      password: ['', [ Validators.required, Validators.minLength(4) ]],
    });
  }

  public validarCampo(campoForm: FormControl): any {
    return ValidadorFormularios.verificarErroCampo(campoForm);
  }

  public retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidadorFormularios.retornarMensagem(nomeCampo, nomeElemento);
  }

  public login(): void {
    this.spinner.show();

    this.userLogin = { ...this.form.value }

    this.loginLogoutService
      .login(this.userLogin)
      .subscribe(
        () => {
          location.reload;
          this.router.navigateByUrl('users/profile');
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);

        }
      )
      .add(() => this.spinner.hide())
  }
}
