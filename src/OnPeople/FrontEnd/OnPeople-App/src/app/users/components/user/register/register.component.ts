import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { FormValidator } from 'src/app/shared/models';

import { Users } from 'src/app/users/models';

import { UserService } from 'src/app/users/services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public formRegister: FormGroup;

  public newUser = {} as Users;

  public get ctrF(): any {
    return this.formRegister.controls;
  }

  constructor(
    private fb: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private userService: UserService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.formValidator();

  }

  public formValidator(): void {

    const formOptions: AbstractControlOptions = {
      validators: FormValidator.argsCompare('password', 'confirmPassword')
    };

    this.formRegister = this.fb.group({
      userName: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(15)]],
      nomeCompleto: ['', [ Validators.required,  Validators.minLength(4), Validators.maxLength(40)]],
      password: ['', [ Validators.required, Validators.minLength(3)]],
      confirmPassword: ['', [ Validators.required ]],
    }, formOptions);
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public validatorReturn(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public createUser(): void {
    this.spinnerService.show();

    this.newUser = { ...this.formRegister.value};

    this.newUser.email = "default@default.com.br";
    this.newUser.dataCadastro = new Date();

    this.newUser.visao = (this.newUser.userName == 'Admin') ? "Master" : "Default";
    this.newUser.master = (this.newUser.userName == 'Admin') ? true : false;
    this.newUser.gold = false;
    this.newUser.bronze = false;
    this.newUser.ativa = true;
    this.newUser.codEmpresa = 0;
    this.newUser.codCargo = 0;
    this.newUser.codDepartamento = 0;
    this.newUser.codFuncionario = 0;
    this.newUser.codMeta = 0;

    this.userService
      .createUser(this.newUser)
      .subscribe(
        () => {
          this.router.navigateByUrl('dashboards/empresa');
          location.replace('dashboards/empresa');
          this.toastrService.success("Conta cadastrada!", "Sucesso!");
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      ).add(() => this.spinnerService.hide());
  }
}
