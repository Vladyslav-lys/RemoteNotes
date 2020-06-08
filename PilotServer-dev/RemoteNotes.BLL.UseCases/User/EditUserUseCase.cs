using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.EditAccountEvents;
using RemoteNotes.BLL.DomainEvents.EditUserEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;
using RemoteNotes.DAL.Contract.Repository;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.UseCases.User
{
    public class EditUserUseCase : IUseCase<EditUserRequestEvent, EditUserResponseEvent>
    {
        private readonly IRequestActivity<EditAccountRequestEvent, EditAccountResponseEvent, IAccountRepository>
            editAccountByRequest;

        private readonly IRequestActivity<EditUserRequestEvent, EditUserResponseEvent, IUserRepository>
            editUserByRequest;

        private readonly IValidationActivity<EditUserRequestEvent> editUserValidationActivity;

        private readonly IValidationActivity<AccessLevelCheckEvent> accessLevelValidationActivity;

        public EditUserUseCase(
            IValidationActivity<EditUserRequestEvent> editUserValidationActivity,
            IRequestActivity<EditUserRequestEvent, EditUserResponseEvent, IUserRepository> editUserByRequest,
            IRequestActivity<EditAccountRequestEvent, EditAccountResponseEvent, IAccountRepository> editAccountByRequest,
            IValidationActivity<AccessLevelCheckEvent> accessLevelValidationActivity
        )
        {
            this.editUserValidationActivity = editUserValidationActivity;
            this.accessLevelValidationActivity = accessLevelValidationActivity;
            this.editAccountByRequest = editAccountByRequest;
            this.editUserByRequest = editUserByRequest;
        }

        public EditUserResponseEvent Execute(EditUserRequestEvent request)
        {
            try
            {
                accessLevelValidationActivity.Validate(new AccessLevelCheckEvent(request.User, DAL.Core.Entity.Enums.AccessLevel.Administrator));
                editUserValidationActivity.Validate(request);
                request.User.Account = editAccountByRequest.Execute(new EditAccountRequestEvent(request.User.Account)).AccountDTO;
                return editUserByRequest.Execute(request);
            }
            catch (SystemEditUserValidationException ex)
            {
                throw new SystemEditUserValidationException(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message, ex);
            }
            catch (OperationCanceledException ex)
            {
                throw new OperationCanceledException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}