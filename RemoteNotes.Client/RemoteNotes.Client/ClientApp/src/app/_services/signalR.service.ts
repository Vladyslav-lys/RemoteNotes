import { Injectable, Inject } from '@angular/core';
/*import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel
} from '@microsoft/signalr';*/
import { BehaviorSubject, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class SignalRService {
  connectionEstablished$ = new BehaviorSubject<boolean>(false);

  /*public hubConnection: HubConnection;

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }*/

  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.startConnection(http, baseUrl);
  }

  private startConnection(http: HttpClient, baseUrl: string) {

    http.get(baseUrl + 'api/Connection/GetConnect').subscribe(() => { console.log("Connected!"); },
      error => console.error(error));
  }
	
  /*private startConnection() {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      return;
    }

    this.hubConnection.start().then(
      () => {
        console.log('Hub connection started!');
        this.connectionEstablished$.next(true);
      },
      error => console.error(error)
    );
  }
	
  /*sendChatMessage(message: string) {
    this.hubConnection.invoke('SendMessage', message);
  }

  private createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('http://46.98.190.16:5001/ServerHub')
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on('Send', (data: any) => {
      console.log('data', data);
    });
  }*/
}
