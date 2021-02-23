import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UserDataService } from './_data-services/user.data-service';
import { Interceptor } from './app.interceptor.module';
import { AuthComponent } from './auth/auth.component';
import { AuthDataService } from './_data-services/auth.data-service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './modal/modal.component';
import { ToastComponent } from './toast/toast.component';
import { ToastService } from './_data-services/toast.data-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
    AuthComponent,
    ModalComponent,
    ToastComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AuthComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent }
    ]),
    Interceptor,
    NgbModule
  ],
  providers: [UserDataService, AuthDataService, ToastService],
  bootstrap: [AppComponent],
  entryComponents: [ModalComponent]
})
export class AppModule { }
