import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, take } from 'rxjs';
import { UserLoged } from 'src/app/models/users/UserLoged';
import { Users } from 'src/app/models/users/Users';
import { environment } from 'src/assets/environments/environments';
import { LoginLogoutService } from '../login/loginLogout.service';

@Injectable()

export class UserService {
  public baseURL = environment.apiURL + "Users/";

  public userLoged = {} as UserLoged;


  constructor(
      private http: HttpClient,
      private loginLogoutService: LoginLogoutService
    ) { }

  public createUser(model: any): Observable<void> {
    console.log("Aqui")
    return this.http
      .post<UserLoged>(this.baseURL + "CreateAccount", model)
      .pipe(take(1),
        map((userReturn: UserLoged) => {
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

  public updateUser(model: UserLoged): Observable<void> {
    return this.http
      .put<UserLoged>(this.baseURL + 'updateuser', model)
      .pipe(take(1),
        map((user: UserLoged) => {
          this.loginLogoutService.setCurrentUser(user);
        })
      );
  }

  public updateUserVisao(model: UserLoged): Observable<any> {
    return this.http
      .put<UserLoged>(this.baseURL + 'updateVisao', model)
      .pipe(take(1));
  }
}
