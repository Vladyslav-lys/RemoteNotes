using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.ChangeUserStatusEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.UseCases.User
{
    public class ChangeUserStatusUseCase : IUseCase<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent>
    {
        private readonly IRequestActivity<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent, IUserRepository> changeUserStatusByRequest;

        public ChangeUserStatusUseCase(IRequestActivity<ChangeUserStatusRequestEvent, ChangeUserStatusResponseEvent, IUserRepository> changeUserStatusByRequest)
        {
            this.changeUserStatusByRequest = changeUserStatusByRequest;
        }


        public ChangeUserStatusResponseEvent Execute(ChangeUserStatusRequestEvent request)
        {
            try
            {
                var response = changeUserStatusByRequest.Execute(request);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
