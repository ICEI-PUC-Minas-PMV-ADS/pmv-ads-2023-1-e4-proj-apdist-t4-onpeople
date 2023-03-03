import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.scss']
})
export class EmpresasComponent implements OnInit {

  public empresas: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEmpresas();
  }

  public getEmpresas(): void {
    this.http.get('https://localhost:7282/api/empresas')
      .subscribe(
        response => this.empresas = response,
        error => console.log(error)
      );

  }
}
