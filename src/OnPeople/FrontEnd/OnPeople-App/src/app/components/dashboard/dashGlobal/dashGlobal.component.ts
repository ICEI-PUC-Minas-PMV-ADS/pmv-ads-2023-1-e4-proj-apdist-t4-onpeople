import { Component, OnInit, } from '@angular/core';

import { NgSelectConfig } from '@ng-select/ng-select';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { RandomColors } from 'src/app/shared/functions';

import { Cargo, Departamento, Empresa, Funcionario, FuncionarioMeta, Meta } from 'src/app/models';

import { CompanyService, DepartmentService, EmployeeGoalAssociateService, EmployeeService, GoalService, JobRoleService } from 'src/app/services';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { DashboardCompany, DashboardDepartment, DashboardEmployee, DashboardGoal, DashboardJobRole} from 'src/app/shared/class/dashboard';

import { environment } from 'src/assets/environments';
import { DashboardEmployeeGoal } from 'src/app/shared/class/dashboard/DashboardEmployeeGoal';

@Component({
  selector: 'app-dashGlobal',
  templateUrl: './dashGlobal.component.html',
  styleUrls: ['./dashGlobal.component.scss']
})
export class DashGlobalComponent implements OnInit {
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
    private config: NgSelectConfig,
    private departmentService: DepartmentService,
    private employeeService: EmployeeService,
    private employeeGoalAssociateService: EmployeeGoalAssociateService,
    private goalService: GoalService,
    private jobRoleService: JobRoleService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
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
        .add(() => this.spinnerService.hide())
  }

  public changeSelectCompany(): void {
    this.spinnerService.show()

    this.companyService
      .CountCompany(this.selectCompanyId)
      .subscribe(
        (returnDash: DashboardCompany) => {
          this.dashboardCompany = returnDash;
          if (this.dashboardCompany !== null) {
            this.totCompany = this.dashboardCompany.countEmpresas;
            this.totActiveCompany = this.dashboardCompany.countEmpresasAtivas;
            this.totPercActiveCompany = +(this.totActiveCompany / this.totCompany * 100).toFixed(2)
            this.totSubsidiary = this.dashboardCompany.countFiliais;
            this.totPercSubsidiary = +(this.totSubsidiary / this.totCompany * 100).toFixed(2)
            this.totActiveSubsidiary = this.dashboardCompany.countFiliaisAtivas;
            this.totPercActiveSubsidiary1 = +(this.totActiveSubsidiary / this.totCompany * 100).toFixed(2)
            this.totPercActiveSubsidiary2 = +(this.totActiveSubsidiary / this.totSubsidiary * 100).toFixed(2)

            this.getDepartments(this.selectCompanyId);
            this.getGoals(this.selectCompanyId);
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public getDepartments(companyId: number): void {
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
    .add(() => this.spinnerService.hide())
  }

  public changeSelectDepartment(): void {
    this.spinnerService.show()

    this.departmentService
      .CountDepartment(this.selectCompanyId)
      .subscribe(
        (returnDash: DashboardDepartment) => {
          this.dashboardDepartment = returnDash;
          if (this.dashboardDepartment !== null) {
            this.totDepartment = this.dashboardDepartment.countDepartamentos;
            this.totActiveDepartment = this.dashboardDepartment.countDepartamentosAtivos;
            this.totPercActiveDepartment = +(this.totActiveDepartment / this.totDepartment * 100).toFixed(2)

            this.getJobRoles(this.selectDepartmentId);
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public getJobRoles(departmentId: number): void {
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
    .add(() => this.spinnerService.hide())
  }

  public changeSelectJobRole(): void {
    this.jobRoleService
      .CountJobRole(this.selectDepartmentId)
      .subscribe(
        (returnDash: DashboardJobRole) => {
          this.dashboardJobRole = returnDash;
          if (this.dashboardJobRole !== null) {
            this.totJobRole = this.dashboardJobRole.countCargos;
            this.totActiveJobRole = this.dashboardJobRole.countCargosAtivos;
            this.totPercActiveJobRole = +(this.totActiveJobRole / this.totJobRole * 100).toFixed(2)

            this.getEmployees(this.selectJobRoleId);
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public getEmployees(jobRoleId: number): void {
      this.employeeService
      .getEmployeesByJobRoleId(jobRoleId)
      .subscribe(
        (employees: Funcionario[]) => {
          this.employees = employees

          if (this.employees.length == 0) {
            this.selectEmployeeId = 0
            this.dashboardEmployee.countFuncionarios = 0;

          } else {

            this.selectEmployeeId = this.employees[0].id;
          }
            this.changeSelectEmployee()
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public changeSelectEmployee(): void {
    this.employeeService
      .countEmployee(this.selectJobRoleId)
      .subscribe(
        (returnDash: DashboardEmployee) => {
          this.dashboardEmployee = returnDash;
          if (this.dashboardEmployee !== null) {
            this.totEmployee = this.dashboardEmployee.countFuncionarios;

            this.getEmployeesGoals(this.selectEmployeeId)
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public getGoals(companyId: number): void {
    this.goalService
      .getGoalByCompanyId(companyId)
      .subscribe(
        (goals: Meta[]) => {
          this.goals = goals

          if (this.goals.length == 0) {
            this.selectGoalId = 0
            this.dashboardGoal.countMetas = 0;
            this.dashboardGoal.countMetasAprovadas = 0;
            this.dashboardGoal.countMetasCumpridas = 0;

          } else {

            this.selectGoalId = this.goals[0].id;
          }
            this.changeSelectGoal()
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public changeSelectGoal(): void {
    this.goalService
      .countGoal(this.selectCompanyId)
      .subscribe(
        (returnDash: DashboardGoal) => {
          this.dashboardGoal = returnDash;
          if (this.dashboardGoal !== null) {
            this.totGoal = this.dashboardGoal.countMetas;
            this.totMetGoal = this.dashboardGoal.countMetasCumpridas;
            this.totApprovedGoal = this.dashboardGoal.countMetasAprovadas;
            this.totPercMetGoal = +(this.totMetGoal / this.totGoal * 100).toFixed(2)
            this.totPercApprovedGoal = +(this.totApprovedGoal / this.totGoal * 100).toFixed(2)
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }

    public getEmployeesGoals(employeeId: number): void {
    this.employeeGoalAssociateService
      .getGoalsByEmployeeId(employeeId)
      .subscribe(
        (employeeGoals: FuncionarioMeta[]) => {
          this.employeeGoals = employeeGoals

          if (this.employeeGoals.length == 0) {
            this.selectAssociatedGoalId = 0
            this.dashboardEmployeeGoal.countMetasAssociadas = 0;
            this.dashboardEmployeeGoal.countMetasCumpridas = 0;

          } else {

            this.selectAssociatedGoalId = this.employeeGoals[0].metaId;
          }
            this.changeSelectEmployeeGoal()
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public changeSelectEmployeeGoal(): void {
    this.employeeGoalAssociateService
      .countEmployeeGoal(this.selectEmployeeId)
      .subscribe(
        (returnDash: DashboardEmployeeGoal) => {
          this.dashboardEmployeeGoal = returnDash;
          if (this.dashboardEmployeeGoal !== null) {
            this.totAssociateGoal = this.dashboardEmployeeGoal.countMetasAssociadas;
            this.totMetAssociateGoal = this.dashboardEmployeeGoal.countMetasCumpridas;
            this.totPercMetAssociateGoal = +(this.totMetAssociateGoal / this.totAssociateGoal * 100).toFixed(2);
          }
        }
      )
      .add(() => this.spinnerService.hide())
  }
  public newColor(): any {
    return 'color: ' + RandomColors.colorsGenerate();
  }
}
