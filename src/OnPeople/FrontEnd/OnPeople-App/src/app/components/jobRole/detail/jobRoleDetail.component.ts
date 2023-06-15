import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

import { Cargo, Departamento, Empresa } from 'src/app/models';

import { CompanyService, DepartmentService, JobRoleService } from 'src/app/services';

import { environment } from 'src/assets/environments';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { FormValidator } from 'src/app/shared/class/validators';

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
    private departmentService: DepartmentService,
    private formBuilder: FormBuilder,
    private jobRoleService: JobRoleService,
    private localService: BsLocaleService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) {
      this.localService.use('pt-br');
    }

  ngOnInit() {
    this.jobRoleParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.jobRoleParm != null) ? true : false;

    this.formValidator();

    if (this.editMode)
      this.getJobRole();
    else {
      this.getCompanies();
    }
  }

  public formValidator(): void {
    this.formDetail = this.formBuilder.group({
      selectCompanyId: [0, Validators.required],
      selectDepartmentId: [0, Validators.required],
      cnpj: [''],
      sigla: [''],
      nomeCargo: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      ativo: [true,  [ Validators.required,]],
      dataCriacao: [new Date().toString()],
      dataEncerramento: []
    });
  }

  public changeSelectCompany(): void {
    this.spinnerService.show()
    var id: number = 0;

    if (this.selectCompanyId != null)
      id = this.selectCompanyId

    this.companyService
      .getCompanyById(id)
      .subscribe(
        (company: Empresa) => {
          this.company = company
          this.departments = company.departamentos
          this.selectDepartmentId = this.departments[0].id
          this.formDetail.patchValue(this.company)
          this.formDetail.patchValue(this.departments[0])
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public changeSelectDepartment(): void {
    this.spinnerService.show()

    this.departmentService
      .getDepartmentById(this.selectDepartmentId)
      .subscribe(
        (department: Departamento) => {
          this.department = department
          this.formDetail.patchValue(this.department)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
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
          this.company = this.companies[0];
          this.selectCompanyId = this.company.id;
          this.selectDepartmentId = this.company.departamentos[0].id;
          this.formDetail.patchValue(this.companies[0]);
          this.logoURL = (this.companies[0].logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.companies[0].logotipo}`
            : `../../../../assets/img/${this.companies[0].logotipo}`;
          this.getDepartmentsByCompanyId();
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
          this.department = this.departments[0];

          if (this.departments.length == 0) {
            this.ctrF.set.nomeCargo.value = null;
            this.ctrF.sigla.set.value = null;
          } else {
            this.formDetail.patchValue(this.department);
            this.selectDepartmentId = this.department.id;
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
    this.jobRole = { ...this.formDetail.value };
    this.jobRole.empresaId = this.selectCompanyId;
    this.jobRole.departamentoId = this.selectDepartmentId;

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
          this.department = jobRole.departamento
          this.departments[0] = jobRole.departamento
          this.company = jobRole.empresa
          this.companies[0] = jobRole.empresa
          this.selectCompanyId = this.companies[0].id
          this.selectDepartmentId = this.departments[0].id
          this.formDetail.patchValue(this.jobRole)
          this.formDetail.patchValue(this.company)
          this.formDetail.patchValue(this.department)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }
}


