import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';

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

  public spinnerShow: boolean = false;

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
    private router: Router,
    private toastrService: ToastrService,
  ) { }

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
    this.spinnerShow = true;
    var id: number = 0;

    if (this.ctrF.selectCompanyId.value != null)
      id = this.ctrF.selectCompanyId.value

    this.companyService
      .getCompanyById(id)
      .subscribe(
        (company: Empresa) => {
          this.company = company
          this.departments = company.departamentos
          this.ctrF.selectCompanyId.setValue(this.company.id)
          this.ctrF.selectDepartmentId.setValue(this.departments[0].id)
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
      .add(() => this.spinnerShow = false);
  }

  public changeSelectDepartment(): void {
    this.spinnerShow = true;

    this.departmentService
      .getDepartmentById(this.ctrF.selectCompanyId.value)
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
      .add(() => this.spinnerShow = false);
  }

  public getCompanies(): void {
    this.spinnerShow = true;;

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result.filter(c => c.departamentos.length > 0);
          this.company = this.companies[0];
          this.ctrF.selectCompanyId.setValue(this.company.id)
          this.formDetail.patchValue(this.company)
          this.logoURL = (this.companies[0].logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.companies[0].logotipo}`
            : `../../../../assets/img/${this.companies[0].logotipo}`;
          this.getDepartmentsByCompanyId();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getDepartmentsByCompanyId(): void {
    this.spinnerShow = true;;

    this.departmentService
      .getDepartmentsByCompanyId(this.ctrF.selectCompanyId.value)
      .subscribe(
        (departments: Departamento[]) => {
          this.departments = departments;
          this.department = this.departments[0];

          if (this.departments.length == 0) {
            this.ctrF.nomeCargo.setValue(null);
            this.ctrF.sigla.setValue(null);
          } else {
            this.formDetail.patchValue(this.department);
            this.ctrF.selectCompanyId.setValue(this.department.id);
            this.ctrF.selectDepartmentId.setValue(this.department.id)
          }
        },
       (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
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
    this.spinnerShow = true;;

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
    this.jobRole.empresaId = this.ctrF.selectCompanyId.value;
    this.jobRole.departamentoId = this.ctrF.selectCompanyId.value;

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
      .add(() => this.spinnerShow = false)
  }

  public updateJobRole(): void {
    this.jobRole = { id: this.jobRole.id, ...this.formDetail.value };
    this.jobRole.empresaId = this.ctrF.selectCompanyId.value;
    this.jobRole.departamentoId = this.ctrF.selectCompanyId.value;

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
      .add(() => this.spinnerShow = false)
  }

  public getJobRole(): void {
    this.spinnerShow = true;;

    this.jobRoleService
      .getJobRoleById(this.jobRoleParm)
      .subscribe(
        (jobRole: Cargo) => {
          this.jobRole = jobRole;
          this.department = jobRole.departamento
          this.departments[0] = jobRole.departamento
          this.company = jobRole.empresa
          this.companies[0] = jobRole.empresa
          this.formDetail.patchValue(this.jobRole)
          this.formDetail.patchValue(this.company)
          this.formDetail.patchValue(this.department)
          this.ctrF.selectCompanyId.setValue(this.company.id)
          this.ctrF.selectDepartmentId.setValue(this.department.id)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }
}


