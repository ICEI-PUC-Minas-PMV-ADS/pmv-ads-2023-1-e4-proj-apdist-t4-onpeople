import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, Observable, take } from 'rxjs';

import { environment } from 'src/assets/environments/environments';

import { DashboardDepartment } from 'src/app/shared/class/dashboard';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { Departamento } from 'src/app/models';

@Injectable()
export class DepartmentService {
  baseURL = environment.apiURL + 'departamentos/'

  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }

  public getDepartments(page?: number, itemsPage?: number, term?: string ): Observable<PaginatedResult<Departamento[]>> {
    const paginatedResult: PaginatedResult<Departamento[]> = new PaginatedResult<Departamento[]>();

    let params = new HttpParams;

    if (page != null && itemsPage != null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPage.toString());
    };

    if (term != null && term != '') {
      params = params.append("term", term);
    }

    return this.http
      .get<Departamento[]>(this.baseURL, {observe: 'response', params})
      .pipe(take(3), map(
        (response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        }));
  };

  public getDepartmentsByCompanyId(companyId: number): Observable<Departamento[]> {
    return this.http.get<Departamento[]>(`${this.baseURL}${companyId}/departamentos`)
    .pipe(take(3));
  }

  public getDepartmentById(departmentId: number): Observable<Departamento> {
    return this.http.get<Departamento>(`${this.baseURL}${departmentId}`)
    .pipe(take(3));
  }

  public createDepartment(department: Departamento): Observable<Departamento> {
    return this.http.post<Departamento>(this.baseURL, department)
    .pipe(take(3));
  }

  public saveDepartment(id: number, department: Departamento): Observable<Departamento> {
    return this.http.put<Departamento>(`${this.baseURL}${id}`, department)
    .pipe(take(3));
  }

  public deleteDepartment(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${id}?departamentoId=${id}`)
    .pipe(take(3));
  }

  public CountDepartment(companyId: number): Observable<DashboardDepartment> {
    return this.http.get<DashboardDepartment>(`${this.baseURL}${companyId}/Dashboard`)
    .pipe(take(3));
  }

}
