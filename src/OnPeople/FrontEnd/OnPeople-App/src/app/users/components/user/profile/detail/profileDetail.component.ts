import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Users } from 'src/app/users/models';
import { UserService } from 'src/app/users/services';

import { Empresa } from 'src/app/companies/models';
import { CompanyService } from 'src/app/companies/services';


import { FormValidator } from 'src/app/shared/models';

@Component({
  selector: 'app-profileDetalhe',
  templateUrl: './profileDetail.component.html',
  styleUrls: ['./profileDetail.component.scss']
})
export class ProfileDetailComponent implements OnInit {
  public formDetail: FormGroup;

  @Output() changeFormValue = new EventEmitter();

  public users = {} as Users;


  public selectValueVisao : string;

  public get ctrF(): any {
    return this.formDetail.controls;
  }

  constructor(
    public companyService: CompanyService,
    public formBuilder: FormBuilder,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    public userService: UserService,
  ) { }

  ngOnInit() {
    this.getUserLoged();
    this.formValidator();
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      nomeEmpresa: [''],
      userName: ['', [ Validators.required]],
      nomeCompleto: ['', [ Validators.required]],
      email: ['', [ Validators.required]],
      phoneNumber: ['', [ Validators.required]],
      visao: ['', [ Validators.required]],
      ativa: ['', [ Validators.required]],
      dataCadastro: ['', [ Validators.required]],
    })

    this.formDetail.valueChanges.subscribe(() => this.changeFormValue.emit({... this.formDetail.value}));
   }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public getUserLoged(): void {
    this.spinnerService.show();

    this.userService
      .getUserByUserName()
      .subscribe(
        (users: Users) => {
          this.users = { ... users}
          this.formDetail.patchValue(this.users);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getCompanyBuId(id: number): void {
    this.spinnerService.show();

    this.companyService
      .getCompanyById(id)
      .subscribe(
        (empresa: Empresa) => {
          if (empresa != null) {
            this.users.nomeEmpresa = empresa.razaoSocial;
            this.formDetail.patchValue(this.users)
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
    if (this.formDetail.valid) {
      this.spinnerService.show();
    }
  }
}
