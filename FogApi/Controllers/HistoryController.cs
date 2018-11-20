using System.Collections.Generic;
using System.Linq;
using FogApi.Interfaces;
using FogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FogApi.Controllers
{
    public class HistoryController : ControllerBase
    {
        private readonly IRepository _repo;

        public HistoryController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<HistoryEntry>> Get()
        {
            return _repo.GetHistoryEntries().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<HistoryEntry> Get(int id)
        {
            var entry = _repo.GetHistoryEntry(id);
            if (entry == null)
                return NotFound();

            return entry;
        }
    }
}