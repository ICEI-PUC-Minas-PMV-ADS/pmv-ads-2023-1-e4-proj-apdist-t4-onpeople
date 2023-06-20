import { Component, OnInit, ViewChild  } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Departamento, Empresa, Funcionario, FuncionarioMeta} from 'src/app/models';
import { CompanyService, EmployeeGoalAssociateService, EmployeeService } from 'src/app/services';
import { QuantitativeDash } from 'src/app/shared/class/dashboard';
import { PaginatedResult } from 'src/app/shared/class/paginator';
import { environment } from 'src/assets/environments';


import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import DataLabelsPlugin from 'chartjs-plugin-datalabels';

import { DashList, DashListEmployee, DashListGoal } from 'src/app/shared/class/dashboardList';

@Component({
  selector: 'app-dashCompany',
  templateUrl: './dashCompany.component.html',
  styleUrls: ['./dashCompany.component.scss']
})
export class DashCompanyComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  public selectCompanyId = 0;

  public companies = [] as Empresa[];
  public departments = [] as Departamento[];
  public employeeGoals = [] as FuncionarioMeta[];
  public employees = [] as Funcionario[];

  public dashListEmployee: DashListEmployee[] = [];
  public dashListGoal: DashListGoal[] = [];
  public dashList: DashList[] = [];

  public goalsPerform: QuantitativeDash[] = [];
  public goalsNotPerform: QuantitativeDash[] = [];

  public colors: string[] = [];

  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    color: 'blue',
    scales: {
      x: {},
      y: {
        min: 1,
        max: 50
      }
    },
    plugins: {
      legend: {
        display: true,
      },
      datalabels: {
        anchor: 'end',
        align: 'end'
      }
    }
  }

  public barChartType: ChartType = 'bar';

  public barChartPlugins = [
    DataLabelsPlugin
  ];

  public barChartLabels: string[] = [];
  public barChartValues: number[] = [];
  public barChartData: ChartData<'bar'> = {
    labels: this.barChartLabels,
    datasets: [
      { data: this.barChartValues, label: 'Empresas x Departamentos' },
    ]
  }

  constructor(
    private companyService: CompanyService,
    private employeeService: EmployeeService,
    private employeeGoalAssociateService: EmployeeGoalAssociateService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.loadCompanies();
    this.loadEmployees();
  }

  public changeSelectCompany(): void {
    console.log("***** selectCompany", this.selectCompanyId)
  }

  // events
  public chartClicked({ event, active }: { event?: ChartEvent, active?: {}[] }): void {
//    console.log(event, active);
  }

  public chartHovered({ event, active }: { event?: ChartEvent, active?: {}[] }): void {
//    console.log(event, active);
  }

  public loadCompanies(): void {
    this.spinnerService.show();

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          this.companies = companies.result
          console.log("== companies == ", this.companies)
          this.montarBarChar()
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public montarBarChar(): void {
    this.companies.forEach((c) => {
      this.barChartLabels.push(c.razaoSocial);
      this.barChartValues.push(c.departamentos.length);


    });
    console.log("ListaEmpresas", this.barChartLabels)
  }

  /*

  public dashboardCompany: DashboardCompany;
  public dashboardDepartment: DashboardDepartment;

  public dashboardEmployeeGoal: DashboardEmployeeGoal;
  public dashboardGoal: DashboardGoal;
  public dashboardJobRole: DashboardJobRole;


  public jobRoles = [] as Cargo[];

  public goals = [] as Meta[];





  public listDepartmentsByCompany: ListDepartmentsByCompany[] = [];


  public changeSelectCompany(): void {
    console.log("***** selectCompany", this.selectCompanyId)
    this.montarDoughnut();
  }
*/

  public loadEmployees(): void {
    this.spinnerService.show();

    this.employeeService
      .getEmployees(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (employees: PaginatedResult<Funcionario[]>) => {
          this.employees = employees.result
          this.employees.forEach((employee, e) => {
            this.dashListEmployee[e] = new DashListEmployee(
              employee.id,
              employee.nomeCompleto,
              employee.dataAdmissao,
              employee.dataDemissao,
              employee.departamento.id,
              employee.departamento.nomeDepartamento,
              employee.departamento.sigla,
              employee.departamento.ativo,
              employee.cargo.id,
              employee.cargo.nomeCargo,
              employee.cargo.ativo,
              employee.empresa.id,
              employee.empresa.razaoSocial,
              employee.empresa.cnpj,
              employee.empresa.ativa,
              employee.empresa.filial,
              employee.empresa.ativa,
            );
          })
          console.log("dashEmployee", this.dashListEmployee)
          this.loadEmployeeGoals()
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public loadEmployeeGoals(): void {
    this.spinnerService.show();

    this.employeeGoalAssociateService
      .getGoalsByEmployeeId(0)
      .subscribe(
        (employeeGoals: FuncionarioMeta[]) => {
          console.log("employeeGoals", employeeGoals)
          this.employeeGoals = employeeGoals
          this.employeeGoals.forEach((employeeGoal, e) => {
            this.dashListGoal[e] = new DashListGoal(
              employeeGoal.funcionarioId,
              employeeGoal.metaId,
              employeeGoal.meta.tipoMeta,
              employeeGoal.meta.nomeMeta,
              employeeGoal.meta.descricao,
              employeeGoal.meta.metaCumprida,
              employeeGoal.meta.metaAprovada,
              employeeGoal.metaCumprida,
            );
          })
          this.generateDashboardList()
          console.log("dashEmployeeGoals", this.dashListGoal)
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public generateDashboardList(): void {
    let i = 0;

    for (var e of this.dashListEmployee) {
      var goals = this.dashListGoal.filter(g => g.funcionarioMetaFuncionarioId == e.funcionarioId)
      for (var g of goals) {
        this.dashList[i] = new DashList(
          e.funcionarioId,
          e.funcionarioNome,
          e.funcionarioAdmissao,
          e.funcionarioDemissao,
          e.departamentoId,
          e.departamentoNome,
          e.departamentoSigla,
          e.departamentoAtivo,
          e.cargoId,
          e.cargoNome,
          e.cargoAtivo,
          e.empresaId,
          e.empresaNome,
          e.empresaCnpj,
          e.empresaAtiva,
          e.empresaFilial,
          e.empresaFilialAtiva,
          g.funcionarioMetaId,
          g.funcionarioMetaTipoMeta,
          g.funcionarioMetaNome,
          g.funcionariometaDescricao,
          g.funcionarioMetaMetaCumprida,
          g.funcionarioMetaMetaAprovada,
          g.funcionarioMetaCumprida
        )
        i++;
      }
    }
    console.log("== employees + goals ", this.dashList)
    this.goalsByCompany();
  }

  public goalsByCompany(): void {
    var listGoalsPerform: QuantitativeDash[] = [];
    var listGoalsNotPerform: QuantitativeDash[] = [];
    var sortListGoalsPerform: QuantitativeDash[] = [];
    var sortListGoalsNotPerform: QuantitativeDash[] = [];

    var amountGoals = this.dashList.length;

    this.getColors();

    console.log("Quantidade de Metas", amountGoals, this.colors)

    for (var i in this.dashList) {
      listGoalsPerform[i] = new QuantitativeDash(this.dashList
        .filter((lgp) =>
            lgp.empresaNome == this.barChartLabels[i] && lgp.funcionarioMetaCumprida == true).length,
            this.barChartLabels[i],
            amountGoals,
            this.colors[i]
      );
    }

    console.log("listaMetasCumpridas", listGoalsPerform)

    sortListGoalsPerform = listGoalsPerform.sort((a, b) => (a.qtde > b.qtde) ? -1 : 1);
    console.log("listaMetasOrdenadas", sortListGoalsPerform)

    this.goalsPerform = sortListGoalsPerform.filter((cm, index) => index < 5)
    console.log("metasCumpridasTop5", this.goalsPerform)

    var amountGoals = this.dashList.length;

    this.getColors();

    for (var i in this.dashList) {
      listGoalsNotPerform[i] = new QuantitativeDash(this.dashList
        .filter((lgnp) =>
          lgnp.empresaNome == this.barChartLabels[i] && lgnp.funcionarioMetaCumprida == false).length,
          this.barChartLabels[i],
          amountGoals,
          this.colors[i]);
      }

      console.log("listaMetasNaoCumpridas", listGoalsNotPerform)

      sortListGoalsNotPerform = listGoalsNotPerform.sort((a, b) => (a.qtde > b.qtde) ? -1 : 1);
      console.log("listaMetasOrdenadas", sortListGoalsNotPerform)

      this.goalsNotPerform = sortListGoalsNotPerform.filter((em, index) => index < 5)
      console.log("metasNaoCumpridasTop5", this.goalsNotPerform)
  }

  public generateColor() {
    var hexadecimais = '0123456789ABCDEF';

    var cor = '#';

    for (var i = 0; i < 6; i++) {
      cor += hexadecimais[Math.floor(Math.random() * 16)];
    }
    return cor;
  }

  public getColors() {

    for (var i = 0; i < 12; i++) {
      this.colors[i] = this.generateColor();
    }
    console.log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@Cores", this.colors)
  }
}


