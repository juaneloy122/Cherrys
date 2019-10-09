using System;
using System.Collections.Generic;
using System.Linq;
using KQ.Service.Models;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KQ.CommonLib.Models.Incidencia;

namespace KQ.Service.Controllers
{
    [Route("api/incidencia")]
    [ApiController]
    public class IncidenciaController : ControllerBase
    {
        private readonly IItemRepository<Incidencia> ItemRepository;

        public IncidenciaController(IItemRepository<Incidencia> itemRepository)
        {
            ItemRepository = itemRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Incidencia>> List()
        {
            return ItemRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Incidencia> GetItem(int id)
        {
            Incidencia item = ItemRepository.Get(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Incidencia> Create([FromBody]Incidencia item)
        {
            ItemRepository.Add(item);
            return CreatedAtAction(nameof(GetItem), new { item.Id }, item);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Incidencia item)
        {
            try
            {
                ItemRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            Incidencia item = ItemRepository.Remove(id);

            if (item == null)
                return NotFound();

            return Ok();
        }
    }
}
