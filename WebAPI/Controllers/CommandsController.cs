using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Dtos;
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

        public readonly IMapper _mapper;

        //Since we added the service on the startup using MockCommanderRepo every time
        //we use ICommanderRepo, using dependency injection
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

    //GET api/commands/5
    [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id) { 
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            else 
            {
                return NotFound();
            }
            
    }
    }
}
