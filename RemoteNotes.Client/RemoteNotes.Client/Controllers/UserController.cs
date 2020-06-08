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
    public class UserController : ControllerBase
    {
        private IServiceClient serviceClient;

        public UserController(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        [HttpPost("[action]")]
        public ActionResult<UserDTO> GetUser([FromBody]string[] datas)
        {
			try
            {
				UserDTO userDTO = serviceClient.Login(datas[0], datas[1]);
				return userDTO;
			}
            catch(AggregateException ax)
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

        [HttpGet("[action]")]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            try
            {
                List<UserDTO> usersDTO = serviceClient.GetAllUsers();
                return usersDTO;
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

        //[HttpPut("[action]/{id}/{login}/{password}/{isActive}/{accessLevel}")]
        //public ActionResult<UserDTO> UpdateUser(int id, string login, string password, bool isActive, short accessLevel, [FromBody] AccountDTO account)
        [HttpPut("[action]")]
        public ActionResult<UserDTO> UpdateUser([FromBody] UserDTO user)
        {
			try
            {
                //UserDTO user = new UserDTO { Id = id, Login = login, Password = password, IsActive = isActive, AccessLevel = accessLevel, Account = account };

                UserDTO userDTO = serviceClient.UpdateUserAsync(user);
				return userDTO;
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

        [HttpPost("[action]")]
        public ActionResult<UserDTO> AddUser([FromBody] UserDTO user)
        {
            try
            {
                UserDTO userDTO = serviceClient.RegistrationUser(user);
                return userDTO;
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

        [HttpDelete("[action]/{id}")]
        public ActionResult<bool> DeleteUser(int id)
        {
            try
            {
                bool isDeleted = serviceClient.DeleteUser(id);
                return isDeleted;
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
