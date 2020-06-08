using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Client.Service;

namespace RemoteNotes.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private IServiceClient serviceClient;

        public ConnectionController(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        [HttpGet("[action]")]
        public IActionResult GetConnect()
        {
			try
            {
				//"http://46.98.190.16:5001"
				//"http://192.168.88.33:5001"
				serviceClient.Connect("http://194.107.230.233:5001");
				return Ok();
			}
			catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
