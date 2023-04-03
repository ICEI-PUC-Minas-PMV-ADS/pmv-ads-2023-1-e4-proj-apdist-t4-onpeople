import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { map, Observable, ReplaySubject, take } from 'rxjs';

import { Users } from '../../models/Users';
import { Constants } from 'src/app/shared/models';

import { environment } from 'src/assets/environments';

@Injectable()

export class LoginLogoutService {

  public baseURL = environment.apiURL + "Users/";

  public userNull = {} as Users

  private rootCurrentUser = new ReplaySubject<Users>(1);
  public currentUser$ = this.rootCurrentUser.asObservable();

  constructor(private http: HttpClient) { }

  public logout(): void {
    localStorage.removeItem(Constants.LOCAL_STORAGE_NAME);
    this.rootCurrentUser.next(this.userNull);
    this.rootCurrentUser.complete();
  }

  public login(login: any): Observable<void> {
    return this.http
      .post<Users>(this.baseURL + "Login", login)
      .pipe(take(1),
        map((userLoged: Users) => {
        const user = userLoged;
        if (user)
          this.setCurrentUser(user);
      })
    );
  }

  public setCurrentUser(user: Users): void {
    localStorage.setItem(Constants.LOCAL_STORAGE_NAME, JSON.stringify(user));
    this.rootCurrentUser.next(user);
  }
}
