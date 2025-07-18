import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../_modules/account';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  constructor(private accountService: AccountService) { };

  loginForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl('')
  });
  handleSubmit() {
    this.loginForm.value
    this.accountService.register(this.loginForm.value);
  }
}
