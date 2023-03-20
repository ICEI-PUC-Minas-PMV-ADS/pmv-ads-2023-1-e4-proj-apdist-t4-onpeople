import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios/ValidadorFormularios';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { Users } from 'src/app/models/users/Users';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';
import { UserService } from 'src/app/services/users/user/user.service';

@Component({
  selector: 'app-userProfileDetalhe',
  templateUrl: './userProfileDetalhe.component.html',
  styleUrls: ['./userProfileDetalhe.component.scss']
})
export class UserProfileDetalheComponent implements OnInit {

  @Output() changeFormValue = new EventEmitter();

  public users = {} as Users;

  public form: FormGroup;

  public selectValueVisao : string;

  public get ctrF(): any {
    return this.form.controls;
  }

  constructor(
    public empresaService: EmpresasService,
    public formBuilder: FormBuilder,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    public userService: UserService,
  ) { }

  ngOnInit() {
    this.carregarUserLoged();
    this.validarFormulario();
  }

  public validarFormulario(): void {
    this.form = this.formBuilder.group({
      nomeEmpresa: [''],
      userName: ['', [ Validators.required]],
      nomeCompleto: ['', [ Validators.required]],
      email: ['', [ Validators.required]],
      phoneNumber: ['', [ Validators.required]],
      visao: ['', [ Validators.required]],
      ativa: ['', [ Validators.required]],
      dataCadastro: ['', [ Validators.required]],
    })

    this.form.valueChanges.subscribe(() => this.changeFormValue.emit({... this.form.value}));
    console.log("nomeEmpresa: ", this.form.get('nomeCompleto')?.value)
  }

  public validarCampo(campoForm: FormControl): any {
    return ValidadorFormularios.verificarErroCampo(campoForm);
  }

  public retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidadorFormularios.retornarMensagem(nomeCampo, nomeElemento);
  }

  public carregarUserLoged(): void {
    this.spinnerService.show();

    this.userService
      .getUserByUserName()
      .subscribe(
        (users: Users) => {
          this.users = { ... users}
          this.form.patchValue(this.users);
          console.log("Conta :", users)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.log(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public buscarEmpresaPorId(id: number): void {
    this.spinnerService.show();

    this.empresaService
      .getEmpresaById(id)
      .subscribe(
        (empresa: Empresa) => {
          if (empresa != null) {
            this.users.nomeEmpresa = empresa.nomeEmpresa;
            this.form.patchValue(this.users)
          }
        },
        (error: any) => {
          console.error(error);
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public onSubmit(): void {
    console.log("aqui")
    if (this.form.valid) {
      this.spinnerService.show();

      console.log(this.form.value)
    }
  }
}
