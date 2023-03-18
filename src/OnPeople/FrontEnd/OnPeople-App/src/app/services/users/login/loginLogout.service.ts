import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject, take } from 'rxjs';
import { UserLoged } from 'src/app/models/users/UserLoged';
import { environment } from 'src/assets/environments/environments';

@Injectable()

export class LoginLogoutService {

  public baseUrl = environment.apiURL + "Users/";

  public userNull = {} as UserLoged

  private rootCurrentUser = new ReplaySubject<UserLoged>(1);
  public currentUser$ = this.rootCurrentUser.asObservable();

  constructor(private http: HttpClient) { }

  public logout(): void {
    localStorage.removeItem('userLoged');
    this.rootCurrentUser.next(this.userNull);
    this.rootCurrentUser.complete();
  }

  public login(login: any): Observable<void> {
    return this.http
      .post<UserLoged>(this.baseUrl + "Login", login)
      .pipe(take(1),
        map((userLoged: UserLoged) => {
        const user = userLoged;
        if (user)
          this.setCurrentUser(user);
      })
    );
  }

  public setCurrentUser(user: UserLoged): void {
    localStorage.setItem("userLoged", JSON.stringify(user));
    this.rootCurrentUser.next(user);
  }
}
