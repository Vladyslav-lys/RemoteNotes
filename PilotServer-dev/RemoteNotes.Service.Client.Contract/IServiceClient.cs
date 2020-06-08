using RemoteNotes.Service.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Client.Contract
{
    public interface IServiceClient
    {
        void Connect(string address);
        Task ConnectAsync(string address);
        void Disconnect();

        UserDTO Login(string login, string password);
        List<UserDTO> GetAllUsers();
        Task Logout();
        UserDTO RegistrationUser(UserDTO user);

        UserDTO ActivateUser(int userId);
        UserDTO DeactivateUser(int userId);
        bool DeleteUser(int userId);
        UserDTO ChangeUserStatus(int userId, bool userStatus);
        
        UserDTO UpdateUserAsync(UserDTO user);
        List<NoteDTO> GetNotes(int accountId);
        NoteDTO EditNote(NoteDTO note);
    }
}
