import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios';

@Component({
  selector: 'app-empresasDetalhe',
  templateUrl: './empresasDetalhe.component.html',
  styleUrls: ['./empresasDetalhe.component.scss']
})
export class EmpresasDetalheComponent implements OnInit {

  public form: FormGroup;

  public get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validarFormulario();
  }

  public validarFormulario(): void {
    this.form = this.fb.group({
      nomeEmpresa: ['', [
        Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      nomeFantasia: ['', [
        Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      sigla: ['', [
        Validators.required, Validators.minLength(3), Validators.maxLength(5)]],
      ativa: ['1', [ Validators.required]],
      dataCadastro: ['', [ Validators.required]],
      dataDesativacao: [''],
      filial: ['1', [ Validators.required]],
      matriz: ['1'],
      presidente: ['1']
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

  public salvarAlteracao(): void {

  }

}
