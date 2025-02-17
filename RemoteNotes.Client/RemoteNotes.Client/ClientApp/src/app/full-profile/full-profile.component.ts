import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { User } from '../_models/user';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { operationStatusInfo } from '../_models/operationStatusInfo';
import { Account } from '../_models/accounts';

@Component({
  selector: 'app-full-profile',
  templateUrl: './full-profile.component.html',
  styleUrls: ['./full-profile.component.css']
})
export class FullProfileComponent implements OnInit {
  /*file: File;
  fileName: string = "Choose file";*/
  fileInBase64: any;
  profileForm: FormGroup;
  currentUserId: number;
  currentUser: User;
  currentPhoto: any;
  loading = false;
  submitted = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder
  ) {
    this.router.events.subscribe(
      (event) => {
        if (event instanceof NavigationEnd) {
          this.route
            .queryParams
            .subscribe(params => {
              // Defaults to 0 if no query param provided.
              this.currentUserId = +this.route.snapshot.paramMap.get('id');
              this.LoadUserInfo(this.currentUserId);
            });
        }
      });
  }

  ngOnInit(): void {
    this.currentUser.account.birthday = new Date(this.currentUser.account.birthday);
    this.fileInBase64 = this.currentUser.account.photo;

    this.profileForm = this.formBuilder.group({
      username: [this.currentUser.login, Validators.required],
      password: [this.currentUser.password, Validators.required],
      lastName: [this.currentUser.account.lastName, Validators.required],
      firstName: [this.currentUser.account.firstName, Validators.required],
      nickName: [this.currentUser.account.nickname, Validators.required],
      email: [this.currentUser.account.email, Validators.required],
      birthday: [this.currentUser.account.birthday, Validators.required],
      accessLevel: [this.currentUser.accessLevel],
      active: [this.currentUser.isActive]
    });
  }

  onFileChanged(event) {
    var registerComponent = this;
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];

      var fr = new FileReader();
      fr.onload = function () {
        var split1 = fr.result.toString().split(":", 2);
        var split2 = split1[1].split(";", 2);

        registerComponent.currentPhoto = fr.result.toString();
        registerComponent.fileInBase64 = fr.result.toString();
      }
      fr.readAsDataURL(file);
    }
  }

  LoadUserInfo(currentUserId: number) {
    var th = this;
    var users = JSON.parse(localStorage.users);
    users.forEach(function (user: User) {
      if (user.id == currentUserId) {
        th.currentUser = user;
        th.currentPhoto = user.account.photo;
        console.log(user);
      }
    });
  }

  EditProfile() {

    this.submitted = true;

    if (this.profileForm.invalid || this.currentPhoto.length < 24) {
      return;
    }

    this.loading = true;

    var newUser: User;
    newUser = this.currentUser;

    if (this.profileForm.controls.username.value != null)
      newUser.login = this.profileForm.controls.username.value;
    if (this.profileForm.controls.password.value != null)
      newUser.password = this.profileForm.controls.password.value;
    if (this.profileForm.controls.lastName.value != null)
      newUser.account.lastName = this.profileForm.controls.lastName.value;
    if (this.profileForm.controls.firstName.value != null)
      newUser.account.firstName = this.profileForm.controls.firstName.value;
    if (this.profileForm.controls.nickName.value != null)
      newUser.account.nickname = this.profileForm.controls.nickName.value;
    if (this.profileForm.controls.email.value != null)
      newUser.account.email = this.profileForm.controls.email.value;
    if (this.profileForm.controls.birthday.value != null)
      newUser.account.birthday = this.profileForm.controls.birthday.value;
    if (this.profileForm.controls.accessLevel.value != null)
      newUser.accessLevel = this.profileForm.controls.accessLevel.value;
    if (this.profileForm.controls.active.value != null)
      newUser.isActive = this.profileForm.controls.active.value;
    if (this.fileInBase64 != null) {
      var splitted = this.fileInBase64.split(",", 2);
      newUser.account.photo = splitted[1];
    }
    newUser.account.modifyTime = new Date();

    /*console.log(newUser);
    return;*/

    var th = this;
    this.authenticationService.invokeUpdateAccountInfo(newUser)
      .subscribe(result => {
        var message = "User info updated successfully";
        console.log(message);
        alert(message);
        th.router.navigate(['/users']);
      }, error => {
        console.log(error.error);
        alert(error.error);
        th.loading = false;
      });

    /*this.authenticationService.invokeUpdateAccountInfo(newUser)
      .then(function (operationStatus: operationStatusInfo) {
        if (operationStatus.operationStatus == 1) {
          var message = "User info updated successfully";
          console.log(message);
          alert(message);
          th.router.navigate(['/users']);
        }
        else {
          alert(operationStatus.attachedInfo);
        }
      }).catch(function (err) {
        console.log("Error while updating user info");
        alert(err);
      });*/
  }

  enableBtn(): boolean {
    if (this.currentPhoto.length > 24 && this.profileForm.controls.username.value.length > 0 && this.profileForm.controls.password.value.length > 0
      && this.profileForm.controls.lastName.value.length > 0 && this.profileForm.controls.firstName.value.length > 0
      && this.profileForm.controls.nickName.value.length > 0 && this.profileForm.controls.email.value.length > 0
      && this.profileForm.controls.birthday.value != null)
      return true;
    return false;
  }
}
