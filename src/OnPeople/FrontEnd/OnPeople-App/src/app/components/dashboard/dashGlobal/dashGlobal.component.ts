import { Component, OnInit, } from '@angular/core';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { RandomColors } from 'src/app/shared/functions';

import { Cargo, Departamento, Empresa, Funcionario, FuncionarioMeta, Meta } from 'src/app/models';

import {
  CompanyService,
  DepartmentService,
  EmployeeGoalAssociateService,
  EmployeeService,
  GoalService,
  JobRoleService
} from 'src/app/services';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import {
  DashboardCompany,
  DashboardDepartment,
  DashboardEmployee,
  DashboardEmployeeGoal,
  DashboardGoal,
  DashboardJobRole
} from 'src/app/shared/class/dashboard';

import { environment } from 'src/assets/environments';


@Component({
  selector: 'app-dashGlobal',
  templateUrl: './dashGlobal.component.html',
  styleUrls: ['./dashGlobal.component.scss']
})
export class DashGlobalComponent implements OnInit {
  public spinnerShow: boolean = false;

  public color: any = "";

  public totCompany = 0;
  public totSubsidiary = 0;
  public totDepartment = 0;
  public totJobRole = 0;
  public totEmployee = 0;
  public totGoal = 0;
  public totAssociateGoal = 0;

  public totActiveCompany = 0;
  public totActiveSubsidiary = 0;
  public totActiveDepartment = 0;
  public totActiveJobRole = 0;

  public totMetGoal = 0;
  public totMetAssociateGoal = 0;

  public totApprovedGoal = 0;

  public totPercActiveCompany = 0.0;
  public totPercSubsidiary = 0.0;
  public totPercActiveSubsidiary1 = 0.0;
  public totPercActiveSubsidiary2 = 0.0;
  public totPercActiveDepartment = 0.0;
  public totPercActiveJobRole = 0.0;
  public totPercApprovedGoal = 0.0;
  public totPercMetGoal = 0.0;
  public totPercMetAssociateGoal = 0.0;

  public dashboardCompany: DashboardCompany;
  public dashboardDepartment: DashboardDepartment;
  public dashboardEmployee: DashboardEmployee;
  public dashboardEmployeeGoal: DashboardEmployeeGoal;
  public dashboardGoal: DashboardGoal;
  public dashboardJobRole: DashboardJobRole;

  public selectCompanyId = 0;
  public selectDepartmentId = 0;
  public selectJobRoleId = 0;
  public selectEmployeeId = 0;
  public selectGoalId = 0;
  public selectAssociatedGoalId = 0;

  public companies = [] as Empresa[];
  public departments = [] as Departamento[];
  public jobRoles = [] as Cargo[];
  public employees = [] as Funcionario[];
  public goals = [] as Meta[];
  public employeeGoals = [] as FuncionarioMeta[];

  constructor(
    private companyService: CompanyService,
    private departmentService: DepartmentService,
    private employeeService: EmployeeService,
    private employeeGoalAssociateService: EmployeeGoalAssociateService,
    private goalService: GoalService,
    private jobRoleService: JobRoleService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.getCompanies();
  }

