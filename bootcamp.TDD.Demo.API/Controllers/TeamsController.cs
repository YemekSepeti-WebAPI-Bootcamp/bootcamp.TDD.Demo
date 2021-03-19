using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp.TDD.Demo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp.TDD.Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        readonly TeamService _service;

        public TeamsController(IMongoDbSettings settings)
        {
            _service = new TeamService(settings);
        }
        [HttpGet]
        public ActionResult<List<Team>> Get()
        {
            return _service.GetAll();
        }
        [HttpGet("{id:length(24)}")]
        public ActionResult<Team> Get(string id)
        {
            return _service.GetSingle(id);
        }
        [HttpPost]
        public ActionResult<Team> Create(Team team) => _service.Create(team);
        [HttpPut("{id:length(24)}")]
        public IActionResult Update (string id, Team currentTeam)
        {
            var team = _service.GetSingle(id);
            if (team==null)
            {
                return NotFound();
            }
            _service.Update(id, currentTeam);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var team = _service.GetSingle(id);
            if (team == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return Ok();
        }
    }
}
