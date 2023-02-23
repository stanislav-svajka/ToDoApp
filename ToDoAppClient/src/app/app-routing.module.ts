import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "./home/home.component";
import {TodoComponent} from "./todo/todo.component";
import {RegisterComponent} from "./register/register.component";
import {ServicesGuard} from "../services/auth/services.guard";

const routes:Routes=[
  {
    path:"",
    redirectTo:"home",
    pathMatch:"full"
  },
  {
    path:"home",
    component:HomeComponent
  },
  {
    path:"todo",
    component:TodoComponent,canActivate:[ServicesGuard]
  },
  {
    path:"register",
    component:RegisterComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
