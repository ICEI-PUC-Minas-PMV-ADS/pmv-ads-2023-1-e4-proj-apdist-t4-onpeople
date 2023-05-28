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
import { Cargo } from 'src/app/jobRoles/models/Cargo';
import { JobRoleService } from 'src/app/jobRoles/services';

@Component({
  selector: 'app-jobRoleDetail',
  templateUrl: './jobRoleDetail.component.html',
  styleUrls: ['./jobRoleDetail.component.scss']
})
export class JobRoleDetailComponent implements OnInit {
  public formDetail: FormGroup;

  public selectCompanyId = 0;
  public selectDepartmentId = 0;

  public jobRoleParm: any = "";

  public company = {} as Empresa;
  public companies: Empresa[] = [];

  public department = {} as Departamento;
  public departments: Departamento[] = [];

  public jobRole = {} as Cargo;

  public editMode: Boolean = false;

  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public get ctrF(): any {
    return this.formDetail.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private companyService: CompanyService,
    private config: NgSelectConfig,
    private departmentService: DepartmentService,
    private formBuilder: FormBuilder,
    private jobRoleService: JobRoleService,
    private localService: BsLocaleService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,) {
      this.localService.use('pt-br');
      this.config.notFoundText = 'Custom not found';
      this.config.appendTo = 'body';
      this.config.bindValue = 'value';
    }

  ngOnInit() {
    this.jobRoleParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.jobRoleParm != null) ? true : false;

    this.formValidator();

    if (this.editMode)
      this.getJobRole();
    else {
      this.getCompanies();
      this.getDepartments();
    }
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      selectCompanyId: [0, Validators.required],
      selectDepartmentId: [0, Validators.required],
      cnpj: [''],
      sigla: [''],
      nomeCargo: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      ativo: ["true",  [ Validators.required,]],
      dataCriacao: [new Date().toString()],
      dataEncerramento: []
    });
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
          this.company = { ...company }
          this.formDetail.patchValue(this.company)
          console.log("changeSelectCompany", this.company)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
          this.getDepartmentsByCompanyId();
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.log(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public changeSelectDepartment(): void {
    this.spinnerService.show()
    var id: number = 0;

    if (this.selectDepartmentId != null)
      id = this.selectDepartmentId

    console.log("selectDepartmentId",this.selectDepartmentId, id, this.selectCompanyId)
    this.departmentService
      .getDepartmentById(id)
      .subscribe(
        (department: Departamento) => {
          this.department = { ...department }
          this.formDetail.patchValue(this.department)
          console.log("changeSelectDepartment", this.department)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.log(error)
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
          this.companies = companies.result.filter(c => c.departamentos.length > 0);
          console.log('Companies', this.companies)
          this.selectCompanyId = this.companies[0].id;
          this.formDetail.patchValue(this.companies[0]);
          this.changeSelectCompany();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getDepartments(): void {
    this.spinnerService.show();

    this.departmentService
      .getDepartments(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (departments: PaginatedResult<Departamento[]>) => {
          this.departments = departments.result;
          this.selectDepartmentId = this.departments[0].id
          console.log('departments', this.departments)
          this.changeSelectDepartment();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
    }

  public getDepartmentsByCompanyId(): void {
    this.spinnerService.show();

    this.departmentService
      .getDepartmentsByCompanyId(this.selectCompanyId)
      .subscribe(
        (departments: Departamento[]) => {
          this.departments = departments;
          console.log('Departments Id', departments);
          if (this.departments.length == 0) {
            console.log("null")
            this.ctrF.set.nomeCargo.value = null;
            this.ctrF.sigla.set.value = null;
          } else {
            console.log("not null")
            this.formDetail.patchValue(this.departments[0]);
            this.selectDepartmentId = this.departments[0].id;
            this.changeSelectDepartment();
          }
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
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

  public saveChange(): void {
    this.spinnerService.show();

    if(this.formDetail.valid)
      if (!this.editMode){
        this.createJobRole();
      }
      else {
        this.updateJobRole();
      }
  }

  public createJobRole(): void {
    console.log("Create", this.jobRole)
    this.jobRole = { ...this.formDetail.value };
    this.jobRole.empresaId = this.selectCompanyId;
    this.jobRole.departamentoId = this.selectDepartmentId;

    console.log("Create", this.jobRole)

    this.jobRoleService
      .createJobRole(this.jobRole)
      .subscribe(
        (jobRoleCreated: Cargo) => {
          this.toastrService.success('Cargo criado!', 'Sucesso!');
          window.location.reload;
          this.router.navigateByUrl(`/cargos/detail/${jobRoleCreated.id}`);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public updateJobRole(): void {
    this.jobRole = { id: this.jobRole.id, ...this.formDetail.value };
    this.jobRole.empresaId = this.selectCompanyId;
    this.jobRole.departamentoId = this.selectDepartmentId;
    console.log("update", this.jobRole, "form", this.ctrF.ativo.value)

    this.jobRoleService
      .saveJobRole(this.jobRole.id, this.jobRole)
      .subscribe(
        (jobRole: Cargo) => {
          this.toastrService.success('Cargo salvo!', 'Sucesso!');
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

  public getJobRole(): void {
    this.spinnerService.show();

    this.jobRoleService
      .getJobRoleById(this.jobRoleParm)
      .subscribe(
        (jobRole: Cargo) => {
          this.jobRole = { ...jobRole }
          console.log("Carog Recuperado", jobRole)
          this.department = jobRole.departamento
          this.company = jobRole.empresa
          this.companies[0] = jobRole.empresa
          this.departments[0] = jobRole.departamento
          this.selectCompanyId = this.companies[0].id
          this.selectDepartmentId = this.departments[0].id
          this.formDetail.patchValue(this.jobRole)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
          this.changeSelectCompany();
          this.changeSelectDepartment();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }
}


