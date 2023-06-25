import { Component, OnInit, ViewChild  } from '@angular/core';
import { ChartType } from 'angular-google-charts';
import { ToastrService } from 'ngx-toastr';
import { CompanyService } from 'src/app/services';
import { DashboardCompany, QuantitativeDash } from 'src/app/shared/class/dashboard';

import { ListaMetas } from 'src/app/shared/class/dashboard/ListaMetas';

@Component({
  selector: 'app-dashCompany',
  templateUrl: './dashCompany.component.html',
  styleUrls: ['./dashCompany.component.scss']
})
export class DashCompanyComponent implements OnInit {
  public spinnerShow: boolean = false;

  public dashCompany: DashboardCompany;

  public dashGoals: ListaMetas[] = []

  public goalsPerform: QuantitativeDash[] = [];
  public goalsNotPerform: QuantitativeDash[] = [];

  public colors: string[] = [];

  public barChartOptions = {
    responsive: true,
    scaleShowVerticalLines: false
  }

  public titleColumnChart = "Quantidade de departamentos por empresa";
  public typeColumnChart = "PieChart" as ChartType;
  public columnNamesChart = ['Empresa', "Departamentos", { role: "annotation" }]
  public options = {     pieHole:0.4};
  public width = 1250;
  public height = 800;

  public chartData: any[] = [];

  constructor(
    private companyService: CompanyService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.loadDashboardCompany();
  }

  public loadDashboardCompany(): void {
    this.spinnerShow = true;

    this.companyService
      .getDashCompany(0)
      .subscribe(
        (dashCompany: DashboardCompany) => {
          this.dashCompany = dashCompany
          console.log("== dashCompany == ", this.dashCompany)
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
    this.dashCompany.listaNomeEmpresa.forEach((item , i) =>
      this.chartData.push([item, this.dashCompany.listaQtdeDepartamentos[i]]))

    console.log("ListaEmpresas", this.chartData)
  }

  public loadDashMetas(): void {
    this.spinnerShow = true;

    this.companyService
      .getDashGoals(0)
      .subscribe(
        (dashGoals: ListaMetas[]) => {
          this.dashGoals = dashGoals
          console.log("dashGoals", this.dashGoals)
          this.goalsByCompany();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerShow = false)
  }

  public goalsByCompany(): void {
    var listGoalsPerform: QuantitativeDash[] = [];
    var listGoalsNotPerform: QuantitativeDash[] = [];
    var sortListGoalsPerform: QuantitativeDash[] = [];
    var sortListGoalsNotPerform: QuantitativeDash[] = [];

    this.getColors();

    console.log("Quantidade de Metas", this.colors)

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
  }
}


