import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-contaCadastro',
  templateUrl: './contaCadastro.component.html',
  styleUrls: ['./contaCadastro.component.scss']
})
export class ContaCadastroComponent implements OnInit {

  public form!: FormGroup;

  constructor() { }

  ngOnInit() {
  }

  cadastrarConta(): void {
    
  }
}
