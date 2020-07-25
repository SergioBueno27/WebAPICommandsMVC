using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace Commander.Controllers
{
    //api/commands it takes the name from controller name (CommandsController)
    [Route("api/[controller]")]
    //It could be
    //[Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        //Since we added the service on the startup using MockCommanderRepo every time
        //we use ICommanderRepo, using dependency injection
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands() {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

    //GET api/commands/5
    [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id) { 
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
    }
    }
}
