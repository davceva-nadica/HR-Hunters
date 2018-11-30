import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  selectedTab = {
    applicant: false,
    client: false,
    admin: true
  }

  authError;
  private authErrorStatusSub: Subscription;
  private roleStatusSub: Subscription;

  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit() {
    if (this.selectedTab === undefined) {
      this.selectedTab = {
        applicant: false,
        client: false,
        admin: true
      }
    }
    const role = this.authService.getRole();
    if (role) {
      if (!role.admin && (role.applicant || role.client)) {
        this.selectedTab = this.authService.getRole();
      } else {
        this.selectedTab = {
          applicant: false,
          client: false,
          admin: true
        }
      }
    }

    this.authErrorStatusSub = this.authService.getAuthErrorStatusListener().subscribe(error => {
      this.authError = error;
    })
  }

  loginForm = this.fb.group({
    email: ['', Validators.compose([Validators.required, Validators.minLength(6), Validators.maxLength(30), Validators.email])],
    password: ['', Validators.compose([Validators.required, Validators.minLength(8), Validators.maxLength(20)])]
  })

  onLogin() {

    if (this.loginForm.invalid) {
      return
    }
    this.authService.loginUser(
      this.loginForm.value.email,
      this.loginForm.value.password,
      null
    );
  }


  ngOnDestroy() {
    this.authErrorStatusSub.unsubscribe();
  }
}
