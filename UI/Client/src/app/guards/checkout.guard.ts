import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { CartService } from '../services/cart.service';

@Injectable({
  providedIn: 'root'
})
export class CheckoutGuard implements CanActivate {
  constructor(
    private cartService: CartService,
    private authService: AuthService,
    private route: Router,
    ){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let access = true;

    if(this.authService.isLoggedIn() && this.cartService.isCartEmpty()){
      return true;
    }
    else{
      this.route.navigate(['/signin']);
      return false;
    }
  }

}
