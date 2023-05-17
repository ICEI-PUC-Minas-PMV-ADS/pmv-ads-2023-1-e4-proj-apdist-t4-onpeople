import { Component, OnInit, } from '@angular/core';

import { NgSelectConfig } from '@ng-select/ng-select';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Empresa } from 'src/app/companies/models';

import { CompanyService } from 'src/app/companies/services';

import { RandomColors } from 'src/app/shared/functions';
import { DashboardCompany, PaginatedResult } from 'src/app/shared/models';

@Component({
  selector: 'app-dashCompany',
  templateUrl: './dashCompany.component.html',
  styleUrls: ['./dashCompany.component.scss']
})
export class DashCompanyComponent implements OnInit {
  public color: any = "";

  public totalCompany = 0;
  public totalActive = 0;
  public percTotalActive = 4.0/5.0*100.0;
  public totalGoal = 40;
  public totalNotGoal = 25;
  public percTotalNotGoal = 25.0/40.0*100

  public dashboardCompany: DashboardCompany;

  public selectCompanyId = 0;

  public companies = [] as Empresa[];

  constructor(
    public companyService: CompanyService,
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
      .getCompanies(1, 50)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
          console.log(companies);
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
          }
        }
      )
  }

  public newColor(): any {
    return 'color: ' + RandomColors.colorsGenerate();
  }
}
