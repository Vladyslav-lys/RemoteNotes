using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.DeleteUserEvents;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.UseCases.User
{
    public class DeleteUserUseCase : IUseCase<DeleteUserRequestEvent, DeleteUserResponseEvent>
    {
        private readonly IRequestActivity<DeleteUserRequestEvent, DeleteUserResponseEvent, IUserRepository>
            deleteUser;

        public DeleteUserUseCase(IRequestActivity<DeleteUserRequestEvent, DeleteUserResponseEvent, IUserRepository> deleteUser)
        {
            this.deleteUser = deleteUser;
        }

        public DeleteUserResponseEvent Execute(DeleteUserRequestEvent request)
        {
            try
            {
               return deleteUser.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
