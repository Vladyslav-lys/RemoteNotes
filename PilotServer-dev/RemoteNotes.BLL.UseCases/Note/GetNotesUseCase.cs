using System;
using RemoteNotes.BLL.Contract.Activity;
using RemoteNotes.BLL.Contract.UseCase;
using RemoteNotes.BLL.DomainEvents.GetNotesEvents;
using RemoteNotes.DAL.Contract.Repository;

namespace RemoteNotes.BLL.UseCases.Note
{
    public class GetNotesUseCase : IUseCase<GetNotesRequestEvent, GetNotesResponseEvent>
    {
        //private IValidationActivity<EnterRequestEvent> loginValidationActivity;

        private readonly IRequestActivity<GetNotesRequestEvent, GetNotesResponseEvent, INoteRepository>
            getNotesByRequest;

        public GetNotesUseCase(
            IRequestActivity<GetNotesRequestEvent, GetNotesResponseEvent, INoteRepository> getNotesByRequest
        )
        {
            this.getNotesByRequest = getNotesByRequest;
        }

        public GetNotesResponseEvent Execute(GetNotesRequestEvent request)
        {
            try
            {
                return getNotesByRequest.Execute(request);
            }
            //catch (SystemEnterValidationException ex)
            //{
            //    throw new SystemEnterValidationException(ex.Message, ex);
            //}
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}