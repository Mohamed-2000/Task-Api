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
    public class CallsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

      
        public CallsController(IUnitOfWork unitOfWork, ILogger<CallsController> logger)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Calls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calls>>> Getcalls()
        {
            return  Ok(await _unitOfWork.calls.GetAllAsync());
        }

        //[HttpGet("GetWithEmployee")]
        //public IActionResult GetTheWhole()
        //{
        //    return Ok(_unitOfWork.calls.GetTheWhole(new[] { "Employees" }));
        //}

        [HttpGet("GetWithpagging")]
        public IActionResult GetTheWhole([FromQuery] ClientParameters clientParameters)
        {
            var call = _unitOfWork.calls.GetTheWhole(clientParameters);

            var metadata = new
            {
                call.TotalCount,
                call.PageSize,
                call.CurrentPage,
                call.TotalPages,
                call.HasNext,
                call.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(call);
        }

        // GET: api/Calls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calls>> GetCalls(int id)
        {
            var calls = await _unitOfWork.calls.GetByIdAsync(id);

            if (calls == null)
            {
                return NotFound();
            }

            return calls;
        }

        // PUT: api/Calls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalls(int id, Calls calls)
        {
            if (id != calls.Id)
            {
                return BadRequest();
            }

            _unitOfWork.calls.Update(calls);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallsExists(id))
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

        // POST: api/Calls
        [HttpPost]
        public async Task<ActionResult<Calls>> PostCalls(Calls calls)
        {
            await _unitOfWork.calls.AddAsync(calls);

            await _unitOfWork.Complete();

            return CreatedAtAction("GetCalls", new { id = calls.Id }, calls);
        }

        // DELETE: api/Calls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalls(int id)
        {
            var calls = await _unitOfWork.calls.FindAsync(b => b.Id == id);
            if (calls == null)
            {
                return NotFound();
            }

            _unitOfWork.calls.Delete(calls);

            await _unitOfWork.Complete();

            return NoContent();
        }

        private bool CallsExists(int id)
        {
            var TheCall = _unitOfWork.calls.GetById(id);

            if (TheCall.Id == id)
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
