import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, take } from 'rxjs';


import { Funcionario } from 'src/app/models';
import { DashboardEmployee, DashboardEmployeeGoal } from 'src/app/shared/class/dashboard';
import { ListaMetas } from 'src/app/shared/class/dashboard/ListaMetas';

import { PaginatedResult } from 'src/app/shared/class/paginator';

import { environment } from 'src/assets/environments';



@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseURL = environment.apiURL + 'funcionarios/';

  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }


  public getEmployees(page?: number, itemsPage?: number, term?: string): Observable<PaginatedResult<Funcionario[]>> {
    const paginatedResult: PaginatedResult<Funcionario[]> = new PaginatedResult<Funcionario[]>();

    let params = new HttpParams;

    if (page != null && itemsPage != null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPage.toString());
    };

    if (term != null && term != '') {
      params = params.append("term", term);
    }

    return this.http
      .get<Funcionario[]>(this.baseURL, {observe: 'response', params})
      .pipe(take(3), map(
        (response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        }));
  }

  public getEmployeeById(id: number): Observable<Funcionario> {
    return this.http.get<Funcionario>(`${this.baseURL}${id}`)
      .pipe(take(3));
  }

  public createEmployee(funcionario: Funcionario): Observable<Funcionario> {
    return this.http.post<Funcionario>(this.baseURL, funcionario)
    .pipe(take(3));
  }

  public saveEmployee(id: number, funcionario: Funcionario): Observable<Funcionario> {
    return this.http.put<Funcionario>(`${this.baseURL}${id}`, funcionario)
    .pipe(take(3));
  }

  public deleteEmployee(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${id}?funcionarioId=${id}`)
    .pipe(take(3));
  }

  public getEmployeesBossesByDepartmentId(departmentId: number): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(`${this.baseURL}${departmentId}/chefes`)
      .pipe(take(3));
  }

  public getEmployeesByJobRoleId(jobRoleId: number): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(`${this.baseURL}${jobRoleId}/cargo`)
      .pipe(take(3));
  }

  public getDashEmployee(companyId: number, departmentId: number, jobRoleId: number, employeeId: number): Observable<DashboardEmployee> {
    return this.http.get<DashboardEmployee>(`${this.baseURL}${companyId}/${departmentId}/${jobRoleId}/${employeeId}/DashboardFuncionarios`)
    .pipe(take(3));
  }

  public getDashEmployeeGoals(companyId: number, departmentId: number, jobRoleId: number, employeeId: number): Observable<ListaMetas[]> {
    return this.http.get<ListaMetas[]>(`${this.baseURL}${companyId}/${departmentId}/${jobRoleId}/${employeeId}/DashboardFuncionarioMetas`)
    .pipe(take(3));
  }

  public getDashGoal(companyId: number, departmentId: number, jobRoleId: number, employeeId: number): Observable<DashboardEmployeeGoal> {
    return this.http.get<DashboardEmployeeGoal>(`${this.baseURL}${companyId}/${departmentId}/${jobRoleId}/${employeeId}/DashboardMetas`)
    .pipe(take(3));
  }
}
