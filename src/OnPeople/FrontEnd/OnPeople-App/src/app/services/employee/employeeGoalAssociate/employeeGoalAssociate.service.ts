import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FuncionarioMeta } from 'src/app/models';
import { DashboardEmployeeGoal } from 'src/app/shared/class/dashboard/DashboardEmployeeGoal';
import { environment } from 'src/assets/environments';

@Injectable({
  providedIn: 'root'
})
export class EmployeeGoalAssociateService {
  baseURL = environment.apiURL + 'funcionariosMetas/';

  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(
    private http: HttpClient
  ) { }

  public getEmployeeGoalByIds(employeeId: number, goalId: number): Observable<FuncionarioMeta> {
    return this.http.get<FuncionarioMeta>(`${this.baseURL}${employeeId}/${goalId}/funcionarioMeta`)
      .pipe(take(3));
  }

  public getGoalsByEmployeeId(employeeId: number): Observable<FuncionarioMeta[]> {
    return this.http.get<FuncionarioMeta[]>(`${this.baseURL}${employeeId}/metas`)
      .pipe(take(3));
  }
  public verifyGoalEmployeeExists(employeeId: number, goalId: number): Observable<boolean> {
    return this.http.get<boolean>(`${this.baseURL}${employeeId}/${goalId}/verifyExists`)
      .pipe(take(3));
  }

  public associateGoal(employeeGoal: FuncionarioMeta): Observable<FuncionarioMeta> {
    return this.http.post<FuncionarioMeta>(`${this.baseURL}`, employeeGoal)
      .pipe(take(3));
  }

  public saveGoal(id: number, employeeGoal: FuncionarioMeta): Observable<FuncionarioMeta> {
    return this.http.put<FuncionarioMeta>(`${this.baseURL}${id}`, employeeGoal)
    .pipe(take(3));
  }

  public countEmployeeGoal(employeeId: number): Observable<DashboardEmployeeGoal> {
    return this.http.get<DashboardEmployeeGoal>(`${this.baseURL}${employeeId}/Dashboard`)
    .pipe(take(3));
  }
}
