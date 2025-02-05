import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5184';
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  isAuthenticated$ = this.isAuthenticatedSubject.asObservable();
  private user: User = new User;

  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('accessToken');
    this.isAuthenticatedSubject.next(!!token);
    this.http.get<User>(this.apiUrl + '/current-user', {headers: this.getHeaders()}).subscribe((response) => {this.user = response});
  }

  signUp(email: string, password: string): void {
    this.http.post<any>(this.apiUrl + '/register', { email, password }).subscribe((response) => {
      this.router.navigate(['/login']);
    });
  }

  signIn(email: string, password: string): void {
    this.http.post<any>(this.apiUrl + '/login', { email, password }).subscribe((response) => {
      this.storeTokens(response.accessToken, response.refreshToken);
      this.http.get<User>(this.apiUrl + '/current-user', {headers: this.getHeaders()}).subscribe((response) => {this.user = response, this.router.navigate(['/profile']);});
    });
  }

  logOut(): void {
    localStorage.clear();
    this.isAuthenticatedSubject.next(false);
    this.router.navigate(['/login']);
  }

  refreshAccessToken(): void {
    const refreshToken = localStorage.getItem('refreshToken');
    this.http.post<any>(this.apiUrl + '/refresh-token', { refreshToken }).subscribe((response) => {
      this.storeTokens(response.accessToken, response.refreshToken);
    });
  }

  getUserEmail(): string {
    return this.user.email;
  }

  getUserId(): string{
    console.log(this.user);
    return this.user.id;
  }

  private storeTokens(accessToken: string, refreshToken: string): void {
    localStorage.setItem('accessToken', accessToken);
    localStorage.setItem('refreshToken', refreshToken);
    this.isAuthenticatedSubject.next(true);
  }

  getAccessToken(): string | null {
    return localStorage.getItem('accessToken');
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  isAuthenticated(): boolean {
    return !!this.getAccessToken();
  }
  
  getHeaders(): HttpHeaders {
    return new HttpHeaders({
      Authorization: `Bearer ${this.getAccessToken()}`
    });
  }
}
