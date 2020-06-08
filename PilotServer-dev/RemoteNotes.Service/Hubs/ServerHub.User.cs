using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RemoteNotes.BLL.Activities.Users.Request;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.BLL.DomainEvents.CreateUserEvents;
using RemoteNotes.BLL.DomainEvents.DeleteUserEvents;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.DomainEvents.GetNotesEvents;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;
using RemoteNotes.Service.Domain.Helpers;

namespace RemoteNotes.Service.Hubs
{
    public partial class ServerHub
    {
        public async Task<OperationStatusInfo> Login(string login, string password)
        {
            return await Task.Run(() =>
            {
                logger.Info($"Client {this.GetIpAddress()} entered Login method with params l:{login} p:{password}");

                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var enterRequest = new EnterRequestEvent(login, password);
                
                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<EnterRequestEvent, EnterResponseEvent>>().Execute(enterRequest);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> UpdateUser(object userToUpdate)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);

                var attachedObjectText = userToUpdate.ToString();
                var newUser = JsonConvert.DeserializeObject<UserDTO>(attachedObjectText);

                var editUserRequestEvent = new EditUserRequestEvent(newUser);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<EditUserRequestEvent, EditUserResponseEvent>>().Execute(editUserRequestEvent);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> getNotesByAccountId(int accountId)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var getNotesRequestEvent = new GetNotesRequestEvent(accountId);

                try
                {
                    var response = 
                        this.useCaseFactory.Create<IUseCase<GetNotesRequestEvent, GetNotesResponseEvent>>().Execute(getNotesRequestEvent);

                    operationStatusInfo.AttachedObject = response.NotesDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> editNoteById(object noteToUpdate)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);

                var attachedObjectText = noteToUpdate.ToString();
                var newNote = JsonConvert.DeserializeObject<NoteDTO>(attachedObjectText);

                var editNoteRequestEvent = new EditNoteRequestEvent(newNote);

                try
                {
                    var response = 
                        this.useCaseFactory.Create<IUseCase<EditNoteRequestEvent, EditNoteResponseEvent>>().Execute(editNoteRequestEvent);

                    operationStatusInfo.AttachedObject = response.NoteDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ActivateUser(int userId)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var changeUserStatusRequestEvent = new ChangeUserStatusRequestEvent(userId,true);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent>>().Execute(changeUserStatusRequestEvent);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> DeactivateUser(int userId)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var changeUserStatusRequestEvent = new ChangeUserStatusRequestEvent(userId, false);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent>>().Execute(changeUserStatusRequestEvent);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ChangeUserStatus(int userId, bool userStatus)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var changeUserStatusRequestEvent = new ChangeUserStatusRequestEvent(userId, userStatus);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent>>().Execute(changeUserStatusRequestEvent);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> RegistrationUser(UserDTO user)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var createUserRequestEvent = new CreateUserRequestEvent(user);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<CreateUserRequestEvent, CreateUserResponseEvent>>().Execute(createUserRequestEvent);

                    operationStatusInfo.AttachedObject = response.UserDTO;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> DeleteUser(int userId)
        {
            return await Task.Run(() =>
            {
                var operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                var deleteUserRequestEvent = new DeleteUserRequestEvent(userId);

                try
                {
                    var response =
                        this.useCaseFactory.Create<IUseCase<DeleteUserRequestEvent, DeleteUserResponseEvent>>().Execute(deleteUserRequestEvent);

                    operationStatusInfo.AttachedObject = response;

                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }
    }
}