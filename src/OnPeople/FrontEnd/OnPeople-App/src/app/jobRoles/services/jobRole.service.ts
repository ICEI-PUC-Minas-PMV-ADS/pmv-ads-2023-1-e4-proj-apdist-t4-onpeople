import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/assets/environments';
import { Cargo } from '../models/Cargo';
import { DashboardJobRole, PaginatedResult } from 'src/app/shared/models';
import { Observable, map, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobRoleService {

  baseURL = environment.apiURL + 'cargos/'
  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

constructor(private http: HttpClient) { }

  public getJobRoles(page?: number, itemsPage?: number, term?: string): Observable<PaginatedResult<Cargo[]>> {
    const paginatedResult: PaginatedResult<Cargo[]> = new PaginatedResult<Cargo[]>();

    let params = new HttpParams;

    if (page != null && itemsPage != null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPage.toString());
    };

    if (term != null && term != '') {
      params = params.append("term", term);
    }

    return this.http
      .get<Cargo[]>(this.baseURL, {observe: 'response', params})
      .pipe(take(3), map(
        (response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        }));
  }

  public getJobRoleById(id: number): Observable<Cargo> {
    return this.http.get<Cargo>(`${this.baseURL}${id}`)
    .pipe(take(3));
  }

  public getJobRoleByDepartmentId(departmentId: number): Observable<Cargo[]> {
    console.log("URL: " + `${this.baseURL}${departmentId}/cargos`)
    return this.http.get<Cargo[]>(`${this.baseURL}${departmentId}/cargos`)
    .pipe(take(3));
  }

  public createJobRole(cargo: Cargo): Observable<Cargo> {
    return this.http.post<Cargo>(this.baseURL, cargo)
    .pipe(take(3));
  }

  public saveJobRole(id: number, cargo: Cargo): Observable<Cargo> {
    return this.http.put<Cargo>(`${this.baseURL}${id}`, cargo)
    .pipe(take(3));
  }

  public deleteJobRole(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${id}?cargoId=${id}`)
    .pipe(take(3));
  }

  public CountJobRole(empresaId: number, departamentoId: number, cargoId: number ): Observable<DashboardJobRole> {
    return this.http.get<DashboardJobRole>(`${this.baseURL}${empresaId}/${departamentoId}/${cargoId}/Dashboard`)
    .pipe(take(3));
  }

}
