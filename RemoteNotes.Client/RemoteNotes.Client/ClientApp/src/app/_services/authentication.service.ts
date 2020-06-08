import { Injectable } from '@angular/core';
import { SignalRService } from './signalR.service';
import { User } from '../_models/user';
import { Note } from '../_models/note';
import { HttpParams } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    constructor(
      private serviceClient: SignalRService
    ) {
    }

    public getAuth(): boolean {
      var result: boolean;
      if(sessionStorage.getItem('isLoggedIn') != null)
        result = JSON.parse(sessionStorage.isLoggedIn);
      else
        result = false;
      return result;
    }

    public setAuth(value: boolean){
      sessionStorage.setItem('isLoggedIn', JSON.stringify(value));
    }
	
	public getAccessProfile(): boolean {
      var result: boolean;
      if(sessionStorage.getItem('isAllowedProfile') != null)
        result = JSON.parse(sessionStorage.isAllowedProfile);
      else
        result = false;
      return result;
    }

    public setAccessProfile(value: boolean){
      sessionStorage.setItem('isAllowedProfile', JSON.stringify(value));
    }

    login(username, password, serviceClient = this.serviceClient) {
      var th = this;
      return serviceClient.http.post<User>(serviceClient.baseUrl + 'api/User/GetUser/', [username, password]);

        /*return new Promise(function (resolve, reject) {
          serviceClient.hubConnection.invoke("Login", username, password)
            .then(function (operationStatus) {
              resolve(operationStatus);
            }).catch(function (err) {
              reject(err);
          });
      });*/
    }

  getAllUsers(serviceClient = this.serviceClient) {
    return serviceClient.http.get<User[]>(serviceClient.baseUrl + 'api/User/GetAllUsers/');
  }

  addUser(user, serviceClient = this.serviceClient) {
    return serviceClient.http.post<User>(serviceClient.baseUrl + 'api/User/AddUser/', user);
  }

  deleteUser(id, serviceClient = this.serviceClient) {
    return serviceClient.http.delete(serviceClient.baseUrl + 'api/User/DeleteUser/' + id);
  }

  getNotesByAccountId(AccountId, serviceClient = this.serviceClient) {
    return serviceClient.http.get<Note[]>(serviceClient.baseUrl + 'api/Note/GetNotes/' + AccountId);
    /*return new Promise(function (resolve, reject) {
      serviceClient.hubConnection.invoke("getNotesByAccountId", AccountId)
        .then(function (operationStatus) {
          resolve(operationStatus);
        }).catch(function (err) {
        reject(err);
      });
    });*/
  }

  editNote(note, serviceClient = this.serviceClient) {
	  /*return new Promise(function (resolve, reject) {
      serviceClient.http.put<Note>(serviceClient.baseUrl + 'api/Note/UpdateNote/', note)
      .toPromise()
        .then(function (note) {
          resolve(note);
        })
		.catch(function (err) {
        reject(err);
      });
    });*/
	
    return serviceClient.http.put<Note>(serviceClient.baseUrl + 'api/Note/UpdateNote/', note);
    /*return new Promise(function (resolve, reject) {
      serviceClient.hubConnection.invoke("editNoteById", note)
        .then(function (operationStatus) {
          resolve(operationStatus);
        }).catch(function (err) {
        reject(err);
      });
    });*/
  }

  invokeUpdateAccountInfo(user, serviceClient = this.serviceClient) {
    //const account = new HttpParams()
    //  .set('id', user.account.id)
    //  .set('createTime', user.account.createTime)
    //  .set('modifyTime', user.account.modifyTime)
    //  .set('photo', user.account.photo)
    //  .set('firstName', user.account.firstName)
    //  .set('lastName', user.account.lastName)
    //  .set('nickname', user.account.nickname)
    //  .set('birthday', user.account.birthday)
    //  .set('email', user.account.email);
    /*const body = new HttpParams()
      .set('id', user.id)
      .set('account', user.account.toString())
      .set('login', user.login)
      .set('password', user.password)
      .set('isActive', user.isActive)
      .set('accessLevel', user.accessLevel);
    console.log("body:   " + body.toString());*/

    return serviceClient.http.put<User>(serviceClient.baseUrl + 'api/User/UpdateUser/', user);
    /*return serviceClient.http.put<User>(serviceClient.baseUrl + 'api/User/UpdateUser/'
      + user.id + '/'
      + user.login + '/'
      + user.password + '/'
      + user.isActive + '/'
      + user.accessLevel + '/', user.account);*/
    /*return new Promise(function (resolve, reject) {
      serviceClient.http.put<User>(serviceClient.baseUrl + 'api/User/UpdateUser/', user)
        .toPromise()
        .then(function (operationStatus) {
            resolve(operationStatus);
          }).catch(function (err) {
            reject(err);
          });
      });*/
  }

    logout() {
        this.setAuth(false);
    }
}
