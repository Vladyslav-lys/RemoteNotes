using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.EditNoteEvents;
using RemoteNotes.BLL.Rules.Validation.Operation.Exceptions;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.UseCases.Note
{
    public class EditNoteUseCase : IUseCase<EditNoteRequestEvent, EditNoteResponseEvent>
    {
        private readonly IRequestActivity<EditNoteRequestEvent, EditNoteResponseEvent, INoteRepository>
            editNoteByRequest;

        private readonly IValidationActivity<EditNoteRequestEvent> editNoteValidationActivity;

        public EditNoteUseCase(
            IValidationActivity<EditNoteRequestEvent> editNoteValidationActivity,
            IRequestActivity<EditNoteRequestEvent, EditNoteResponseEvent, INoteRepository> editNoteByRequest
        )
        {
            this.editNoteValidationActivity = editNoteValidationActivity;
            this.editNoteByRequest = editNoteByRequest;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EditNoteResponseEvent Execute(EditNoteRequestEvent request)
        {
            try
            {
                editNoteValidationActivity.Validate(request);
                return editNoteByRequest.Execute(request);
            }
            catch (SystemEditNoteValidationException ex)
            {
                throw new SystemEditNoteValidationException(ex.Message, ex);
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