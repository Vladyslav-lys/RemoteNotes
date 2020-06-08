import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { operationStatusInfo } from '../_models/operationStatusInfo';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[];

  users2: User[];

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder
  ) {
  }

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    var th = this;
    this.authenticationService.getAllUsers()
      .subscribe(result => {
        var users = result;
        for (let user of users) {
          user.account.photo = 'data:image/png;base64,' + user.account.photo;
        }
        th.users = users;
        console.log(th.users);
        localStorage.setItem("users", JSON.stringify(users));
        th.users2 = JSON.parse(localStorage.users).map(i => ({
          idx: i,
          id: i.id,
          account: i.account,
          login: i.login,
          password: i.password,
          isActive: i.isActive,
          accessLevel:i.accessLevel
        }));
      }, error => {
        console.log(error.error);
      });
  }

  getAccessLevel(accessLevel) {
    var s = "";

    switch (accessLevel) {
      case 1:
        s = "Guest";
        break;
      case 2:
        s = "Student";
        break;
      case 3:
        s = "Teacher";
        break;
      case 4:
        s = "Administrator";
        break;
    }

    return s;
  }

  getActive(isActive) {
    var s = "";

    switch (isActive) {
      case true:
        s = "Active";
        break;
      case false:
        s = "Banned";
        break;
    }

    return s;
  }

  openEdit(user) {
    this.router.navigate(['/fullprofile/:id']);
  }

  deleteUser(user) {
    var th = this;
    this.authenticationService.deleteUser(user.id)
      .subscribe(result => {
        console.log(result);
        if (result)
          window.location.reload();
      }, error => {
        console.log(error.error);
        alert(error.error);
      });
  }

  openAdd() {
    this.router.navigate(['/register']);
  }
}
