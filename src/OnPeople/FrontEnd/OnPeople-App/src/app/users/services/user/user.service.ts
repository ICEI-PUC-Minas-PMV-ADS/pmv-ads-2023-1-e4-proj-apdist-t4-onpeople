import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { map, Observable, take } from 'rxjs';

import { environment } from 'src/assets/environments';

import { Users } from '../../models/Users';

import { LoginLogoutService } from '../login';


@Injectable()

export class UserService {
  public baseURL = environment.apiURL + "Users/";

  public userLoged = {} as Users;


  constructor(
      private http: HttpClient,
      private loginLogoutService: LoginLogoutService
    ) { }

  public createUser(model: any): Observable<void> {
    return this.http
      .post<Users>(this.baseURL + "CreateAccount", model)
      .pipe(take(1),
        map((userReturn: Users) => {
          const user = userReturn;
          if (user)
            this.loginLogoutService.setCurrentUser(user)
        })
      );
  }

  public getUserByUserName(): Observable<Users> {
    return this.http
      .get<Users>(this.baseURL + "getusername")
      .pipe(take(1));
  }

  public getUserById(id: number): Observable<Users> {
    return this.http
      .get<Users>(this.baseURL + `${id}`)
      .pipe(take(1));
  }

  public updateUser(model: Users): Observable<void> {
    return this.http
      .put<Users>(this.baseURL + 'updateuser', model)
      .pipe(take(1),
        map((user: Users) => {
          this.loginLogoutService.setCurrentUser(user);
        })
      );
  }

  public updateUserVisao(model: Users): Observable<any> {
    return this.http
      .put<Users>(this.baseURL + 'updateVisao', model)
      .pipe(take(1));
  }
}
