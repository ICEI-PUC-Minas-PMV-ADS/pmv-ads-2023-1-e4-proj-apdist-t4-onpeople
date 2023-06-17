import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Funcionario, FuncionarioMeta, Users } from 'src/app/models';
import { EmployeeGoalAssociateService, EmployeeService, UserService } from 'src/app/services';


@Component({
  selector: 'app-myGoals',
  templateUrl: './myGoals.component.html',
  styleUrls: ['./myGoals.component.scss']
})
export class MyGoalsComponent implements OnInit {
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
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.goalParm = this.activevateRouter.snapshot.paramMap.get('id');

    this.getEmployee();
  }

  public getEmployee(): void {
    this.spinnerService.show();

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
      .add(() => this.spinnerService.hide());
  }
  public getGoalsEmployee(): void {
    this.spinnerService.show();

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
      .add(() => this.spinnerService.hide());
  }

  public getUser(): void {
    this.spinnerService.show();

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
      .add(() => this.spinnerService.hide());
  }
}
