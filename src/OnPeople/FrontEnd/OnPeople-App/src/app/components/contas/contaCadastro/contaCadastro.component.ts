import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { ValidadorFormularios } from 'src/app/helpers/class/ValidadorFormularios';

@Component({
  selector: 'app-contaCadastro',
  templateUrl: './contaCadastro.component.html',
  styleUrls: ['./contaCadastro.component.scss']
})
export class ContaCadastroComponent implements OnInit {

  public form: FormGroup;

  public get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validarFormulario();
   
  }

  public validarFormulario(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidadorFormularios.compararArgumentos('senha', 'confirmarSenha')
    };

    this.form = this.fb.group({
      nomeEmpresa: ['1', [
        Validators.required]],
      conta: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(15)]],
      nomeCompleto: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(40)]],
      email: ['agaldino@br.xlb.com', [
        Validators.email]],
      senha: ['agaldino@br.xlb.com', [
        Validators.required, Validators.minLength(3)]],
      confirmarSenha: ['', [
        Validators.required ]],
    }, formOptions);
  }

  public validarCampo(campoForm: FormControl): any {
    return ValidadorFormularios.verificarErroCampo(campoForm);
  }

  public retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidadorFormularios.retornarMensagem(nomeCampo, nomeElemento);
  }

  cadastrarConta(): void {

  }
}
