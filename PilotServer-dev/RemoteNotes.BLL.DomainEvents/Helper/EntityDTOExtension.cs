using System.Collections.Generic;
using AutoMapper;
using RemoteNotes.DAL.Core.Entity;
using RemoteNotes.Service.Domain.DTO;

namespace RemoteNotes.BLL.DomainEvents.Helper
{
    public static class EntityDTOExtension
    {
        private static readonly MapperConfiguration userToDTOConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<Account, AccountDTO>();
        });

        private static readonly MapperConfiguration accountToDTOConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Account, AccountDTO>();
        });

        private static readonly MapperConfiguration noteToDTOConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Note, NoteDTO>();
            cfg.CreateMap<Account, AccountDTO>();
        });

        private static readonly MapperConfiguration userToEntityConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, User>();
            cfg.CreateMap<AccountDTO, Account>();
        });

        private static readonly MapperConfiguration accountToEntityConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountDTO, Account>();
        });

        private static readonly MapperConfiguration noteToEntityConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<NoteDTO, Note>();
            cfg.CreateMap<AccountDTO, Account>();
        });

        public static UserDTO ToDTO(this User user)
        {
            var mapper = new Mapper(userToDTOConfig);
            return mapper.Map<UserDTO>(user);
        }

        public static AccountDTO ToDTO(this Account account)
        {
            var mapper = new Mapper(accountToDTOConfig);
            return mapper.Map<AccountDTO>(account);
        }

        public static NoteDTO ToDTO(this Note note)
        {
            var mapper = new Mapper(noteToDTOConfig);
            return mapper.Map<NoteDTO>(note);
        }

        public static User ToEntity(this UserDTO userDTO)
        {
            var mapper = new Mapper(userToEntityConfig);
            return mapper.Map<User>(userDTO);
        }

        public static Account ToEntity(this AccountDTO accountDTO)
        {
            var mapper = new Mapper(accountToEntityConfig);
            return mapper.Map<Account>(accountDTO);
        }

        public static Note ToEntity(this NoteDTO noteDTO)
        {
            var mapper = new Mapper(noteToEntityConfig);
            return mapper.Map<Note>(noteDTO);
        }

        public static List<NoteDTO> ToDTO(this List<Note> notes)
        {
            var mapper = new Mapper(noteToDTOConfig);
            return mapper.Map<List<NoteDTO>>(notes);
        }
    }
}