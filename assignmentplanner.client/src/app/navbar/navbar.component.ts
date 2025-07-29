import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { inject } from '@angular/core';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { RegisterDialogComponent } from '../register-dialog/register-dialog.component';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  readonly dialog = inject(MatDialog);
  openLogin() {
    this.dialog.open(LoginDialogComponent);
  }
  openRegister() {
    this.dialog.open(RegisterDialogComponent);
  }
  isLoggedIn() {
    return localStorage.getItem('token') !== null;
  }
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('name');
    window.location.reload();
  }

}
