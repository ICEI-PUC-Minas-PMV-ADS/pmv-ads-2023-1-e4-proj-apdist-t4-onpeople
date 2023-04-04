import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/companies/models';
import { CompanyService } from 'src/app/companies/services';

import { UploadService } from 'src/app/shared/services';

import { FormValidator } from 'src/app/shared/models';

import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-companyDetail',
  templateUrl: './companyDetail.component.html',
  styleUrls: ['./companyDetail.component.scss'],
})
export class CompanyDetailComponent implements OnInit {
  public formDetail: FormGroup;

  public CNPJOk: Boolean = false;
  public CNPJExists: Boolean = false;

  public companyParam: any = "";

  public company = {} as Empresa;

  public editMode: Boolean = false;

  public logoUpload: string = 'Image_not_available.png';
  public logoURL: string = "../../../../assets/img/upload1-325x300-1.jpg";
  public file: File[];

  public get bsConfig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY h:mm:ss a',
      containerClass: 'theme-blue'
    }
  }

  public get ctrF(): any {
    return this.formDetail.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private companyService: CompanyService,
    private formBuilder: FormBuilder,
    private localService: BsLocaleService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private uploadService: UploadService,
    )
  {
    this.localService.use('pt-br')
  }

  ngOnInit() {
    this.companyParam = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.companyParam != null) ? true : false;

    if (this.editMode)
      this.CNPJOk = true;

    this.formValidator();

    if (this.editMode)
      this.getCompany();
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      cnpj: ['', [ Validators.required]],
      razaoSocial: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      nomeFantasia: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      siglaEmpresa: ['', [ Validators.required, Validators.minLength(1), Validators.maxLength(20)]],
      ativa: ['',  [ Validators.required,]],
      dataCadastro: ['', [ Validators.required]],
      dataDesativacao: [''],
      filial: ['',  [ Validators.required]],
      padraoEmail: ['',  [ Validators.required, Validators.minLength(5), Validators.maxLength(40)]],
      naturezaJuridica: [''],
      porteEmpresa: [''],
      optanteSimples: [''],
      tipoLogradouro: [''],
      logradouro: [''],
      numero: [''],
      complemento: [''],
      bairro: [''],
      cep: [''],
      ddd: [''],
      telefone: [''],
      email: [''],
      atividadePrincipal: [''],
      siglaPaisIso3: [''],
      siglaPaisIso2: [''],
      nomePais: [''],
      siglaEstado: [''],
      estado: [''],
      cidade: [''],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formDetail.reset();
  }

  public getCompany(): void {
    this.spinnerService.show();

    if (this.editMode) {
      this.companyService
        .getCompanyById(+this.companyParam)
        .subscribe(
          (company: Empresa) => {
            this.company = { ...company};
            this.formDetail.patchValue(this.company);
            this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
              ? `${environment.resourcesLogosURL}${this.company.logotipo}`
              : `../../../../assets/img/${this.company.logotipo }`;
            this.ctrF.dataCadastro.setValue(this.company.dataCadastro);
          },
          (error: any) => {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        )
        .add(() => this.spinnerService.hide());
    }
  }

  public saveChange(): void {
    this.spinnerService.show();

    if(this.formDetail.valid)
      if (!this.editMode){
        this.createCompany();
      }
      else {
        this.updateCompany();
      }
  }

  public createCompany(): void {

    this.company = { logotipo: this.logoUpload, ...this.formDetail.value };

    this.companyService
      .createCompany(this.company)
      .subscribe(
        (companyCreated: Empresa) => {
          this.toastrService.success('Empresa criada!', 'Sucesso!');
          window.location.reload;
          this.router.navigateByUrl(`/empresas/detail/${companyCreated.id}`);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public updateCompany(): void {
    this.company ={ id: this.company.id, logotipo: this.company.logotipo, ...this.formDetail.value };

    this.companyService
      .saveCompany(this.company.id, this.company)
      .subscribe(
        (company: Empresa) => {
          this.toastrService.success('Empresa salva!', 'Sucesso!');
        },
        (error: any) => {
          if (error.status == 401)
          this.toastrService.error("Usuário não autorizado.", `Erro! Status ${error.status}` )
          else {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public toggleImage(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.logoUpload = event.target.result;

    this.file = ev.target.files;

    reader.readAsDataURL(this.file[0]);

    this.uploadImage();
  }

  public uploadImage(): void {
    this.spinnerService.show();

    this.uploadService
      .saveLogoCompany(+this.companyParam, this.file)
      .subscribe(
        () => {
          this.toastrService.success("Logo atualizada!", "Sucesso!"),
          this.getCompany();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getCompanyByCnpj(): void {
    this.spinnerService.show();

    if (!this.editMode)
      this.companyService
      .getCompanyByCnpj(this.ctrF.cnpj.value)
      .subscribe(
        (company: Empresa) => {
          if (company != null) {
            this.toastrService.error("Cnpj já cadastrado em seu sistema.")
            this.CNPJOk = false;
            this.CNPJExists = true;
          } else {
            this.CNPJExists = false;
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());

    this.companyService
      .getCompanyByCnpjExternal(this.ctrF.cnpj.value)
      .subscribe(
        (company: Empresa) => {
          if (company != null) {
            this.company = company;
            if (this.company.nomeFantasia == null) {
              this.company.nomeFantasia = this.company.razaoSocial
            }
            this.formDetail.patchValue(this.company);
            this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
              ? `${environment.resourcesLogosURL}${this.company.logotipo}`
              : `../../../../assets/img/${this.company.logotipo }`;

            if (!this.CNPJExists)
              this.CNPJOk = true;
          }

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
