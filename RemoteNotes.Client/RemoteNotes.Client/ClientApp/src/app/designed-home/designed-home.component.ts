import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '../_services/authentication.service';
import {operationStatusInfo} from '../_models/operationStatusInfo';
import {Note} from '../_models/note';
import {User} from '../_models/user';
import {SignalRService} from '../_services/signalR.service';
import {HubConnectionState} from '@microsoft/signalr';
import {Router} from '@angular/router';

@Component({
  selector: 'app-designed-home',
  templateUrl: './designed-home.component.html',
  styleUrls: ['./designed-home.component.css']
})
export class DesignedHomeComponent implements OnInit {

	items:Note[];

  items2:Note[];

  //selected = { item: this.items[0], desc: '[default item]' };
  selected:any;
  
	constructor(
    private serviceClient: SignalRService,
    private authenticateService: AuthenticationService,
    private router: Router
	) {
	  /*if(localStorage.notes != null) {
		  this.items = localStorage.notes;

		  this.items2 = JSON.parse(localStorage.notes).map(i => ({ 
			  idx: i, 
			  id: i.id, 
			  title: i.title, 
			  text: i.text, 
			  account: i.account, 
			  ptime: i.publishTime, 
			  mtime: i.modifyTime, 
			  img: i.image}));

		  this.selected = { item: this.items[0], desc: '[default item]' };
	  }*/
  }
  
  ngOnInit(): void {
	  var user = JSON.parse(localStorage.currentUser);
	  this.getAccessPrifle(user);
	  this.getNotes(user);
	}

  /*async ngOnInit(): Promise<void> {

    if(this.serviceClient.hubConnection.state == HubConnectionState.Connected){
      await this.GetNotes();
    }
    else {
      setTimeout(async () => await this.GetNotes(), 500);
    }
  }*/

  getNotes(user:User) {
    var th = this;
    this.authenticateService.getNotesByAccountId(user.account.id)
      .subscribe(result => {
        var nts = result;
        for (let note of nts) {
          note.image = 'data:image/png;base64,' + note.image;
        }
        th.items = nts;
        console.log(th.items);
        localStorage.setItem("notes", JSON.stringify(nts));
        th.items2 = JSON.parse(localStorage.notes).map(i => ({
          idx: i,
          id: i.id,
          title: i.title,
          text: i.text,
          account: i.account,
          ptime: i.publishTime,
          mtime: i.modifyTime,
          img: i.image
        }));
      }, error => {
        console.log(error.error);
      });

    /*await this.authenticateService.getNotesByAccountId(user.account.id).then(function (operationStatus: operationStatusInfo){
      if (operationStatus.operationStatus == 1) {
        var nts = operationStatus.attachedObject;
        for (let note of nts){
          note.image = 'data:image/png;base64,' + note.image;
        }
        th.items = nts;
        console.log(th.items);
        localStorage.setItem("notes", JSON.stringify(nts));
		    th.items2 = JSON.parse(localStorage.notes).map(i => ({ 
			    idx: i, 
			    id: i.id, 
			    title: i.title, 
			    text: i.text, 
			    account: i.account, 
			    ptime: i.publishTime, 
			    mtime: i.modifyTime, 
			    img: i.image}));
        }
        else {
          console.log(operationStatus.attachedInfo);
          localStorage.setItem("notes", JSON.stringify(""));
          alert(operationStatus.attachedInfo);
        }
      }).catch(function(err) {
        console.log("Error loading notes");
        alert(err);
      });*/
  }
	
  getDesc(idx: number): Promise<string> {
    return new Promise(res => setTimeout(() => res(`${this.items[idx].title}!!`), 100));
  }

  random(): void {
    this.selected = {
      item: this.items[Math.floor(Math.random() * this.items.length)],
      desc: '[random item]'
    };
  }
  
  getAccessPrifle(user:User)
  {
	  if(user.accessLevel == 4)
	  {
		  this.authenticateService.setAccessProfile(true);
	  }
  }
}
