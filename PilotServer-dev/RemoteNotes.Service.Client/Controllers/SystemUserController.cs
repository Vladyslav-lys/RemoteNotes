using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using RemoteNotes.Service.Client.Service;
using RemoteNotes.Service.Domain.DTO;
using RemoteNotes.Service.Domain.Helpers;

namespace RemoteNotes.Service.Client.Controllers
{
    public class SystemUserController
    {
        private ServiceEnvironment serviceEnvironment;
        private CancellationTokenSource cts;

        public SystemUserController(ServiceEnvironment serviceEnvironment)
        {
            this.serviceEnvironment = serviceEnvironment;
        }

        public async Task<UserDTO> Login(string login, string password)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                var paramsToSend = new object[] { login, password };

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("Login", paramsToSend, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO user = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return user;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeAsync<OperationStatusInfo>("GetAllUsers", this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<UserDTO> users = JsonConvert.DeserializeObject<List<UserDTO>>(attachedObjectText);
                    return users;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<UserDTO> RegistrationUser(UserDTO user)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("RegistrationUser", new object[] { user }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return newUser;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("DeleteUser", new object[] { userId }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return true;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO user)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("UpdateUser", new object[] { user }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return newUser;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<UserDTO> ActivateUser(int id)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("ActivateUser", new object[] { id }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return newUser;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<UserDTO> DeactivateUser(int id)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("DeactivateUser", new object[] { id }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return newUser;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<UserDTO> ChangeUserStatus(int id, bool status)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("ChangeUserStatus", new object[] { id , status }, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    UserDTO newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);
                    return newUser;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task Logout()
        {
            throw new NotImplementedException();
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                OperationStatusInfo operationStatusInfo = await this.serviceEnvironment.Connection.InvokeAsync<OperationStatusInfo>("Logout", this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exit operation cannot be performed. {ex.Message}", ex);
            }
        }
    }
}
