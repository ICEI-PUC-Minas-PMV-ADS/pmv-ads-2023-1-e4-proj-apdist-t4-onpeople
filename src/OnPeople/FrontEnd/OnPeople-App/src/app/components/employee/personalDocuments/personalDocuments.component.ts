import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DadoPessoal } from 'src/app/models';
import { PersonalDocumentsService } from 'src/app/services';
import { FormValidator } from 'src/app/shared/class/validators';


@Component({
  selector: 'app-personalDocuments',
  templateUrl: './personalDocuments.component.html',
  styleUrls: ['./personalDocuments.component.scss']
})
export class PersonalDocumentsComponent implements OnInit {
  public formPersonalDocuments: FormGroup;

  public id = 0;

  public employeeParm: any = "";

  public cep: any = "";

  public editMode: Boolean = false;

  public personalDocument = {} as DadoPessoal;
  public personalsDocuments: DadoPessoal[] = [];

  public get ctrF(): any {
    return this.formPersonalDocuments.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private personalDocumentService: PersonalDocumentsService,
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.employeeParm = this.activevateRouter.snapshot.paramMap.get('id');
    this.formValidator();

    this.getPersonalDocument();
  }

  public formValidator(): void {
    this.formPersonalDocuments = this.formBuilder.group({
      id: [0, Validators.required],
      cpf: ['', Validators.required],
      tituloEleitor: ["", Validators.required],
      impedimentoEleitoral: ['', Validators.required],
      identidade: ['', Validators.required],
      dataExpedicao: ['', Validators.required],
      ufEmissao: ['', Validators.required],
      estadoCivil: ['', Validators.required],
      carteiraTrabalho: ['', Validators.required],
      pisPasep: ['', Validators.required],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public getPersonalDocument(): void {
    this.spinnerService.show();

    this.personalDocumentService
      .getAllPersonalDocumentsByEmployeeId(parseInt(this.employeeParm))
      .subscribe(
        (personalsDocuments: DadoPessoal[]) => {
          this.personalsDocuments = personalsDocuments;
          this.personalDocument = this.personalsDocuments[0]
          this.id = this.personalDocument.id;
          this.formPersonalDocuments.patchValue(this.personalDocument);
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`)
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public saveChange(): void {
    this.spinnerService.show();

    this.personalDocument = { ...this.formPersonalDocuments.value }
    this.personalDocument.funcionarioId = this.employeeParm;

    this.personalDocumentService
      .savePersonalDocument(this.personalDocument.id, this.personalDocument)
      .subscribe(
        (personalDocument: DadoPessoal) => {
          this.toastrService.success('Dados Pessoais ataulizados!', "Sucesso")

        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status} `)
        }
      )
      .add(() => this.spinnerService.hide())
  }
}
