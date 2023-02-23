import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginService} from "../../services/login.service";
import {Router} from "@angular/router";
import {ILoginForm} from "../../models/ILoginForm";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
username:string=''
  password:string=''
  password2:string=''

  constructor(private loginService:LoginService,private router:Router) {
  }
  usernameForm = new FormControl('', [Validators.required,Validators.minLength(5)]);
  passwordForm = new FormControl('', [Validators.required,Validators.minLength(5)]);

  getErrorMessage() {
    if (this.usernameForm.hasError('required')) {
      return 'Username must have 5 letters at least';
    }
    return null
  }

  getPasswordErrors(){
    if(this.password!=this.password2)
      return 'password doesnt match'

    if(this.passwordForm.hasError('passwords doesnt match'))
    {
      return 'wrong password'
    }
    return null
  }
  onRegister()
  {
    let obj={} as ILoginForm
    obj.username=this.username
    obj.password=this.password
    obj.password=this.password2
    if(this.password2===this.password)
    {
      this.loginService.register(obj).subscribe()
      console.log(obj)
    }
    console.log(obj)
    this.password=''
    this.password2=''
    this.username=''
  }

}
