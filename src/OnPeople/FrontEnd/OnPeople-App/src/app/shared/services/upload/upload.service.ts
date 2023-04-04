import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Empresa } from 'src/app/companies/models/Empresa';
import { Observable, take } from 'rxjs';
import { environment } from 'src/assets/environments/environments';

import { Users } from 'src/app/users/models';



@Injectable()
export class UploadService {

  baseURL = environment.apiURL + 'Uploads/'

  constructor(private http: HttpClient) { }

  public saveLogoCompany(empresaId: number, file: File[]): Observable<Empresa> {
    const fileUpload = file[0] as File;
    const formData = new FormData();

    formData.append('file', fileUpload);

    return this.http
    .post<Empresa>(`${this.baseURL}upload-logo-company/${empresaId}`, formData)
    .pipe(take(1));
  }

  public saveUserPhoto(file: File[]): Observable<Users> {
    const fileUpload = file[0] as File;
    const formData = new FormData();

    formData. append('file', fileUpload);

    return this.http
    .post<Users>(`${this.baseURL}upload-user-photo`, formData)
    .pipe(take(1));
  }

}
