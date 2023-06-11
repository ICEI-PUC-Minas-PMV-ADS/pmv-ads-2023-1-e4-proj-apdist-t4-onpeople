import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/assets/environments';

import { Observable, map, take } from 'rxjs';

import { Meta } from 'src/app/models';

import { DashboardMeta } from 'src/app/shared/class/dashboard';

import { PaginatedResult } from 'src/app/shared/class/paginator';

@Injectable({
  providedIn: 'root'
})
export class GoalService {

  baseURL = environment.apiURL + 'metas/'
  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

constructor(private http: HttpClient) { }

  public getGoals(page?: number, itemsPage?: number, term?: string): Observable<PaginatedResult<Meta[]>> {
    const paginatedResult: PaginatedResult<Meta[]> = new PaginatedResult<Meta[]>();

    let params = new HttpParams;

    if (page != null && itemsPage != null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPage.toString());
    };

    if (term != null && term != '') {
      params = params.append("term", term);
    }

    return this.http
      .get<Meta[]>(this.baseURL, {observe: 'response', params})
      .pipe(take(3), map(
        (response: any) => {
          paginatedResult.result = response.body;
          if (response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          return paginatedResult;
        }));
  }

  public getGoalById(id: number): Observable<Meta> {
    return this.http.get<Meta>(`${this.baseURL}${id}`)
    .pipe(take(3));
  }

  public getGoalByTipo(tipo: string): Observable<Meta[]> {
    console.log("URL: " + `${this.baseURL}${tipo}/cargos`)
    return this.http.get<Meta[]>(`${this.baseURL}${tipo}/tipo`)
    .pipe(take(3));
  }

  public createGoal(meta: Meta): Observable<Meta> {
    return this.http.post<Meta>(this.baseURL, meta)
    .pipe(take(3));
  }

  public saveGoal(id: number, meta: Meta): Observable<Meta> {
    return this.http.put<Meta>(`${this.baseURL}${id}`, meta)
    .pipe(take(3));
  }

  public deleteGoal(id:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${id}?metaId=${id}`)
    .pipe(take(3));
  }

  public CountGoal(empresaId: number): Observable<DashboardMeta> {
    return this.http.get<DashboardMeta>(`${this.baseURL}${empresaId}/Dashboard`)
    .pipe(take(3));
  }

}
