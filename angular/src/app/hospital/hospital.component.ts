import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']
})
export class HospitalComponent implements OnInit {

  constructor(private route: ActivatedRoute,  private router: Router) { }

  ngOnInit(): void {
  }
kanser(){

}
yonetim(){

}
change(){
  this.router.navigate(['/main']);
}
}
