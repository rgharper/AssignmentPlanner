// import components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ClassComponent } from './class/class.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './interceptor/jwt.interceptor';

// import dialogs
import { ClassDialogComponent } from './class-dialog/class-dialog.component';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { RegisterDialogComponent } from './register-dialog/register-dialog.component';
import { AssignmentDialogComponent } from './assignment-dialog/assignment-dialog.component';

// angular import
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

// angular material imports
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { HomeComponent } from './home/home.component';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClassComponent,
    UserComponent,
    LoginComponent,
    HomeComponent,
    AssignmentDialogComponent,
    ClassDialogComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule, MatInputModule, MatButtonModule, ReactiveFormsModule, MatDividerModule, MatExpansionModule, MatListModule,
    MatTabsModule, MatCardModule, MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatDatepickerModule,
    MatButtonToggleModule, MatRadioModule, MatSelectModule,
  ],
  providers: [
    provideHttpClient(withInterceptors([JwtInterceptor,])),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
