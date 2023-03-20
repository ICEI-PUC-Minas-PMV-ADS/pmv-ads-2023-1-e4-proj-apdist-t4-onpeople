import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { faCalendarAlt, IconDefinition } from '@fortawesome/free-solid-svg-icons'

import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios/ValidadorFormularios';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';
import { UploadsService } from 'src/app/services/uploads/uploads.service';
import { environment } from 'src/assets/environments/environments';

@Component({
  selector: 'app-empresasDetalhe',
  templateUrl: './empresasDetalhe.component.html',
  styleUrls: ['./empresasDetalhe.component.scss']
})
export class EmpresasDetalheComponent implements OnInit {

  public form: FormGroup;

  public estadoSalvar: string = 'post';
  public modoEditar: Boolean = false;

  public calendarIcon: IconDefinition = faCalendarAlt;

  public logotipoUpload: string = 'Image_not_available.png';
  public logotipoURL: string = "../../../../assets/img/upload1-325x300-1.jpg";
  public file: File[];

  public empresa: Empresa;
  public empresaFilter: Empresa[] = [];
  public empresaMatriz: Boolean = false;
  public empresaMatrizId: number = 0;
  public nomeMatriz: string = "";
  public empresaAtiva: Boolean = false;

  public get bsConfig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY h:mm:ss a',
      containerClass: 'theme-blue'
    }
  }

  public get fmC(): any {
    return this.form.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private empresaService: EmpresasService,
    private formBuilder: FormBuilder,
    private localService: BsLocaleService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private uploadsService: UploadsService,
    )
  {
    this.localService.use('pt-br')
  }

  ngOnInit() {
    this.spinnerService.show();

    this.validarFormulario();
    this.consultarEmpresa();

    this.spinnerService.hide();
  }

  public validarFormulario(): void {
    this.form = this.formBuilder.group({
      nomeEmpresa: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      nomeFantasia: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      sigla: ['', [ Validators.required, Validators.minLength(3), Validators.maxLength(7)]],
      dataCadastro: ['', [ Validators.required]],
      dataDesativacao: [''],
      padraoEmail: ['',  [ Validators.required, , Validators.minLength(5), Validators.maxLength(25)]]
    });
  }

  public validarCampo(campoForm: FormControl): any {
    return ValidadorFormularios.verificarErroCampo(campoForm);
  }

  public retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidadorFormularios.retornarMensagem(nomeCampo, nomeElemento);
  }

  public limparFormulario(): void {
    this.form.reset();
  }

  public consultarEmpresa(): void {
    this.spinnerService.show();

    const empresaIdparam = this.activevateRouter.snapshot.paramMap.get('id');

    this.verificarEmpresaMatriz();

    if (empresaIdparam !== null) {
      this.estadoSalvar = 'put'
      this.modoEditar = true;

      this.empresaService
          .getEmpresaById(+empresaIdparam)
          .subscribe(
            (empresa: Empresa) => {
              this.empresa = { ...empresa};
              this.form.patchValue(this.empresa);
              this.empresa.logotipo = empresa.logotipo;
              this.empresaAtiva = empresa.ativa
              this.logotipoURL = (this.empresa.logotipo !== 'Image_not_available.png')
                ? `${environment.resourcesLogosURL}${this.empresa.logotipo}`
                : `../../../../assets/img/${this.empresa.logotipo }`;
            },
            (error: any) => {
              this.toastrService.error(error.error, `Erro! Status ${error.status}`);
              console.error(error);
            }
          )
          .add(() => this.spinnerService.hide());
    }
  }

  public verificarEmpresaMatriz(): void {
    this.spinnerService.show();

    this.empresaService
      .getEmpresaMatriz()
      .subscribe(
        (empresa: Empresa) => {
          if (empresa == null) {
            this.empresaMatriz = true;
          } else {
            console.log("Filial ", empresa.filial)
            this.empresaMatriz = false;
            this.nomeMatriz = empresa.nomeEmpresa
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public salvarAlteracao(): void {
    this.spinnerService.show();

    if (this.empresa)
      this.logotipoUpload = this.empresa.logotipo;

    if(this.form.valid) {
      this.empresa = (this.estadoSalvar == 'post')
      ? { ...this.form.value }
      : {id: this.empresa.id, ...this.form.value };
    }

    this.empresa.logotipo = this.logotipoUpload;
    this.empresa.filial = !this.empresaMatriz;
    this.empresa.matrizId = this.empresaMatrizId
    this.empresa.ativa = this.empresaAtiva;

    if(this.estadoSalvar == 'post') {
      this.empresa.logotipo = 'Image_not_available.png';

      this.empresaService
          .createEmpresa(this.empresa)
          .subscribe(
            (empresa: Empresa) => {
              this.toastrService.success('Empresa criada!', 'Sucesso!');
              window.location.reload;
              this.router.navigateByUrl(`/empresas/detalhe/${empresa.id}`);
              this.estadoSalvar = 'put';
            },
            (error: any) => {
              this.toastrService.error(error.error, `Erro! Status ${error.status}`);
              console.error(error);
            }
          )
          .add(() => this.spinnerService.hide())
    } else {
      console.log("salvar empresa", this.empresa)
      this.empresaService
      .salvarEmpresa(this.empresa.id, this.empresa)
      .subscribe(
        (empresa: Empresa) => {
          this.toastrService.success('Empresa salva!', 'Sucesso!');
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide())
    }
  }

  public alterarImagem(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.logotipoUpload = event.target.result;

    this.file = ev.target.files;

    reader.readAsDataURL(this.file[0]);

    this.uplodaImagem();
  }

  public uplodaImagem(): void {
    this.spinnerService.show();

    const empresaIdparam: number = Number(this.activevateRouter.snapshot.paramMap.get('id'));

    this.uploadsService
      .salvarLogoEmpresa(empresaIdparam, this.file)
      .subscribe(
        () => {
          this.toastrService.success("Logo atualizada!", "Sucesso!"),
          this.consultarEmpresa();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
