import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';

import { environment } from 'src/assets/environments/environments';

import { Empresa } from '../models';


@Injectable()
export class CompanyService {
  baseURL = environment.apiURL + 'empresas/'
  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }

  public getCompanies(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(this.baseURL)
      .pipe(take(3));
  }

  public getCompanyById(id: number): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}${id}`)
    .pipe(take(3));
  }

  public getCompaniesByArg(argumento: string): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}${argumento}/argumento`)
    .pipe(take(3));
  }

  public getCompaniesActive(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}ativas`)
    .pipe(take(3));
  }

  public getCompaniesBranches(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(`${this.baseURL}filiais`)
    .pipe(take(3));
  }

  public getCompanyPattern(): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}matriz`)
    .pipe(take(3));
  }

  public createCompany(empresa: Empresa): Observable<Empresa> {
    return this.http.post<Empresa>(this.baseURL, empresa)
    .pipe(take(3));
  }

  public saveCompany(id: number, empresa: Empresa): Observable<Empresa> {
    return this.http.put<Empresa>(`${this.baseURL}${id}`, empresa)
    .pipe(take(3));
  }

  public deleteCompany(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${id}?empresaId=${id}`)
    .pipe(take(3));
  }
}
