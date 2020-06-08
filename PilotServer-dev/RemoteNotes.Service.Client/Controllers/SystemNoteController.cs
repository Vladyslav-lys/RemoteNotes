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
    public class SystemNoteController
    {
        private ServiceEnvironment serviceEnvironment;
        private CancellationTokenSource cts;

        public SystemNoteController(ServiceEnvironment serviceEnvironment)
        {
            this.serviceEnvironment = serviceEnvironment;
        }
        public async Task<List<NoteDTO>> GetNotes(int accountId)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                var paramsToSend = new object[] { accountId };

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("getNotesByAccountId", paramsToSend, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<NoteDTO> notes = JsonConvert.DeserializeObject<List<NoteDTO>>(attachedObjectText);
                    return notes;
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

        public async Task<NoteDTO> EditNote(NoteDTO note)
        {
            try
            {
                this.cts = new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);

                var paramsToSend = new object[] { note };

                OperationStatusInfo operationStatusInfo =
                    await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>("editNoteById", paramsToSend, this.cts.Token);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    NoteDTO newNote = JsonConvert.DeserializeObject<NoteDTO>(attachedObjectText);
                    return newNote;
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
    }
}
