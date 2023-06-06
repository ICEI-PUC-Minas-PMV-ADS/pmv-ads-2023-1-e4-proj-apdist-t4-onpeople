import { Component, OnInit, } from '@angular/core';

import { NgSelectConfig } from '@ng-select/ng-select';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { RandomColors } from 'src/app/shared/functions';

import { Empresa } from 'src/app/models';

import { CompanyService, DepartmentService, EmployeeService, JobRoleService } from 'src/app/services';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { DashboardCompany, DashboardDepartment, DashboardEmployee, DashboardJobRole } from 'src/app/shared/class/dashboard';

import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-dashCompany',
  templateUrl: './dashCompany.component.html',
  styleUrls: ['./dashCompany.component.scss']
})
export class DashCompanyComponent implements OnInit {
  public color: any = "";

  public totalCompany = 0;
  public totalActive = 0;
  public percTotalActive = 0;
  public totalDepartments = 0;
  public totalJobRole = 0;
  public totalEmployee = 0;
  public totalGoal = 40;
  public totalNotGoal = 25;
  public percTotalNotGoal = 25.0/40.0*100

  public dashboardCompany: DashboardCompany;
  public dashboardDepartment: DashboardDepartment;
  public dashboardJobRole: DashboardJobRole;
  public dashboardEmployee: DashboardEmployee;

  public selectCompanyId = 0;

  public companies = [] as Empresa[];

  constructor(
    public companyService: CompanyService,
    public departmentService: DepartmentService,
    public jobRoleService: JobRoleService,
    public employeeService: EmployeeService,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    private config: NgSelectConfig,
  ) {
    this.config.notFoundText = 'Custom not found';
    this.config.appendTo = 'body';
    this.config.bindValue = 'value';
}

ngOnInit() {
  this.getCompanies();
}

public getCompanies(): void {
  this.spinnerService.show();

  this.companyService
    .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
    .subscribe(
      (companies: PaginatedResult<Empresa[]>) => {
        console.log("Dash", companies);
        this.companies = companies.result
        this.selectCompanyId = this.companies[0].id;
        this.changeSelectCompany();
      },
      (error: any) => {
        this.toastrService.error(error.error, `Erro! Status ${error.status}`);
        console.error(error);
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
    .CountCompany(id)
    .subscribe(
      (returnDash: DashboardCompany) => {
        this.dashboardCompany = {...returnDash}
        console.log("conntador: ", this.dashboardCompany)
        if (this.dashboardCompany !== null) {
          console.log('countEmpresa', this.dashboardCompany.countEmpresas)
          this.totalCompany = this.dashboardCompany.countEmpresas;
          this.totalActive = this.dashboardCompany.countEmpresasAtivas;
          this.percTotalActive = +(this.dashboardCompany.countEmpresasAtivas / this.dashboardCompany.countEmpresas * 100).toFixed(2);
          this.getDashDepartment(id);
        }
      }
    )
    .add(() => this.spinnerService.hide())
}

public getDashDepartment(companyId: number, departmentId: number = 0): void {
  this.departmentService
    .CountDepartment(companyId, departmentId)
    .subscribe(
      (returnDash: DashboardDepartment) => {
        this.dashboardDepartment = {...returnDash}
        console.log("conntador: ", this.dashboardDepartment)
        if (this.dashboardDepartment !== null) {
          console.log('countEmpresa', this.dashboardDepartment.countDepartamentos)
          this.totalDepartments = this.dashboardDepartment.countDepartamentos;
          this.getDashJobRole(companyId, departmentId);
        }
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public getDashJobRole(companyId: number, departmentId: number = 0, jobRoleId: number = 0): void {
  this.jobRoleService
    .CountJobRole(companyId, departmentId, jobRoleId)
    .subscribe(
      (returnDash: DashboardJobRole) => {
        this.dashboardJobRole = {...returnDash}
        console.log("conntador: ", this.dashboardJobRole)
        if (this.dashboardJobRole !== null) {
          console.log('countCargo', this.dashboardJobRole.countCargos)
          this.totalJobRole = this.dashboardJobRole.countCargos;
          this.getDashEmployee(companyId, departmentId, jobRoleId);
        }
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public getDashEmployee(companyId: number, departmentId: number = 0, jobRoleId: number = 0, employeeId: number = 0): void {
    this.employeeService
      .countEmployee(companyId, departmentId, jobRoleId, employeeId)
      .subscribe(
        (returnDash: DashboardEmployee) => {
          this.dashboardEmployee = {...returnDash}
          console.log("conntador: ", this.dashboardEmployee)
          if (this.dashboardEmployee !== null) {
            console.log('countFuncionario', this.dashboardEmployee.countFuncionarios)
            this.totalEmployee = this.dashboardEmployee.countFuncionarios;
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public newColor(): any {
    return 'color: ' + RandomColors.colorsGenerate();
  }
}
