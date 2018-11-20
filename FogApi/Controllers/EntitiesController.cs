using System.Collections.Generic;
using System.Linq;
using FogApi.Interfaces;
using FogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FogApi.Controllers
{
    public class EntitiesController : ControllerBase
    {
        private readonly IRepository _repo;

        public EntitiesController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Entity>> Get()
        {
            return _repo.GetEntities().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Entity> Get(int id)
        {
            var entity = _repo.GetEntity(id);
            if (entity == null)
                return NotFound();

            return entity;
        }
    }
}