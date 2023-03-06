import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Empresa } from 'src/app/models/empresas/Empresa';

@Injectable()
export class EmpresasService {
  baseURL = 'https://localhost:7282/api/empresas'

  constructor(private http: HttpClient) { }

  public getEmpresas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(this.baseURL);
  }

  public getEmpresaById(id: number): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}/${id}`);
  }

  public getEmpresasByArgumento(argumento: string): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/${argumento}/argumento`);
  }

  public getEmpresasAtivas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/ativas`);
  }

  public getEmpresasFiliais(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}/filiais`);
  }
}
