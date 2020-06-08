using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.SignalR;
using RemoteNotes.BLL.Contract.UseCase;

namespace RemoteNotes.Service.Hubs
{
    public partial class ServerHub : Hub
    {
        /// <summary>
        ///     The connection collection. Stores the active connections.
        /// </summary>
        private static readonly List<string> connectionCollection = new List<string>();

        /// <summary>
        ///     The locker.
        /// </summary>
        private static readonly object locker = new object();

        private readonly LoggingService logger;

        private readonly IUseCaseFactory useCaseFactory;

        public ServerHub()
        {
            logger = DependencyConfiguration.Container.Resolve<LoggingService>();
            useCaseFactory = DependencyConfiguration.Container.Resolve<IUseCaseFactory>();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is user entered.
        /// </summary>
        protected virtual bool IsUserEntered => connectionCollection.Contains(Context.ConnectionId);

        /// <summary>
        ///     The add connection.
        /// </summary>
        /// <param name="connectionId">
        ///     The connection id.
        /// </param>
        private void AddConnection(string connectionId)
        {
            lock (locker)
            {
                if (!connectionCollection.Contains(connectionId)) connectionCollection.Add(connectionId);
            }
        }


        /// <summary>
        ///     The remove connection.
        /// </summary>
        /// <param name="connectionId">
        ///     The connection id.
        /// </param>
        private void RemoveConnection(string connectionId)
        {
            lock (locker)
            {
                if (connectionCollection.Contains(connectionId)) connectionCollection.Remove(connectionId);
            }
        }

        /// <summary>
        ///     The join group.
        /// </summary>
        /// <param name="groupName">
        ///     The group.
        /// </param>
        private void JoinGroup(string groupName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        /// <summary>
        ///     The leave group.
        /// </summary>
        /// <param name="groupName">
        ///     The group name.
        /// </param>
        private void LeaveGroup(string groupName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        private string GetIpAddress()
        {
            var ipAddress = Context.GetHttpContext().Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }

        public override Task OnConnectedAsync()
        {
            this.logger.Info($"Client {this.Context.ConnectionId} connected to the hub");
            return base.OnConnectedAsync();
        }
    }
}