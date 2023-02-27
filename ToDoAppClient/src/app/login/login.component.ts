import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginService} from "../../services/login.service";
import {ILoginForm} from "../../models/ILoginForm";
import {Router} from "@angular/router";
import {MessageService} from "../../services/message.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  password: any;
  username: any;


  constructor(private loginService:LoginService, private router:Router, private message:MessageService) {
  }

  onSubmit() {
    let obj = {} as ILoginForm;
    obj.username = this.username;
    obj.password = this.password
    console.log(this.username,this.password)
    this.loginService.login(obj).subscribe(token => {
      if(token){
        localStorage.setItem('token',token)
        localStorage.setItem('username',obj.username)
        console.log('dobre')
        this.router.navigateByUrl("todo")
        this.message.successMessage("Successfully loged in")
      }
      else{
        this.message.errorMessage("Wrong username or password")
      }
    })
    console.log(obj)


  }
}
