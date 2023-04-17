import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, take } from 'rxjs';


import { environment } from 'src/assets/environments/environments';

import { Empresa } from '../models';
import { SetEmpresaActive } from '../models';

import { PaginatedResult } from 'src/app/shared/models';
import { DashboardCompany } from 'src/app/shared/models';

@Injectable()
export class CompanyService {
  baseURL = environment.apiURL + 'empresas/'
  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }

  public getCompanies(page?: number, itemsPage?: number, term?: string): Observable<PaginatedResult<Empresa[]>> {
    const paginatedResult: PaginatedResult<Empresa[]> = new PaginatedResult<Empresa[]>();

    let params = new HttpParams;

    if (page != null && itemsPage != null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPage.toString());
    };

    if (term != null && term != '') {
      params = params.append("term", term);
    }

    return this.http
      .get<Empresa[]>(this.baseURL, {observe: 'response', params})
      .pipe(take(3), map(
        (response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        }));
  }

  public getCompanyById(id: number): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}${id}`)
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

  public CountCompany(id: number): Observable<DashboardCompany> {
    return this.http.get<DashboardCompany>(`${this.baseURL}${id}/Dashboard`)
    .pipe(take(3));
  }

  public getCompanyByCnpjExternal(cnpj: string): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}${cnpj}/external`)
    .pipe(take(3));
  }

  public getCompanyByCnpj(cnpj: string): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}${cnpj}/internal`)
    .pipe(take(3));
  }
}
