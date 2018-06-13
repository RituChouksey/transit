import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { StationsComponent } from './stations/stations.component';
import { NavMenuComponent } from './navmenu/navmenu.component';

import { HttpInterceptorProviders } from './infrastructure/index';

@NgModule({
  declarations: [
    AppComponent,
    StationsComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'stations', pathMatch: 'full'},
      { path: 'stations', component: StationsComponent }])
  ],
  providers: [HttpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
