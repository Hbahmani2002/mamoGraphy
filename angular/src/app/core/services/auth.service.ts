import { Injectable, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient,HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable, of, Subscription } from 'rxjs';
import { map, tap, delay, finalize } from 'rxjs/operators';
import { ApplicationUser } from '../models/application-user';
import { environment } from 'src/environments/environment';
import { ApplicationProtokol } from '../models/vsys_protokol';

interface LoginResult {
  username: string;
  role: string;
  originalUserName: string;
  accessToken: string;
  refreshToken: string;
}
interface RoleHastane {
  hastanename: string[];

}
interface ProtokolResult {
  BARkODKODU: string;
  ADI: string;
  SOYADI: string;
  PROTOKOL: string;
  KLINIK: string;
  DOKTOR: string;
  TARIH: Date;

}

@Injectable({
  providedIn: 'root',
})
export class AuthService implements OnDestroy {
  private readonly apiUrl = `${environment.apiUrl}api/account`;
  private readonly apiUrl1 = `${environment.apiUrl}api/enabiz`;
  private readonly apiUrl2 = `${environment.apiUrl}api/hasta`;
  
  private timer: Subscription | null = null;
  private _user = new BehaviorSubject<ApplicationUser | null>(null);
  private _protokol = new BehaviorSubject<ApplicationProtokol | null>(null);
  
  user$ = this._user.asObservable();

  private storageEventListener(event: StorageEvent) {
    if (event.storageArea === localStorage) {
      if (event.key === 'logout-event') {
        this.stopTokenTimer();
        this._user.next(null);
      }
      if (event.key === 'login-event') {
        this.stopTokenTimer();
        this.http.get<LoginResult>(`${this.apiUrl}/user`).subscribe((x) => {
          this._user.next({
            username: x.username,
            role: x.role,
            originalUserName: x.originalUserName,
          });
        });
      }
    }
  }

  constructor(private router: Router, private http: HttpClient) {
    window.addEventListener('storage', this.storageEventListener.bind(this));
  }

  ngOnDestroy(): void {
    window.removeEventListener('storage', this.storageEventListener.bind(this));
  }

  login(username: string, password: string) {
    return this.http
      .post<LoginResult>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        map((x) => {
          this._user.next({
            username: x.username,
            role: x.role,
            originalUserName: x.originalUserName,
          });
          this.setLocalStorage(x);
          this.startTokenTimer();
          return x;
        })
      );
  }
  
  
  
  
  HastaneRole(username:string) {
    return this.http
      .post<RoleHastane>(`${this.apiUrl}/HastaneRole`, {username})
      .pipe(
        map((x) => {
          // this._protokol.next({
          //   BARkODKODU: x.BARkODKODU,
          //   ADI: x.ADI,
          //   SOYADI: x.SOYADI,
          //   PROTOKOL: x.PROTOKOL,
          //   KLINIK: x.KLINIK,
          //   DOKTOR: x.DOKTOR,
          //   TARIH: x.TARIH,
            
          // });
          return x;
        })
      );
  }
 

  // getDoctorBranchEnumService(bastar: Date, bittar: Date){
  //   let model: any[] = [];
  //   return this.http
  //     .post<any>(`${this.apiUrl1}/Sorgula`, { bastar, bittar })
  //     .pipe(
  //       map((data) => {
  //         data.forEach((e) => {
  //           model.push({ 
  //             BARkODKODU: e.BARkODKODU, 
  //             ADI: e.ADI,
  //             SOYADI: e.SOYADI, 
  //             PROTOKOL: e.PROTOKOL,
  //             KLINIK: e.KLINIK, 
  //             DOKTOR: e.DOKTOR,
  //             UZMANLIK: e.UZMANLIK });
  //         });

  //         return model;
  //       })
  //     );
  // }
  logout() {
    this.http
      .post<unknown>(`${this.apiUrl}/logout`, {})
      .pipe(
        finalize(() => {
          this.clearLocalStorage();
          this._user.next(null);
          this.stopTokenTimer();
          this.router.navigate(['login']);
        })
      )
      .subscribe();
  }

  refreshToken(): Observable<LoginResult | null> {
    const refreshToken = localStorage.getItem('refresh_token');
    if (!refreshToken) {
      this.clearLocalStorage();
      return of(null);
    }

    return this.http
      .post<LoginResult>(`${this.apiUrl}/refresh-token`, { refreshToken })
      .pipe(
        map((x) => {
          this._user.next({
            username: x.username,
            role: x.role,
            originalUserName: x.originalUserName,
          });
          this.setLocalStorage(x);
          this.startTokenTimer();
          return x;
        })
      );
  }

  setLocalStorage(x: LoginResult) {
    localStorage.setItem('access_token', x.accessToken);
    localStorage.setItem('refresh_token', x.refreshToken);
    localStorage.setItem('username', x.username);
    localStorage.setItem('login-event', 'login' + Math.random());
  }
  clearLocalStorage() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    localStorage.removeItem('username');
    localStorage.setItem('logout-event', 'logout' + Math.random());
  }

  private getTokenRemainingTime() {
    const accessToken = localStorage.getItem('access_token');
    if (!accessToken) {
      return 0;
    }
    const jwtToken = JSON.parse(atob(accessToken.split('.')[1]));
    const expires = new Date(jwtToken.exp * 1000);
    return expires.getTime() - Date.now();
  }

  private startTokenTimer() {
    const timeout = this.getTokenRemainingTime();
    this.timer = of(true)
      .pipe(
        delay(timeout),
        tap({
          next: () => this.refreshToken().subscribe(),
        })
      )
      .subscribe();
  }

  private stopTokenTimer() {
    this.timer?.unsubscribe();
  }
}
