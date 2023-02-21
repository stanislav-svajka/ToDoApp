import {Component, OnInit} from '@angular/core';
import {LoginService} from "../../services/login.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  isLoggedIn:boolean=false;
  constructor(public loginService :LoginService) {
  }


  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.isLoggedIn=true;
    }else
      this.isLoggedIn=false;
  }
}
