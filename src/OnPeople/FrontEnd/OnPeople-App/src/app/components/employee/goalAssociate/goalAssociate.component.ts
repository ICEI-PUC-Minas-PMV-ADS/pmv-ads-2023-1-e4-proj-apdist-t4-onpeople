import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Funcionario, FuncionarioMeta, Meta } from 'src/app/models';
import { EmployeeGoalAssociateService, EmployeeService, GoalService } from 'src/app/services';
import { PaginatedResult } from 'src/app/shared/class/paginator';
import { FormValidator } from 'src/app/shared/class/validators';
import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-goalAssociate',
  templateUrl: './goalAssociate.component.html',
  styleUrls: ['./goalAssociate.component.scss']
})
export class GoalAssociateComponent implements OnInit {
  public formGoals: FormGroup;

  public spinnerShow: boolean = false;

  public employeeGoalId = 0;

  public employee = {} as Funcionario;

  public goal = {} as Meta;
  public goals: Meta[] = [];

  public employeeGoal = {} as FuncionarioMeta;
  public employeeGoals: FuncionarioMeta[] = [];

  public goalParm: any = "";

  public get ctrF(): any {
    return this.formGoals.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private employeeService: EmployeeService,
    private employeeGoalAssociateService: EmployeeGoalAssociateService,
    private formBuilder: FormBuilder,
    private goalService: GoalService,
    private router: Router,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.goalParm = this.activevateRouter.snapshot.paramMap.get('id');

    this.formValidator();

    this.getEmployee();
  }

  public formValidator(): void {
    this.formGoals = this.formBuilder.group({
      selectGoalId: [0, Validators.required],
      goalAssociated: ['' ],
      tipoMeta: [""],
      descricao: [''],
      nomeMeta: [''],
      metaCumprida: ['' ],
      metaAprovada: [''],
      inicioPlanejado: [''],
      fimPlanejado: [''],
      diasPlanejado: ['0' ],
      inicioOficial: [''],
      fimOficial: [''],
      diasOficial: ['0'],
      inicioEfetivo: [''],
      fimEfetivo: [''],
      diasEfetivo: ['0'],
      inicioAcordado: ['', Validators.required],
      fimAcordado: ['', Validators.required],
      diasAcordado: ['0'],
      employeeGoalId: [],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public changeSelectGoal(): void {
    this.spinnerShow = true;

    this.goalService
      .getGoalById(this.ctrF.selectGoalId.value)
      .subscribe(
        (goal: Meta) => {
          this.goal = goal
          this.formGoals.patchValue(this.goal)
          this.verifyGoalEmployeeExists();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public calculateIntervalEffective(inicioEFetivo: string, fimEfetivo: string): void {
    this.ctrF.diasEfetivo.setValue(this.calculateIntervalOfDays(inicioEFetivo, fimEfetivo))
  }

  public calculateIntervalConcerted(inicioAcordado: string, fimAcordado: string): void {
    this.ctrF.diasAcordado.setValue(this.calculateIntervalOfDays(inicioAcordado, fimAcordado))
  }
  public calculateIntervalOfDays(intervaloInicio: string, intervalorFim: string): number {
    moment.calendarFormat
    const inicioPlan = moment(new Date(intervaloInicio));
    const fimPlan = moment(new Date(intervalorFim));
    const diasPlan = moment.duration(fimPlan.diff(inicioPlan));

    return (parseInt((diasPlan.asDays() + 1).toFixed(0)));
  }


  public getEmployee(): void {
    this.spinnerShow = true;

    this.employeeService
      .getEmployeeById(this.goalParm)
      .subscribe(
        (employee: Funcionario) => {
          this.employee = employee;
          this.formGoals.patchValue(this.employee);
          this.getGoals();
          this.getGoalsEmployee();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getGoals(): void {
    this.spinnerShow = true;

    this.goalService
      .getGoals(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (goals: PaginatedResult<Meta[]>) => {
          this.goals = goals.result.filter(c => c.empresaId == this.employee.empresaId && c.metaAprovada);
          if (this.goals.length > 0) {
            this.goal = this.goals[0];
            this.ctrF.selectGoalId.setValue(this.goal.id);
            this.formGoals.patchValue(this.goal);
            this.verifyGoalEmployeeExists()
          }
       },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public verifyGoalEmployeeExists(): void {
    this.spinnerShow = true;

    this.employeeGoalAssociateService
      .verifyGoalEmployeeExists(this.employee.id, this.goal.id)
      .subscribe(
        (goalAssociated: boolean) => {
          this.ctrF.goalAssociated.setValue(goalAssociated);
          if (this.ctrF.goalAssociated.value) {
            this.getGoalEmployee();
          }
          else {
            this.employeeGoal.metaCumprida = false;
            this.employeeGoal.inicioEfetivo = '';
            this.employeeGoal.fimEfetivo = '';
            this.employeeGoal.diasEfetivo = 0;
            this.employeeGoal.inicioAcordado = '';
            this.employeeGoal.fimAcordado = '';
            this.employeeGoal.diasAcordado = 0;
            this.formGoals.patchValue(this.employeeGoal);
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public getGoalEmployee(): void {
    this.spinnerShow = true;

    this.employeeGoalAssociateService
      .getEmployeeGoalByIds(this.employee.id, this.ctrF.selectGoalId.value)
      .subscribe(
        (goalEmployee: FuncionarioMeta) => {
          this.employeeGoal = goalEmployee;
          this.formGoals.patchValue(this.employeeGoal);
          this.employeeGoalId = this.employeeGoal.id;
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
          if (this.employeeGoals.length > 0) {
            this.employeeGoal = this.employeeGoals[0]
            this.formGoals.patchValue(this.employeeGoal);
            this.employeeGoalId = this.employeeGoal.id;
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerShow = false);
    }

  public saveChanges(): void {
    if (!this.ctrF.goalAssociated.value)
      this.associateGoal();
    else
      this.saveGoal();
    this.getGoalsEmployee();
  }

  public associateGoal(): void {
    this.spinnerShow = true;

    this.employeeGoal = { ... this.formGoals.value };
    this.employeeGoal.funcionarioId = this.employee.id;
    this.employeeGoal.metaId = this.ctrF.selectGoalId.value;
    this.employeeGoal.empresaId = this.employee.empresaId;
    console.log("create", this.employeeGoal)
    this.employeeGoalAssociateService
      .associateGoal(this.employeeGoal)
      .subscribe(
        (goalAssociated: FuncionarioMeta) => {
          this.toastrService.success('Meta associada ao funcionário', 'Sucesso!');
          this.ctrF.goalAssociated.setValue(true);
          window.location.reload();
          this.router.navigateByUrl(`/funcionarios/detail/${this.employee.id}`);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false);
  }

  public saveGoal(): void {
    this.spinnerShow = true;

    this.employeeGoal = { id: this.employeeGoalId, ...this.formGoals.value };
    this.employeeGoal.funcionarioId = this.employee.id;
    this.employeeGoal.metaId = this.ctrF.selectGoalId.value;

    this.employeeGoalAssociateService
      .saveGoal(this.employeeGoal.id, this.employeeGoal)
      .subscribe(
        (employeeGoal: FuncionarioMeta) => {
          this.toastrService.success("Meta salva!", "Sucesso!");
          window.location.reload();
        },
        (error: any) => {
          if (error.status == 401)
            this.toastrService.error("Conta não autorizada.", `Erro! Status ${error.status}`)
        }
      )
  }
}
