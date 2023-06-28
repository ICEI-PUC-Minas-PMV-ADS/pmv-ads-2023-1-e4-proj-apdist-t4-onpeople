import { Component, OnInit } from '@angular/core';
import { ChartType } from 'angular-google-charts';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from 'src/app/services';
import { DashboardEmployee, QuantitativeDash } from 'src/app/shared/class/dashboard';
import { ListaMetas } from 'src/app/shared/class/dashboard/ListaMetas';
import { environment } from 'src/assets/environments';

@Component({
  selector: 'app-dashEmployee',
  templateUrl: './dashEmployee.component.html',
  styleUrls: ['./dashEmployee.component.scss']
})
export class DashEmployeeComponent implements OnInit {
  public spinnerShow: boolean = false;

  public dashEmployee: DashboardEmployee;

  public dashGoals: ListaMetas[] = []

  public goalsPerform: QuantitativeDash[] = [];
  public goalsNotPerform: QuantitativeDash[] = [];

  public colors: string[] = [];

  public titleColumnChart = "Quantidade de departamentos por empresa";
  public typeColumnChart = "PieChart" as ChartType;
  public columnNamesChart = ['Empresa', "Departamentos", { role: "annotation" }]
  public options = {     pieHole:0.4};
  public width = environment.charWidth;
  public height = environment.chartHeight;


  public chartData: any[] = [];

  constructor(
    private employeeService: EmployeeService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.loadDashboardEmployee();
  }

  public loadDashboardEmployee(): void {
    this.spinnerShow = true;

    this.employeeService
      .getDashEmployee(0, 0, 0, 0)
      .subscribe(
        (dashEmployee: DashboardEmployee) => {
          this.dashEmployee = dashEmployee
          this.montarChart();
          this.loadDashMetas();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public montarChart(): void {
    this.dashEmployee.listaNomeFuncionario.forEach((item , i) => {
      this.chartData.push([item, this.dashEmployee.listaQtdeMetas[i]])
    })

  }

  public loadDashMetas(): void {
    this.spinnerShow = true;

    this.employeeService
      .getDashEmployeeGoals(0, 0, 0, 0)
      .subscribe(
        (dashGoals: ListaMetas[]) => {
          this.dashGoals = dashGoals
          this.goalsByDepartment();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public goalsByDepartment(): void {
    var listGoalsPerform: QuantitativeDash[] = [];
    var listGoalsNotPerform: QuantitativeDash[] = [];
    var sortListGoalsPerform: QuantitativeDash[] = [];
    var sortListGoalsNotPerform: QuantitativeDash[] = [];

    this.getColors();

    for (var i in this.dashGoals) {
      listGoalsPerform[i] = new QuantitativeDash(
            this.dashGoals[i].qtdeMetasCumpridas,
            this.dashGoals[i].nomeEmpresa,
            this.dashGoals[i].qtdeMetas,
            this.colors[i]
      );
    }

    sortListGoalsPerform = listGoalsPerform.sort((a, b) => (a.qtde > b.qtde) ? -1 : 1);

    this.goalsPerform = sortListGoalsPerform.filter((cm, index) => index < 5)

    this.getColors();

    for (var i in this.dashGoals) {
      listGoalsNotPerform[i] = new QuantitativeDash(
          this.dashGoals[i].qtdeMetasNaoCumpridas,
          this.dashGoals[i].nomeEmpresa,
          this.dashGoals[i].qtdeMetas,
          this.colors[i]
      );
    }

    sortListGoalsNotPerform = listGoalsNotPerform.sort((a, b) => (a.qtde > b.qtde) ? -1 : 1);

    this.goalsNotPerform = sortListGoalsNotPerform.filter((em, index) => index < 5)

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
  }
}
