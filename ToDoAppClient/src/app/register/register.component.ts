import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginService} from "../../services/login.service";
import {Router} from "@angular/router";
import {ILoginForm} from "../../models/ILoginForm";
import {FormControl, Validators} from "@angular/forms";
import {MessageService} from "../../services/message.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
username:string=''
  password:string=''
  password2:string=''

  constructor(private loginService:LoginService,private router:Router, private message:MessageService) {
  }
  usernameForm = new FormControl('', {validators:[Validators.required,Validators.minLength(5)],updateOn:'change'});
  passwordForm = new FormControl('', [Validators.required,Validators.minLength(5)]);

  getErrorMessage() {
    if (this.usernameForm.hasError('required')) {
      return 'Username is required';
    }
    if(this.usernameForm.hasError("minlength")){
      return 'Username must have 5 letters at least';
    }
    return null
  }

  getPasswordErrors(){
    if(this.password!=this.password2)
      return 'Passwords doesnt match'

    if(this.passwordForm.hasError('Passwords doesnt match'))
    {
      return 'Wrong password'
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
    this.usernameForm.markAsUntouched()
    this.passwordForm.markAsUntouched()
    this.message.successMessage("Successfully registered")
  }

}
