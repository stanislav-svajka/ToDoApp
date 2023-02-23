import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {LoginService} from "../login.service";

@Injectable({
  providedIn: 'root'
})
export class ServicesGuard implements CanActivate {

  constructor(private login:LoginService, private router:Router) {
  }
  canActivate() {
    if (this.login.isLoggedIn()) {
      return true;
    }
    this.router.navigate(['home'])
    return false;
  }
}
