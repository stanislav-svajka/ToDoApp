import {Component, OnInit} from '@angular/core';
import {LoginService} from "../../services/login.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{

  isLoggedIn:boolean=false;

  constructor(private loginService:LoginService,private router:Router) {
  }

  ngOnInit(){
    if(localStorage.getItem("token")){
      this.isLoggedIn=true;
    }else
      this.isLoggedIn=false;
  }

  logout() {
    this.loginService.logout()
    this.router.navigateByUrl('/home')
  }
}
