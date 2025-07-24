import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ClassComponent } from './class/class.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
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
import { AssignmentDialogComponent } from './assignment-dialog/assignment-dialog.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ClassDialogComponent } from './class-dialog/class-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClassComponent,
    UserComponent,
    LoginComponent,
    HomeComponent,
    AssignmentDialogComponent,
    ClassDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule, MatInputModule, MatButtonModule, ReactiveFormsModule, MatDividerModule, MatExpansionModule, MatListModule,
    MatTabsModule, MatCardModule, MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MatDatepickerModule,
  ],
  providers: [
    provideHttpClient(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
