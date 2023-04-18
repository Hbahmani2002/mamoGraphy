import {ViewChild, TemplateRef , Component, OnInit } from '@angular/core';
import { AuthService } from '../core';
import { ColDef, RowHighlightPosition } from 'ag-grid-community';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatAlertComponent } from '../mat-alert/mat-alert.component';
import { SafeResourceUrl, DomSanitizer } from '@angular/platform-browser';
import { SpinnerService } from '../sppiner.service';
import swal from 'sweetalert2';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  
 
  accessToken = '';
  refreshToken = '';
  
  showSpinner=false;
 
  constructor(
    private spinnerService: SpinnerService,
    public sanitizer:DomSanitizer,
    private route: ActivatedRoute,
    private router: Router,
    public authService: AuthService,private dialog: MatDialog) {
      this.spinnerService.spinner$.subscribe((data: boolean) => {
        setTimeout(() => {
          this.showSpinner = data ? data : false;
        });
        console.log(this.showSpinner);
      });
  
    }
    
  ngOnInit(): void {
    this.accessToken = localStorage.getItem('access_token') ?? '';
    this.refreshToken = localStorage.getItem('refresh_token') ?? '';
   
  }
  
 
pad(num:number, size:number): string {
  let s = num+"";
  while (s.length < size) s = "0" + s;
  return s;
}

 


}

