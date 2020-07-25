using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {

        public CommanderContext _context { get; }
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;   
        }

        

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null) 
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing in our case of the sql server but in case we'll use other database it could be neccesary
        }
    }
}
