import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, take } from 'rxjs';

import { DadoPessoal } from 'src/app/models';

import { environment } from 'src/assets/environments';
@Injectable({
  providedIn: 'root'
})
export class PersonalDocumentsService {

  baseURL = environment.apiURL + 'dadosPessoais/';

  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }


  public getPersonalsDocuments(): Observable<DadoPessoal[]> {
    return this.http.get<DadoPessoal[]>(this.baseURL)
      .pipe(take(3));
  }

  public getPersonalDocumentById(personalDocumentId: number): Observable<DadoPessoal> {
    return this.http.get<DadoPessoal>(`${this.baseURL}${personalDocumentId}`)
      .pipe(take(3));
  }

  public getAllPersonalDocumentsByEmployeeId(employeeId: number): Observable<DadoPessoal[]> {
    return this.http.get<DadoPessoal[]>(`${this.baseURL}${employeeId}/funcionario`)
      .pipe(take(3));
  }

  public createPersonalDocument(personalDocumentId: DadoPessoal): Observable<DadoPessoal> {
    return this.http.post<DadoPessoal>(this.baseURL, personalDocumentId)
    .pipe(take(3));
  }

  public savePersonalDocument(personalDocumentId: number, personalDocument: DadoPessoal): Observable<DadoPessoal> {
    return this.http.put<DadoPessoal>(`${this.baseURL}${personalDocumentId}`, personalDocument)
    .pipe(take(3));
  }

  public deletePersonalDocument(personalDocumentId:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${personalDocumentId}?personalDocumentIdId=${personalDocumentId}`)
    .pipe(take(3));
  }
}
