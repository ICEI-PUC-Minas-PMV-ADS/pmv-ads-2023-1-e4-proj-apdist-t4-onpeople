import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgSelectConfig } from '@ng-select/ng-select';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

import { Departamento } from 'src/app/department/models';
import { Empresa } from 'src/app/companies/models';

import { CompanyService } from 'src/app/companies/services';
import { DepartmentService } from 'src/app/department/services';

import { FormValidator, PaginatedResult } from 'src/app/shared/models';

import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-departmentDetail',
  templateUrl: './departmentDetail.component.html',
  styleUrls: ['./departmentDetail.component.scss']
})
export class DepartmentDetailComponent implements OnInit {
  public formDetail: FormGroup;

  public selectCompanyId = 0;

  public departmentParm: any = "";

  public company = {} as Empresa;
  public companies: Empresa[] = [];

  public department = {} as Departamento;
  public departments: Departamento[] = [];

  public editMode: Boolean = false;

  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public get ctrF(): any {
    return this.formDetail.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private companyService: CompanyService,
    private departmentService: DepartmentService,
    private config: NgSelectConfig,
    private formBuilder: FormBuilder,
    private localService: BsLocaleService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) {
    this.localService.use('pt-br')
      this.config.notFoundText = 'Custom not found';
      this.config.appendTo = 'body';
      this.config.bindValue = 'value';
    }

  ngOnInit() {
    this.departmentParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.departmentParm != null) ? true : false;

    this.formValidator();

    if (this.editMode)
      this.getDepartment();
    else
      this.getCompanies();
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      nomeDepartamento: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      sigla: ['', [ Validators.required, Validators.minLength(1), Validators.maxLength(20)]],
      ativo: ["true",  [ Validators.required,]],
      diretorId: [0],
      gerenteId: [0],
      supervisorId: [0],
      dataCriacao: [new Date().toString()],
      dataEncerramento: []
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

  public getDepartment(): void {
    this.spinnerService.show();

    this.departmentService
      .getDepartmentById(this.departmentParm)
      .subscribe(
        (department: Departamento) => {
          console.log("Depto Recuperado", department)
          this.department = {...department}
          this.company = department.empresa
          this.companies[0] = department.empresa
          this.selectCompanyId = this.companies[0].id
          this.formDetail.patchValue(this.department)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
          : `../../../../assets/img/${this.company.logotipo }`;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getCompanies(): void {
    this.spinnerService.show();

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result;
          console.log('Companies', companies)
          this.selectCompanyId = this.companies[0].id;
          this.changeSelectCompany();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public saveChange(): void {
    this.spinnerService.show();

    if(this.formDetail.valid)
      if (!this.editMode){
        this.createDepartment();
      }
      else {
        this.updateDepartment();
      }
  }

  public createDepartment(): void {

    this.department = { ...this.formDetail.value };
    this.department.empresaId = this.selectCompanyId;

    console.log("Create", this.department)

    this.departmentService
      .createDepartment(this.department)
      .subscribe(
        (departmentCreated: Departamento) => {
          this.toastrService.success('Departamento criado!', 'Sucesso!');
          window.location.reload;
          this.router.navigateByUrl(`/departamentos/detail/${departmentCreated.id}`);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public updateDepartment(): void {
    this.department ={ id: this.department.id, ...this.formDetail.value };
    console.log("update", this.department, "form", this.ctrF.ativo.value)

    this.departmentService
      .saveDepartment(this.department.id, this.department)
      .subscribe(
        (department: Departamento) => {
          this.toastrService.success('Departamento salvo!', 'Sucesso!');
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

  public changeSelectCompany(): void {
    this.spinnerService.show()
    console.log(this.selectCompanyId)
    var id: number = 0;

    if (this.selectCompanyId != null)
      id = this.selectCompanyId

    this.companyService
      .getCompanyById(id)
      .subscribe(
        (company: Empresa) => {
          this.company = {...company}
          console.log(this.company)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
          : `../../../../assets/img/${this.company.logotipo }`;
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.log(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
