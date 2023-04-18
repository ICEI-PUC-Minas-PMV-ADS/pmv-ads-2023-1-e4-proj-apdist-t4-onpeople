

import { Meta } from '../models/Meta';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable(
  // {providedIn: 'root'}
  )
export class MetaService {

  baseURL = 'https://localhost:5001/api/metas';

  constructor(private http: HttpClient) { }

  public getMetas(): Observable<Meta[]> {
    return this.http.get<Meta[]>(this.baseURL);
  }

  public getMetasByNome(nome: string): Observable<Meta[]> {
    return this.http.get<Meta[]>(`${this.baseURL}/${nome}/nome`);
  }

  public getMetaById(id: number): Observable<Meta> {
    return this.http.get<Meta>(`${this.baseURL}/${id}`);
  }

}
