import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, take } from 'rxjs';
import { PaginatedResult } from 'src/app/shared/models';
import { environment } from 'src/assets/environments';
import { Funcionario } from '../models';

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
}
