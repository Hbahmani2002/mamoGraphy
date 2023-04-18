import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { CoreModule } from './core/core.module';
import { AgGridModule } from 'ag-grid-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DemoApisComponent } from './demo-apis/demo-apis.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAlertComponent } from './mat-alert/mat-alert.component';
import { SppinerComponent } from './sppiner/sppiner.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    DemoApisComponent,
    MatAlertComponent,
    SppinerComponent,
  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CoreModule,
    AppRoutingModule,
    AgGridModule,
    BrowserAnimationsModule,
    MatDialogModule
   
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
