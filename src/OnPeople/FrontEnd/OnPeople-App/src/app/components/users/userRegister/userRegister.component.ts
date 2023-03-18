import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios/ValidadorFormularios';

import {
  faCheckDouble,
  faIdCard,
  faFileSignature,
  faKey,
  faUser,
  IconDefinition
} from '@fortawesome/free-solid-svg-icons';

import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/services/users/user/user.service';
import { Users } from 'src/app/models/users/Users';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userRegister',
  templateUrl: './userRegister.component.html',
  styleUrls: ['./userRegister.component.scss']
})
export class UserRegisterComponent implements OnInit {
  public form: FormGroup;

  public iconIdCard: IconDefinition = faIdCard;
  public iconUser: IconDefinition = faUser;
  public iconFileSignature: IconDefinition = faFileSignature;
  public iconKey: IconDefinition = faKey;
  public iconCheckDouble: IconDefinition = faCheckDouble;

  public newUser = {} as Users;

  public get ctrF(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private userService: UserService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.validarFormulario();

  }

  public validarFormulario(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidadorFormularios.compararArgumentos('password', 'confirmPassword')
    };

    this.form = this.fb.group({
      userName: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(15)]],
      nomeCompleto: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(40)]],
      password: ['', [
        Validators.required, Validators.minLength(3)]],
      confirmPassword: ['', [
        Validators.required ]],
    }, formOptions);
  }

  public validarCampo(campoForm: FormControl): any {
    return ValidadorFormularios.verificarErroCampo(campoForm);
  }

  public retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidadorFormularios.retornarMensagem(nomeCampo, nomeElemento);
  }

  public createUser(): void {
    this.spinner.show();

    this.newUser = { ...this.form.value};

    this.newUser.email = "default@default.com.br";
    this.newUser.visao = "default";
    this.newUser.dataCadastro = new Date();
    this.newUser.master = false;
    this.newUser.gold = false;
    this.newUser.bronze = false;
    this.newUser.ativa = true;
    this.newUser.codEmpresa = 0;
    this.newUser.codCargo = 0;
    this.newUser.codDepartamento = 0;
    this.newUser.codFuncionario = 0;
    this.newUser.codMeta = 0;

    console.log(this.newUser);

    this.userService
      .createUser(this.newUser)
      .subscribe(
        () => {
          this.toastr.success("Conta cadastrada!", "Sucesso!");
          window.location.reload;
          this.router.navigateByUrl('/home');
        },
        (error: any) => {
          this.toastr.error(error.error, "Erro!");
          console.error(error);
        }
      ).add(() => this.spinner.hide());
  }
}
