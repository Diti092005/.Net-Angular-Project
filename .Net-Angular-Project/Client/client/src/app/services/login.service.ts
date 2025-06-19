import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:5001/api/User';

  constructor(private http: HttpClient) { }

  // התחברות
  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.http.post(`${this.apiUrl}/login`, body);
  }

  // שמירת הטוקן והשם
  setSession(token: string, fullName: string) {
    localStorage.setItem('token', token);
    localStorage.setItem('fullName', fullName);
  }

  // שליפת הטוקן
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // שליפת fullName
  getFullName(): string | null {
    return localStorage.getItem('fullName');
  }

  // פענוח הטוקן
  getDecodedToken(): any {
    const token = this.getToken();
    if (token) {
      return jwtDecode(token);
    }
    return null;
  }

  // שליפת userId מתוך ה-token
  getUserId(): number | null {
    const decoded = this.getDecodedToken();
    return decoded ? +decoded.unique_name : null;
  }

  // שליפת role מתוך ה-token
  getUserRole(): string | null {
    const decoded = this.getDecodedToken();
    return decoded ? decoded.role : null;
  }

  // האם מנהל
  isManager(): boolean {
    return this.getUserRole() === 'Manager';
  }

  // האם מחובר
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // התנתקות
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('fullName');
  }
}
