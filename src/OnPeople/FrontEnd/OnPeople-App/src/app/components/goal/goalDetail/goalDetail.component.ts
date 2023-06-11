import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Empresa, Meta } from 'src/app/models';

import { CompanyService, GoalService } from 'src/app/services';
import { PaginatedResult } from 'src/app/shared/class/paginator';

import { FormValidator } from 'src/app/shared/class/validators';
import { environment } from 'src/assets/environments';

import { DateAdapter } from '@angular/material/core';
import * as moment from 'moment';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-goalDetail',
  templateUrl: './goalDetail.component.html',
  styleUrls: ['./goalDetail.component.scss']
})
export class GoalDetailComponent implements OnInit {
  public formGoal: FormGroup;

  public selectCompanyId = 0;

  public goalParm: any = "";

  public company = {} as Empresa;
  public companies: Empresa[] = [];

  public goal = {} as Meta;

  public editMode: Boolean = false;

  public logoURL: string = "../../../../assets/img/Image_not_available.png";

  public get ctrF(): any {
    return this.formGoal.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private companyService: CompanyService,
    private dateAdapter: DateAdapter<Date>,
    private formBuilder: FormBuilder,
    private goalService: GoalService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) {
    this.dateAdapter.setLocale('pt-BR')
   }

  ngOnInit() {
    this.goalParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.editMode = (this.goalParm != null) ? true : false;

    this.formValidator();

    if (this.editMode) {
      this.getGoal();
    }
      else {
      this.getCompanies();
    }
  }

  public formValidator(): void {
    this.formGoal = this.formBuilder.group({
      selectCompanyId: [0, Validators.required],
      cnpj: [''],
      tipoMeta: ["", Validators.required],
      nomeMeta: ['', Validators.required],
      metaCumprida: ['', Validators.required ],
      descricao: ['',  [ Validators.required,]],
      metaAprovada: ['', Validators.required],
      inicioPlanejado: ['', Validators.required],
      fimPlanejado: ['', Validators.required],
      diasPlanejado: ['0' ],
      inicioOficial: [''],
      fimOficial: [''],
      diasOficial: ['0' ],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formGoal.reset();
  }

  public changeSelectCompany(): void {
    this.spinnerService.show()

    this.companyService
      .getCompanyById(this.selectCompanyId)
      .subscribe(
        (company: Empresa) => {
          this.company = company
          this.formGoal.patchValue(this.company)
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
          ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
        },
        (error: any) => {
          this.logoURL = "../../../../assets/img/Image_not_available.png";
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getCompanies(): void {
    this.spinnerService.show();

    this.companyService
      .getCompanies(environment.initialPageDefault, environment.totalPagesDefault)
      .subscribe(
        (companies: PaginatedResult<Empresa[]>) => {
         this.companies = companies.result.filter(c => c.cargos.length > 0);
          console.log("Companies", this.companies)
          this.company = this.companies[0];
          this.selectCompanyId = this.company.id;
          this.formGoal.patchValue(this.company);
          this.logoURL = (this.companies[0].logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.companies[0].logotipo}`
            : `../../../../assets/img/${this.companies[0].logotipo}`;
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public calculateIntervalPlanned(inicioPlanejado: string, fimPlanejado: string): void {
    this.ctrF.diasPlanejado.setValue(this.calculateIntervalOfDays(inicioPlanejado, fimPlanejado))
  }

  public calculateIntervalEffective(inicioOficial: string, fimOficial: string): void {
    this.ctrF.diasOficial.setValue(this.calculateIntervalOfDays(inicioOficial, fimOficial))
  }
  public calculateIntervalOfDays(inicioPlanejado: string, fimPlanejado: string): number {
    moment.calendarFormat
    const inicioPlan = moment(new Date(inicioPlanejado));
    const fimPlan = moment(new Date(fimPlanejado));
    const diasPlan = moment.duration(fimPlan.diff(inicioPlan));

    return (parseInt((diasPlan.asDays() + 1).toFixed(0)));
  }

  public saveChange(): void {
    this.spinnerService.show();

    if(this.formGoal.valid)
      if (!this.editMode){
        this.createGoal();
      }
      else {
        this.updateMeta();
      }
  }

  public createGoal(): void {
    this.spinnerService.show();

    this.goal = { ... this.formGoal.value };
    this.goal.empresaId = this.selectCompanyId;

    this.goalService
      .createGoal(this.goal)
      .subscribe(
        (goalCreated: Meta) => {
          this.toastrService.success('Meta criada', 'Sucesso!');
          window.location.reload;
          this.router.navigateByUrl(`/metas/detail/${goalCreated.id}`);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public updateMeta(): void {
    this.spinnerService.show();

    this.goal = { id: this.goal.id, ...this.formGoal.value };
    this.goal.empresaId = this.selectCompanyId;

    console.log("Update Meta", this.goal)

    this.goalService
      .saveGoal(this.goal.id, this.goal)
      .subscribe(
        (goal: Meta) => {
          this.toastrService.success("Meta salva!", "Sucesso!");
        },
        (error: any) => {
          if (error.status == 401)
            this.toastrService.error("Conta não autorizada.", `Erro! Status ${error.status}`)
        }
      )
  }

  public getGoal(): void {
    this.spinnerService.show();

    if (this.editMode) {
      this.goalService
      .getGoalById(this.goalParm)
      .subscribe(
        (goal: Meta) => {
          this.goal = goal;
          this.company = this.goal.empresa;
          this.companies[0] = this.company;
          console.log("Meta", this.goal);
          this.formGoal.patchValue(this.goal);
          this.selectCompanyId = this.goal.empresaId;
          this.formGoal.patchValue(this.company);
          this.logoURL = (this.company.logotipo !== 'Image_not_available.png')
            ? `${environment.resourcesLogosURL}${this.company.logotipo}`
            : `../../../../assets/img/${this.company.logotipo}`;
          },
          (error: any) => {
            this.toastrService.error(error.error, `Erro! Status ${error.status}`);
            console.error(error);
          }
        )
        .add(() => this.spinnerService.hide());

    }
  }
}
