import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Empresa } from 'src/app/models/empresas/Empresa';
import { Observable, take } from 'rxjs';
import { environment } from 'src/assets/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class UploadsService {

  baseURL = environment.apiURL + 'Uploads/'

  constructor(private http: HttpClient) { }

  public salvarLogoEmpresa(empresaId: number, file: File[]): Observable<Empresa> {
    const arquivoUpload = file[0] as File;
    const formData = new FormData();

    formData. append('file', arquivoUpload);

    return this.http
    .post<Empresa>(`${this.baseURL}upload-logo-empresa/${empresaId}`, formData)
    .pipe(take(1));
  }

}
