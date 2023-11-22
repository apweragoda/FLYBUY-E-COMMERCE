import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  userAuthenticated!: boolean;
  constructor(private authService: AuthService, private route: Router) {}

  ngOnInit(): void {
    this.userAuthenticated = this.authService.isLoggedIn();
  }
  onLogout() {
    this.authService.logOutUser();
    console.log('User Logout!');
    this.route.navigate([this.route.url]);

  }
}


