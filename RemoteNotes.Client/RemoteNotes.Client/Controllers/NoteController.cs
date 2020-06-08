using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private IServiceClient serviceClient;

        public NoteController(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<IEnumerable<NoteDTO>> GetNotes(int id)
        {
            try
            {
                var notesDTO = serviceClient.GetNotes(id);
                return notesDTO;
            }
            catch (AggregateException ax)
            {
                var err = "";
                foreach (var errInner in ax.InnerExceptions)
                {
                    err = errInner.Message;
                }
                return BadRequest(err);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public ActionResult<NoteDTO> UpdateNote([FromBody] NoteDTO note)
        {
            try
            {
                NoteDTO noteDTO = serviceClient.EditNote(note);
                return noteDTO;
            }
            catch (AggregateException ax)
            {
                var err = "";
                foreach (var errInner in ax.InnerExceptions)
                {
                    err = errInner.Message;
                }
                return BadRequest(err);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
