import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { Login } from '../../models/login.model';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { AuthService } from '../../services/login.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  //styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [HttpClientModule ,CommonModule, FormsModule, InputTextModule],
  providers: [MessageService, ConfirmationService]
})
export class LoginComponent implements OnInit {
  login: Login = {};
  token: any;

  constructor(private loginService: AuthService, private messageService: MessageService, private confirmationService: ConfirmationService, private router: Router) { }

  ngOnInit(): void {
    localStorage.clear();
  }

  Login() {
    if (this.login.username && this.login.password) {
      this.loginService.login(this.login.username, this.login.password).subscribe({
        next: (res) => {
          // this.loginService.login = this.login;
          console.log("Response from server:", res);
          // קבלת הטוקן מתוך התגובה
          if (res && res.token) {
            localStorage.setItem("token", res.token); // שמירת הטוקן ב-session storage
            const decodedToken: any = jwtDecode(res.token);
            console.log(decodedToken["role"]);
            localStorage.setItem("role", decodedToken["role"]);

             alert("התחברת בהצלחה!");

            this.router.navigate(['/shop']);
            // window.location.reload();
          }
          else {
            alert("שגיאה: לא התקבל טוקן מהשרת.");
          }
        },
        error: (err) => {
          // console.error("Error during login:", err);
          // טיפול במקרה של שגיאה מהשרת
          if (err.status === 401) {
            alert("אתה לא קיים במערכת, יש לבצע רישום.");
          }
          else {
            alert("שגיאה: לא ניתן להתחבר כרגע, נסה שוב מאוחר יותר.");
          }
        }
      })
    }
    this.login = {};
  }

  refreshPage() {
    window.location.reload();
  }

}


