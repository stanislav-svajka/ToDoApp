import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginService} from "../../services/login.service";
import {ILoginForm} from "../../models/ILoginForm";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  password: any;
  username: any;


  constructor(private loginService:LoginService, private router:Router) {
  }

  onSubmit() {
    let obj = {} as ILoginForm;
    obj.username = this.username;
    obj.password = this.password
    console.log(this.username,this.password)
    this.loginService.login(obj).subscribe(token => {
      if(token){
        localStorage.setItem('token',token)
        console.log('dobre')
        this.router.navigateByUrl("todo")
      }
      else{
        console.log('balamuta')
      }
    })
    console.log(obj)


  }
}
