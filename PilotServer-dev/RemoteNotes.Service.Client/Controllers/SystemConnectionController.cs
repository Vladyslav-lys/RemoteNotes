using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using RemoteNotes.Service.Client.Service;

namespace RemoteNotes.Service.Client.Controllers
{
    public class SystemConnectionController
    {
        private HubConnection hubConnection;
        private ServiceEnvironment serviceEnvironment;
        private CancellationTokenSource cts;

        public SystemConnectionController(ServiceEnvironment serviceSettings)
        {
            this.serviceEnvironment = serviceSettings;
        }

        public void Connect(string serviceUrl)
        {
            this.ConnectAsync(serviceUrl).Wait();
        }

        public async Task ConnectAsync(string serviceUrl)
        {
            try
            {
                string hubName = this.serviceEnvironment.HubName;
                string servicePathUrl = $"{serviceUrl}/{hubName}";

                this.hubConnection = new HubConnectionBuilder()
                    .WithUrl(servicePathUrl)
                    .Build();

                this.serviceEnvironment.Connection = hubConnection;

                hubConnection.Closed += this.HubConnectionOnClosed;

                ConfigureServerNotifications();
                
                this.cts = new CancellationTokenSource(this.serviceEnvironment.ConnectionTimeout);

                await hubConnection.StartAsync(this.cts.Token);
                Console.WriteLine("Connection started");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task HubConnectionOnClosed(Exception arg)
        {
            await this.hubConnection.StartAsync(this.cts.Token);
        }

        public async void Disconnect()
        {
            if (this.hubConnection != null)
            {
                if (this.hubConnection.State != HubConnectionState.Disconnected)
                {
                    await this.hubConnection.StopAsync();
                }
            }
        }

        public void ConfigureServerNotifications()
        {
            hubConnection.On<string>("Notify", (message) =>
            {
                System.Console.Write($"Received notification: {message}\r\n");
            });
        }
    }
}
