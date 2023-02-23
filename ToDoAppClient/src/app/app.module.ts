import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';

import {RouterLink, RouterOutlet} from "@angular/router";
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { TodoComponent } from './todo/todo.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatFormFieldControl, MatFormFieldModule} from "@angular/material/form-field";
import {MatCardModule} from "@angular/material/card";
import {FooterComponent} from "./footer/footer.component";
import {BannerComponent} from "./banner/banner.component";
import { EditTaskComponent } from './edit-task/edit-task.component';
import {MatDialogModule} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import { RegisterComponent } from './register/register.component';
import {MatSnackBarModule} from "@angular/material/snack-bar";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BannerComponent,
    HomeComponent,
    LoginComponent,
    TodoComponent,
    EditTaskComponent,
    RegisterComponent,
  ],
    imports: [
        BrowserModule,
        RouterOutlet,
        RouterLink,
        FormsModule,
        HttpClientModule,
        MatInputModule,
        MatIconModule,
        BrowserAnimationsModule,
        MatIconModule,
        MatCheckboxModule,
        MatCardModule,
        MatDialogModule,
        MatButtonModule,
        MatSnackBarModule,
        ReactiveFormsModule,
      AppRoutingModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
