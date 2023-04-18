import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../core';
import { finalize } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { SpinnerService } from '../sppiner.service';
import swal from 'sweetalert2';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  busy = false;
  username = '';
  password = '';
  loginError = false;
  showSpinner=false;
  private subscription: Subscription | null = null;

  constructor(
    private spinnerService: SpinnerService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {
    this.spinnerService.spinner$.subscribe((data: boolean) => {
      setTimeout(() => {
        this.showSpinner = data ? data : false;
      });
      console.log(this.showSpinner);
    });
  }

  ngOnInit(): void {
    this.subscription = this.authService.user$.subscribe((x) => {
      if (this.route.snapshot.url[0].path === 'login') {
        const accessToken = localStorage.getItem('access_token');
        const refreshToken = localStorage.getItem('refresh_token');
        if (x && accessToken && refreshToken) {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
          this.router.navigate([returnUrl]);
        }
      } // optional touch-up: if a tab shows login page, then refresh the page to reduce duplicate login
    });
  }

  login() {
    if (!this.username || !this.password) {
      return;
    }
    // this.username='my'
    // this.password='AAECAwQFBgcICQoLDA0ODwABAgMEBQYHCAkKCwwNDg94Tkvelcio+LBjGPrNuMaD'
    this.busy = true;
    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';

    this.authService
      .login(this.username, this.password)
      .pipe(finalize(() => (this.busy = false)))
      .subscribe(
        () => {
          this.router.navigate(['/main']);
         
        },
        () => {
         
          this.loginError = true;
          if(this.loginError)
          swal.fire({ icon: 'error',
      title: 'Hata',
      text: "kullanıcı adı veya şifre hatalı lütfen tekrar deneyiniz!!!!!!",})   
        }
      );
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}