  public getCompanies(): void {
    this.spinnerShow = true;;

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result

          if (this.companies.length == 0) {
            this.selectCompanyId = 0
            this.dashboardCompany.countEmpresas = 0;
            this.dashboardCompany.countEmpresasAtivas = 0
            this.dashboardCompany.countFiliais = 0
            this.dashboardCompany.countFiliaisAtivas = 0
          } else {

            this.selectCompanyId = this.companies[0].id;
          }

          this.changeSelectCompany();

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
        )
        .add(() => this.spinnerShow = false)
  }

  public changeSelectCompany(): void {
    this.spinnerShow = true;

    this.companyService
      .getDashCompany(this.selectCompanyId)
      .subscribe(
        (returnDash: DashboardCompany) => {
          this.dashboardCompany = returnDash;
          console.log("dashCompany ", this.dashboardCompany)
          if (this.dashboardCompany !== null) {
            this.totCompany = this.dashboardCompany.countEmpresas;
            this.totActiveCompany = this.dashboardCompany.countEmpresasAtivas;
            this.totPercActiveCompany = +(this.dashboardCompany.percentualEmpresasAtivas).toFixed(2)
            this.totSubsidiary = this.dashboardCompany.countFiliais;
            this.totPercSubsidiary = +(this.dashboardCompany.percentualFiliais).toFixed(2)
            this.totActiveSubsidiary = this.dashboardCompany.countFiliaisAtivas;
            this.totPercActiveSubsidiary1 = +(this.dashboardCompany.percentualFiliaisAtivas).toFixed(2)
            this.totPercActiveSubsidiary2 = +(this.dashboardCompany.percentualFiliaisAtivas2).toFixed(2)

            this.getDepartments(this.selectCompanyId);
//            this.getGoals(this.selectCompanyId);
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public getDepartments(companyId: number): void {
    this.spinnerShow = true;

    this.departmentService
      .getDepartmentsByCompanyId(companyId)
      .subscribe(
        (departments: Departamento[]) => {
          this.departments = departments

          if (this.departments.length == 0) {
            this.selectDepartmentId = 0
            this.dashboardDepartment.countDepartamentos = 0
            this.dashboardDepartment.countDepartamentosAtivos = 0
          } else {

            this.selectDepartmentId = this.departments[0].id;
          }

          this.changeSelectDepartment()

      }
    )
    .add(() => this.spinnerShow = false)
  }

  public changeSelectDepartment(): void {
    this.spinnerShow = true;

    this.departmentService
      .getDashDepartment (this.selectCompanyId, this.selectDepartmentId)
      .subscribe(
        (returnDash: DashboardDepartment) => {
          this.dashboardDepartment = returnDash;
          console.log("dashDepartment ", this.dashboardDepartment)
          if (this.dashboardDepartment !== null) {
            this.totDepartment = this.dashboardDepartment.countDepartamentos;
            this.totActiveDepartment = this.dashboardDepartment.countDepartamentosAtivos;
            this.totPercActiveDepartment = +(this.dashboardDepartment.percentualDepartamentosAtivos).toFixed(2)

            this.getJobRoles(this.selectDepartmentId);
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public getJobRoles(departmentId: number): void {
    this.spinnerShow = true;

    this.jobRoleService
      .getJobRoleByDepartmentId(departmentId)
      .subscribe(
        (jobRoles: Cargo[]) => {
          this.jobRoles = jobRoles

          if (this.jobRoles.length == 0) {
            this.selectJobRoleId = 0
            this.dashboardJobRole.countCargos = 0
            this.dashboardJobRole.countCargosAtivos = 0
          } else {

            this.selectJobRoleId = this.jobRoles[0].id;
          }
          this.changeSelectJobRole()
      }
    )
    .add(() => this.spinnerShow = false)
  }

  public changeSelectJobRole(): void {
    this.spinnerShow = true;

    this.jobRoleService
      .getDashJobRole(this.selectCompanyId, this.selectDepartmentId, this.selectJobRoleId)
      .subscribe(
        (returnDash: DashboardJobRole) => {
          this.dashboardJobRole = returnDash;
          console.log("dashJobRole", this.dashboardJobRole)
          if (this.dashboardJobRole !== null) {
            this.totJobRole = this.dashboardJobRole.countCargos;
            this.totActiveJobRole = this.dashboardJobRole.countCargosAtivos;
            this.totPercActiveJobRole = this.dashboardJobRole.percentualCargosAtvios;

            this.getEmployees(this.selectJobRoleId);
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public getEmployees(jobRoleId: number): void {
      this.employeeService
      .getEmployeesByJobRoleId(jobRoleId)
      .subscribe(
        (employees: Funcionario[]) => {
          this.employees = employees

          if (this.employees.length == 0) {
            this.selectEmployeeId = 0

          } else {

            this.selectEmployeeId = this.employees[0].id;
          }
            this.changeSelectEmployee()
      }
    )
    .add(() => this.spinnerShow = false)
  }

  public changeSelectEmployee(): void {
    this.employeeService
      .getDashEmployee(this.selectCompanyId, this.selectDepartmentId, this.selectJobRoleId, this.selectEmployeeId)
      .subscribe(
        (returnDash: DashboardEmployee) => {
          this.dashboardEmployee = returnDash;
          console.log("dashboardEmployee", this.dashboardEmployee)
          if (this.dashboardEmployee !== null) {
            this.totEmployee = this.dashboardEmployee.countFuncionarios;

            this.getEmployeesGoals(this.selectEmployeeId)
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }
/*
  public getGoals(companyId: number): void {
    this.goalService
      .getGoalByCompanyId(companyId)
      .subscribe(
        (goals: Meta[]) => {
          this.goals = goals

          if (this.goals.length == 0) {
            this.selectGoalId = 0


          } else {

            this.selectGoalId = this.goals[0].id;
          }
            this.changeSelectGoal()
      }
    )
    .add(() => this.spinnerShow = false)
  }

  public changeSelectGoal(): void {
    this.employeeService
      .getDashGoal(this.selectCompanyId, this.selectDepartmentId, this.selectJobRoleId, this.selectEmployeeId)
      .subscribe(
        (returnDash: DashboardGoal) => {
          this.dashboardGoal = returnDash;
          if (this.dashboardGoal !== null) {
            this.totAssociateGoal = this.dashboardGoal.countMetas;
            this.totMetAssociateGoal = this.dashboardGoal.countMetasCumpridas;
            this.totPercMetAssociateGoal = +(this.dashboardGoal.PercentualMetasCumpridas).toFixed(2)
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }
*/
    public getEmployeesGoals(employeeId: number): void {
    this.employeeGoalAssociateService
      .getGoalsByEmployeeId(employeeId)
      .subscribe(
        (employeeGoals: FuncionarioMeta[]) => {
          this.employeeGoals = employeeGoals
          console.log(employeeGoals)
          if (this.employeeGoals.length == 0) {
            this.selectAssociatedGoalId = 0;
            this.dashboardEmployeeGoal.countMetasAssociadas = 0;
            this.dashboardEmployeeGoal.countMetasCumpridas = 0;

          } else {

            this.selectAssociatedGoalId = this.employeeGoals[0].metaId;
          }
            this.changeSelectEmployeeGoal()
      }
    )
    .add(() => this.spinnerShow = false)
  }

  public changeSelectEmployeeGoal(): void {
    this.employeeService
      .getDashGoal(this.selectCompanyId, this.selectDepartmentId, this.selectJobRoleId, this.selectEmployeeId)
      .subscribe(
        (returnDash: DashboardEmployeeGoal) => {
          this.dashboardEmployeeGoal = returnDash;
          console.log("dashboardEmployeeGoal", this.dashboardEmployeeGoal)
          if (this.dashboardEmployeeGoal !== null) {
            this.totAssociateGoal = this.dashboardEmployeeGoal.countMetasAssociadas;
            this.totMetAssociateGoal = this.dashboardEmployeeGoal.countMetasCumpridas;
            this.totPercMetAssociateGoal = +(this.dashboardEmployeeGoal.percentualMetasCumpridas).toFixed(2);
          }
        }
      )
      .add(() => this.spinnerShow = false)
  }
  public newColor(): any {
    return 'color: ' + RandomColors.colorsGenerate();
  }
}
