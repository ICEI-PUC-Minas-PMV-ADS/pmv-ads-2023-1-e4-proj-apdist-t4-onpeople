import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { faCalendarAlt } from '@fortawesome/free-solid-svg-icons'

import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios/ValidadorFormularios';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { EmpresasService } from 'src/app/services/empresas/Empresas.service';

@Component({
  selector: 'app-empresasDetalhe',
  templateUrl: './empresasDetalhe.component.html',
  styleUrls: ['./empresasDetalhe.component.scss']
})
export class EmpresasDetalheComponent implements OnInit {

  public form: FormGroup;

  public estadoSalvar: string = 'post';
  public estadoBotao: string = 'Criar'

  public calendarIcon = faCalendarAlt;

  public empresa: Empresa;

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
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
    )
  {
    this.localService.use('pt-br')
  }

  ngOnInit() {
    this.spinner.show
    this.validarFormulario();
    this.consultarEmpresa();
  }

  public validarFormulario(): void {
    this.form = this.formBuilder.group({
      nomeEmpresa: ['', [
        Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      nomeFantasia: ['', [
        Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      sigla: ['', [
        Validators.required, Validators.minLength(3), Validators.maxLength(7)]],
      ativa: ['', [ Validators.required]],
      dataCadastro: ['', [ Validators.required]],
      dataDesativacao: [''],
      filial: ['', [ Validators.required]],
      padraoEmail: ['',  [ Validators.required]]
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
    const empresaIdparam = this.activevateRouter.snapshot.paramMap.get('id');

    if (empresaIdparam !== null) {
      this.estadoSalvar = 'put'
      this.estadoBotao = 'Salvar'

      this.empresaService
          .getEmpresaById(+empresaIdparam)
          .subscribe(
            (empresa: Empresa) => {
              this.empresa = { ...empresa};
              this.form.patchValue(this.empresa);
            },
            (error: any) => {
              this.toastr.error("Não foi possível carrgar os dados da empresa.", 'Erro!');
              console.error(error);
            }
          )
          .add(() => this.spinner.hide());
    }
  }

  public salvarAlteracao(): void {
    this.spinner.show();

    if(this.form.valid) {
      this.empresa = (this.estadoSalvar == 'post')
        ? { ...this.form.value }
        : {id: this.empresa.id, ...this.form.value };
    }

    if(this.estadoSalvar == 'post') {
      this.empresaService
          .createEmpresa(this.empresa)
          .subscribe(
            (empresa: Empresa) => {
              this.toastr.success('Empresa criada!', 'Sucesso!');
            },
            (error: any) => {
              this.toastr.error("Erro ao criar a empresa.", "Eror!");
              console.error(error);
            }
          )
          .add(() => this.spinner.hide())
    } else {
      this.empresaService
      .salvarEmpresa(this.empresa.id, this.empresa)
      .subscribe(
        (empresa: Empresa) => {
          this.toastr.success('Empresa salva!', 'Sucesso!');
        },
        (error: any) => {
          this.toastr.error("Erro ao salvar a empresa.", "Eror!");
          console.error(error);
        }
      )
      .add(() => this.spinner.hide())
    }
  }
}
