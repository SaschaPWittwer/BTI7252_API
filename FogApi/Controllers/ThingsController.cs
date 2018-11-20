using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FogApi.Models;
using FogApi.Interfaces;
using System.Linq;

namespace FogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly IRepository _repo;

        public ThingsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Thing>> Get()
        {
            return _repo.GetThings().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Thing> Get(int id)
        {
            var thing = _repo.GetThing(id);
            if (thing == null)
                return NotFound();

            return thing;
        }
    }
}