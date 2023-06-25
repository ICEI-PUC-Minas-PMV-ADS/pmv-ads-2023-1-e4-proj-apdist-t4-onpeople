import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';

import { Funcionario, FuncionarioMeta, Users } from 'src/app/models';

import { EmployeeGoalAssociateService, EmployeeService, UserService } from 'src/app/services';

@Component({
  selector: 'app-myGoals',
  templateUrl: './myGoals.component.html',
  styleUrls: ['./myGoals.component.scss']
})
export class MyGoalsComponent implements OnInit {
  public spinnerShow: boolean = false;

  public goalParm: any = "";

  public employee = {} as Funcionario;

  public user = {} as Users;

  public employeeGoal = {} as FuncionarioMeta;
  public employeeGoals: FuncionarioMeta[] = [];

  public imageGoals = '../../../../assets/img/metasPessoais.jpeg'

  constructor(
    private activevateRouter: ActivatedRoute,
    private employeeGoalAssociateService: EmployeeGoalAssociateService,
    private employeeService: EmployeeService,
    private toastrService: ToastrService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.goalParm = this.activevateRouter.snapshot.paramMap.get('id');

    this.getEmployee();
  }

  public getEmployee(): void {
    this.spinnerShow = true;

    this.employeeService
      .getEmployeeById(this.goalParm)
      .subscribe(
        (employee: Funcionario) => {
          this.employee = employee;
            this.getGoalsEmployee();
          this.getUser();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }
  public getGoalsEmployee(): void {
    this.spinnerShow = true;

    this.employeeGoalAssociateService
      .getGoalsByEmployeeId(this.employee.id)
      .subscribe(
        (goalsEmployee: FuncionarioMeta[]) => {
          this.employeeGoals = goalsEmployee;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getUser(): void {
    this.spinnerShow = true;

    this.userService
      .getUserById(this.employee.userId)
      .subscribe(
        (user: Users) => {
          this.user = user;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }
}
