import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store'

import { AppComponent } from './app.component';
import { LoginComponent } from '../app/login/login.component';
import { AlertComponent } from './alert/alert.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AuthGuard } from './_services/auth.guard';
import { DesignedHomeComponent } from './designed-home/designed-home.component';
import { NoteComponent } from './note/note.component';
import { MasterDetailModule } from './master-detail/master-detail.module';
import { DetailComponent } from './master-detail/detail.component';
import { ProfileComponent } from './profile/profile.component';
import { LeftmenuComponent } from './leftmenu/leftmenu.component';
import { ProfileGuard } from './_services/profile.guard';
import { UsersComponent } from './users/users.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { FullProfileComponent } from './full-profile/full-profile.component';

@NgModule({
  declarations: [
    AppComponent,
	  LoginComponent,
    AlertComponent,
	  HeaderComponent,
    FooterComponent,
    DesignedHomeComponent,
    NoteComponent,
    DetailComponent,
    ProfileComponent,
    LeftmenuComponent,
    UsersComponent,
    SignUpComponent,
    FullProfileComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
	  ReactiveFormsModule,
    FormsModule,
    MasterDetailModule,
    StoreModule.forRoot({}, {}),
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'dhome', component: DesignedHomeComponent, canActivate: [AuthGuard] },
      { path: 'note/:id', component: NoteComponent, canActivate: [AuthGuard] },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard, ProfileGuard] },
      { path: 'register', component: SignUpComponent, canActivate: [AuthGuard, ProfileGuard] },
      { path: 'fullprofile/:id', component: FullProfileComponent, canActivate: [AuthGuard, ProfileGuard] },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
