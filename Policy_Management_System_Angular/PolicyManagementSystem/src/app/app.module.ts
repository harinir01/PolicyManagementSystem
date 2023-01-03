import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ToastNotificationsModule } from 'ngx-toast-notifications';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreatepolicyComponent } from './createpolicy/createpolicy.component';
import { SearchpolicyComponent } from './searchpolicy/searchpolicy.component';
import { ViewpolicyComponent } from './viewpolicy/viewpolicy.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { PolicyformComponent } from './shared/policyform/policyform.component';
import { EditpolicyComponent } from './editpolicy/editpolicy.component';
import { ViewpolicyinformComponent } from './viewpolicyinform/viewpolicyinform.component';

@NgModule({
  declarations: [
    AppComponent,
    CreatepolicyComponent,
    SearchpolicyComponent,
    ViewpolicyComponent,
    PolicyformComponent,
    EditpolicyComponent,
    ViewpolicyinformComponent,
  ],
  imports: [
    BrowserModule,
    NgxPaginationModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastNotificationsModule.forRoot({duration: 6000, type: 'primary'})
  ],
  providers: [SearchpolicyComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
