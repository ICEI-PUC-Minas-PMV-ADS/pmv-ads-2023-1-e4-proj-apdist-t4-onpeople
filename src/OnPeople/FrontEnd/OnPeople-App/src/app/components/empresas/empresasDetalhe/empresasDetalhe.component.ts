import { Component, OnInit, HostListener, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BsDatepickerDirective, BsLocaleService } from 'ngx-bootstrap/datepicker';
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

  @ViewChild(BsDatepickerDirective, { static: false }) datepicker: BsDatepickerDirective;
  @HostListener('window:scroll')

  public form: FormGroup;

  public estadoSalvar: string = 'post';
  public estadoBotao: string = 'Criar'

  public calendarIcon = faCalendarAlt;

  public empresa: Empresa;
  public empresaFilter: Empresa[] = [];
  public empresaMatriz: Boolean = false;
  public empresaMatrizId: number = 0;
  public nomeMatriz: string = ""

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
    private toastrService: ToastrService,
    private router: Router
    )
  {
    this.localService.use('pt-br')
  }

  ngOnInit() {
    this.spinner.show();

    this.validarFormulario();
    this.consultarEmpresa();

    this.spinner.hide();
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
      padraoEmail: ['',  [
        Validators.required, , Validators.minLength(5), Validators.maxLength(25)]]
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
    this.spinner.show();

    const empresaIdparam = this.activevateRouter.snapshot.paramMap.get('id');

    this.verificarEmpresaMatriz();

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
              this.toastrService.error("Não foi possível carrgar os dados da empresa.", 'Erro!');
              console.error(error);
            }
          )
          .add(() => this.spinner.hide());
    }
  }

  public verificarEmpresaMatriz(): void {
    const empresaIdparam: number = Number(this.activevateRouter.snapshot.paramMap.get('id'));

        this.empresaService
      .getEmpresas()
      .subscribe(
        (empresas: Empresa[]) => {
          if (empresas) {
            this.empresaFilter = empresas.filter((e) => e.filial == false);
          }
          console.log("Empresa Filter", this.empresaFilter, this.estadoBotao)
          if (this.empresaFilter.length > 0) {
            this.empresaMatrizId = this.empresaFilter[0].id
            this.nomeMatriz = this.empresaFilter[0].nomeEmpresa
            if (this.estadoBotao !== 'Salvar') {
              this.empresaMatriz = false;
            }else {
              this.empresaMatriz = (empresaIdparam == this.empresaFilter[0].id) ? true : false;
              console.log("Empresa Matriz?", this.empresaMatriz, this.empresaMatrizId, this.nomeMatriz, empresaIdparam)
            }
          }
        },
        (error: any) => {
          this.toastrService.error("Falha ao verificar se empresa é matriz", "Erro!")
          console.error(error)
        }
      )
  }

  public salvarAlteracao(): void {
    this.spinner.show();

    if(this.form.valid) {
      this.empresa = (this.estadoSalvar == 'post')
      ? { ...this.form.value }
      : {id: this.empresa.id, ...this.form.value };
    }

    this.empresa.logotipo = 'Image_not_available.png';
    this.empresa.filial = !this.empresaMatriz;
    this.empresa.matrizId = this.empresaMatrizId
    console.log("Criar empresa", this.empresa)

    if(this.estadoSalvar == 'post') {
      this.empresaService
          .createEmpresa(this.empresa)
          .subscribe(
            (empresa: Empresa) => {
              this.toastrService.success('Empresa criada!', 'Sucesso!');
            },
            (error: any) => {
              this.toastrService.error("Erro ao criar a empresa.", "Eror!");
              console.error(error);
            }
          )
          .add(() => this.spinner.hide())
    } else {
      console.log("salvar empresa", this.empresa)
      this.empresaService
      .salvarEmpresa(this.empresa.id, this.empresa)
      .subscribe(
        (empresa: Empresa) => {
          this.toastrService.success('Empresa salva!', 'Sucesso!');
        },
        (error: any) => {
          this.toastrService.error("Erro ao salvar a empresa.", "Eror!");
          console.error(error);
        }
        )
        .add(() => this.spinner.hide())
      }
      this.router.navigate(['empresas/lista'])
  }
}
