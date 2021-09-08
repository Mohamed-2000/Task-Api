using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RepositryPattern.Core;
using RepositryPattern.Core.Models;
using RepositryPattern.EF;

namespace RepositryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<clientController> _logger;

        public clientController(IUnitOfWork unitOfWork, ILogger<clientController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<client>>> Getclients()
        {
            return Ok(await _unitOfWork.clients.GetAllAsync());
        }

        //[HttpGet("GetWithEmployee")]
        //public IActionResult GetTheWhole()
        //{
        //    return Ok(_unitOfWork.clients.GetTheWhole(new[] { "Employees" }));
        //}

        [HttpGet("GetWithEmployee")]
        public IActionResult GetTheWhole([FromQuery] ClientParameters clientParameters)
        {
            var clients = _unitOfWork.clients.GetTheWhole(clientParameters, new[] { "Employees" });

            var metadata = new
            {
                clients.TotalCount,
                clients.PageSize,
                clients.CurrentPage,
                clients.TotalPages,
                clients.HasNext,
                clients.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            _logger.LogInformation($"Returned {clients.TotalCount} owners from database.");
            return Ok(clients);
        }

        // GET: api/client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<client>> Getclient(int id)
        {
            var client = await _unitOfWork.clients.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclient(int id, client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _unitOfWork.clients.Update(client);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/client
        [HttpPost]
        public async Task<ActionResult<client>> Postclient(client client)
        {
            await _unitOfWork.clients.AddAsync(client);
            await _unitOfWork.Complete();

            return CreatedAtAction("Getclient", new { id = client.Id }, client);
        }

        // DELETE: api/client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclient(int id)
        {
            var client = await _unitOfWork.clients.FindAsync(b => b.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _unitOfWork.clients.Delete(client);
            
            await _unitOfWork.Complete();

            return NoContent();
        }

        private bool clientExists(int id)
        {
            var TheClient = _unitOfWork.clients.GetById(id);

            if(TheClient.Id == id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
