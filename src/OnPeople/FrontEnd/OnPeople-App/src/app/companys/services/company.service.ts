import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, take } from 'rxjs';

import { Empresa } from '../models';

import { environment } from 'src/assets/environments/environments';

import { PaginatedResult } from 'src/app/shared/models/class/pages';

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
