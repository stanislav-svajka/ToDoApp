import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ILoginForm} from "../models/ILoginForm";
import {Observable} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  login(login:ILoginForm){
    return this.http.post<string>('https://localhost:5001/api/user/login', login)
  }

  register(login:ILoginForm){
    return this.http.post<string>('https://localhost:5001/api/user/register', login)
  }

  logout(){
    localStorage.removeItem("token")
  }

  isLoggedIn() {
    return !!localStorage.getItem('token')
  }



}
