import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, take } from 'rxjs';

import { Endereco } from 'src/app/models';

import { environment } from 'src/assets/environments';



@Injectable({
  providedIn: 'root'
})
export class AddressService {

  baseURL = environment.apiURL + 'enderecos/';

  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer '
  });

  constructor(private http: HttpClient) { }


  public getAddresses(): Observable<Endereco[]> {
    return this.http.get<Endereco[]>(this.baseURL)
      .pipe(take(3));
  }

  public getAddressById(addressId: number): Observable<Endereco> {
    return this.http.get<Endereco>(`${this.baseURL}${addressId}`)
      .pipe(take(3));
  }

  public getAllAddressesByEmployeeId(employeeId: number): Observable<Endereco[]> {
    return this.http.get<Endereco[]>(`${this.baseURL}${employeeId}/funcionario`)
      .pipe(take(3));
  }

  public createAddress(address: Endereco): Observable<Endereco> {
    return this.http.post<Endereco>(this.baseURL, address)
    .pipe(take(3));
  }

  public saveAddress(addressId: number, address: Endereco): Observable<Endereco> {
    return this.http.put<Endereco>(`${this.baseURL}${addressId}`, address)
    .pipe(take(3));
  }

  public deleteSAddress(addressId:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${addressId}?addressId=${addressId}`)
    .pipe(take(3));
  }

  public getCEP(cep: string): Observable<any> {
    return this.http.get(`${this.baseURL}${cep}/json`)
  }
}

