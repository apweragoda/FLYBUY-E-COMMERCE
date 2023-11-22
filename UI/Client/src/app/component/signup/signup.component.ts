import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationService } from 'src/app/services/notification.service';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  user!: object;
  errorMessage!: object;
  registerForm!: FormGroup;
  attemptToSubmit: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private notificationService: NotificationService,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onRegister(): void {
    this.attemptToSubmit = true;

    if (this.registerForm.valid) {
      this.authService.registerUser(this.registerForm.value).subscribe({
        next: (user: object) => {
          this.user = user;
          this.notificationService.showNotification(
            'success',
            'Regitered successfully !'
          );
          this.route.navigate(['/signin']);
        },
        error: (err: any) => (this.errorMessage = err),
      });
    }
  }

  isValid(field: string) {
    return (
      ((this.registerForm.get(field)?.dirty ||
        this.registerForm.get(field)?.touched) &&
        !this.registerForm.get(field)?.valid) ||
      (!this.registerForm.get(field)?.valid && this.attemptToSubmit)
    );
  }
}
