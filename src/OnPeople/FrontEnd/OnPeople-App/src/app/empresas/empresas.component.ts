import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { faTrash, faPencil } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.scss']
})
export class EmpresasComponent implements OnInit {

  public trashIcon = faTrash;
  public pencilIcon = faPencil

  public empresas: any = [];
  public empresasFiltradas: any = []
  private _filtroEmpresa: string = '';

  public get filtroEmpresa() {
    return this._filtroEmpresa;
  }

  public set filtroEmpresa(argumento: string) {
    this._filtroEmpresa = argumento;
    this.empresasFiltradas = this.filtroEmpresa ? this.filtrarEmpresas(this.filtroEmpresa) : this.empresas
  }

  public filtrarEmpresas(argumento: string): any {
    argumento = argumento.toLocaleLowerCase();
    return this.empresas.filter(
      (empresa: {nomeEmpresa: string, nomeFantasia: string, siglaEmpresa: string}) =>
        empresa.nomeEmpresa.toLocaleLowerCase().indexOf(argumento) !== -1
        || empresa.nomeFantasia.toLocaleLowerCase().indexOf(argumento) !== -1
        || empresa.siglaEmpresa.toLocaleLowerCase().indexOf(argumento) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEmpresas();
  }

  public getEmpresas(): void {
    this.http.get('https://localhost:7282/api/empresas')
      .subscribe(
        response => {
          this.empresas = response,
          this.empresasFiltradas = this.empresas;
        },
        error => console.log(error)
      );

  }
}
