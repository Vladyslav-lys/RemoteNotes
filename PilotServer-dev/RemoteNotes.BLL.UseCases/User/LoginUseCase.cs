using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.LoginEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.BLL.DomainEvents.Helper;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.UseCases.User
{
    public class LoginUseCase : IUseCase<EnterRequestEvent, EnterResponseEvent>
    {
        private readonly IRequestActivity<EnterRequestEvent, EnterResponseEvent, IUserRepository> getUserByRequest;
        private readonly IValidationActivity<EnterRequestEvent> loginValidationActivity;
        private readonly IValidationActivity<EnterResponseEvent> afterLoginValidationActivity;

        public LoginUseCase(
            IValidationActivity<EnterRequestEvent> loginValidationActivity,
            IRequestActivity<EnterRequestEvent, EnterResponseEvent, IUserRepository> getUserByRequest,
            IValidationActivity<EnterResponseEvent> afterLoginValidationActivity
        )
        {
            this.loginValidationActivity = loginValidationActivity;
            this.getUserByRequest = getUserByRequest;
            this.afterLoginValidationActivity = afterLoginValidationActivity;
        }

        /// <summary>
        ///     Execute activities needed to log into the system
        /// </summary>
        /// <param name="request">EnterRequestEvent</param>
        /// <returns>User</returns>
        public EnterResponseEvent Execute(EnterRequestEvent request)
        {
            try
            {
                loginValidationActivity.Validate(request);
                var response = getUserByRequest.Execute(request);
                afterLoginValidationActivity.Validate(response);
                return response;

            }
            catch (SystemEnterValidationException ex)
            {
                throw new SystemEnterValidationException(ex.Message, ex);
            }
            catch (MissingMemberException ex)
            {
                throw new MissingMemberException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}