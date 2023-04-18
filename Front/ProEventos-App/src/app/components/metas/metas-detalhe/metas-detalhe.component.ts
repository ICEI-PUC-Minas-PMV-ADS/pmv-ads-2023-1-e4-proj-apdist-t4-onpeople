import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-metas-detalhe',
  templateUrl: './metas-detalhe.component.html',
  styleUrls: ['./metas-detalhe.component.scss']
})
export class MetasDetalheComponent implements OnInit {

  form: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      nomeMeta: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      tipoMeta: ['', Validators.required],
      dataInicio: ['', Validators.required],
      idEmpresa: ['', Validators.required],
      descricao: ['', Validators.required]
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

}
