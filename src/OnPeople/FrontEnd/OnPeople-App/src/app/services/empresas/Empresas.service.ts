import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';

import { Empresa } from 'src/app/models/empresas/Empresa';


@Injectable()
export class EmpresasService {
  baseURL = 'https://localhost:7282/api/empresas'

  constructor(private http: HttpClient) { }

  public getEmpresas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(this.baseURL)
      .pipe(take(3));
  }

  public getEmpresaById(id: number): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}/${id}`)
    .pipe(take(3));
  }

  public getEmpresasByArgumento(argumento: string): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/${argumento}/argumento`)
    .pipe(take(3));
  }

  public getEmpresasAtivas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/ativas`)
    .pipe(take(3));
  }

  public getEmpresasFiliais(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/filiais`)
    .pipe(take(3));
  }

  public createEmpresa(empresa: Empresa): Observable<Empresa> {
    return this.http.post<Empresa>(this.baseURL, empresa)
    .pipe(take(3));
  }

  public salvarEmpresa(id: number, empresa: Empresa): Observable<Empresa> {
    return this.http.put<Empresa>(`${this.baseURL}/${id}`, empresa)
    .pipe(take(3));
  }

  public excluirEmpresa(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`)
    .pipe(take(3));
  }
}
