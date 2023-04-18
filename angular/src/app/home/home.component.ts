import {ViewChild, TemplateRef ,Renderer2,ElementRef, Component, OnInit } from '@angular/core';
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
  username:any ='';
  hospitalname=''
  showSpinner=false;
 
  constructor(
    private renderer:Renderer2,
    private el:ElementRef,
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
      this.username = localStorage.getItem("username");
    }
    
  ngOnInit(): void {
    this.accessToken = localStorage.getItem('access_token') ?? '';
    this.refreshToken = localStorage.getItem('refresh_token') ?? '';
    this.HastaneRole();
   
  }
  
 ac(){

 }
 HastaneRole(){
  this.spinnerService.showSpinner();
 
  const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
  this.authService
    .HastaneRole(this.username).subscribe((resp) => {
             
      
         for(var i=0;i<resp.hastanename.length;i++)
         {
          const button = this.renderer.createElement('button');
    const buttonText = this.renderer.createText(resp.hastanename[i]);
    this.renderer.addClass(this.el.nativeElement, 'red');
    this.renderer.appendChild(button, buttonText);
    this.renderer.appendChild(this.el.nativeElement, button);
    //
    this.renderer.listen(button, 'click', () => {alert('hi');});
         };
          this.spinnerService.hideSpinner();
   
       
     
    });
}
pad(num:number, size:number): string {
  let s = num+"";
  while (s.length < size) s = "0" + s;
  return s;
}

 


}

