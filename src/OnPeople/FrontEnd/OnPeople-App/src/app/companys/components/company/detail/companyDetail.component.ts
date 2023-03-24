import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/companys/models';
import { CompanyService } from 'src/app/companys/services';

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

  public saveState: string = 'post';
  public editMode: Boolean = false;

  public logoUpload: string = 'Image_not_available.png';
  public logoURL: string = "../../../../assets/img/upload1-325x300-1.jpg";
  public file: File[];

  public company: Empresa;
  public companyFilter: Empresa[] = [];
  public companyPattern: Boolean = false;
  public companyPatternId: number = 0;
  public patternName: string = "";
  public companyActive: Boolean = false;

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
    this.formValidator();
    this.getCompany();
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      nomeEmpresa: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      nomeFantasia: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      sigla: ['', [ Validators.required, Validators.minLength(3), Validators.maxLength(7)]],
      dataCadastro: ['', [ Validators.required]],
      dataDesativacao: [''],
      padraoEmail: ['',  [ Validators.required, , Validators.minLength(5), Validators.maxLength(25)]]
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

    const companyIdParm = this.activevateRouter.snapshot.paramMap.get('id');

    this.verificarcompanyMPattern();

    if (companyIdParm !== null) {
      this.saveState = 'put'
      this.editMode = true;

      this.companyService
        .getCompanyById(+companyIdParm)
        .subscribe(
          (company: Empresa) => {
            this.company = { ...company};
            this.formDetail.patchValue(this.company);
            this.company.logotipo = company.logotipo;
            this.companyActive = company.ativa
            this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
              ? `${environment.resourcesLogosURL}${this.company.logotipo}`
              : `../../../../assets/img/${this.company.logotipo }`;
          },
          (error: any) => {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        )
        .add(() => this.spinnerService.hide());
    }
  }

  public verificarcompanyMPattern(): void {
    this.spinnerService.show();

    this.companyService
      .getCompanyPattern()
      .subscribe(
        (company: Empresa) => {
          if (company == null) {
            this.companyPattern = true;
          } else {
            console.log("Filial ", company.filial)
            this.companyPattern = false;
            this.patternName = company.nomeEmpresa;
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public saveChange(): void {
    this.spinnerService.show();

    if (this.company)
      this.logoUpload = this.company.logotipo;

    if(this.formDetail.valid) {
      this.company = (this.saveState == 'post')
      ? { ...this.formDetail.value }
      : {id: this.company.id, ...this.formDetail.value };
    }

    this.company.logotipo = this.logoUpload;
    this.company.filial = !this.companyPattern;
    this.company.matrizId = this.companyPatternId
    this.company.ativa = this.companyActive;

    if(this.saveState == 'post') {
      this.company.logotipo = 'Image_not_available.png';

      this.companyService
          .createCompany(this.company)
          .subscribe(
            (company: Empresa) => {
              this.toastrService.success('Empresa criada!', 'Sucesso!');
              window.location.reload;
              this.router.navigateByUrl(`/company/detail/${company.id}`);
              this.saveState = 'put';
            },
            (error: any) => {
              this.toastrService.error(error.error, `Erro! Status ${error.status}`);
              console.error(error);
            }
          )
          .add(() => this.spinnerService.hide())
    } else {
      console.log("salvar empresa", this.company)
      this.companyService
      .saveCompany(this.company.id, this.company)
      .subscribe(
        (company: Empresa) => {
          this.toastrService.success('Empresa salva!', 'Sucesso!');
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
    }
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

    const companyIdParm: number = Number(this.activevateRouter.snapshot.paramMap.get('id'));

    this.uploadService
      .saveLogoCompany(companyIdParm, this.file)
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
}
