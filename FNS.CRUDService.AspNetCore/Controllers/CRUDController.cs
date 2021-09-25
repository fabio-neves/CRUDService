using System.Linq;
using System.Threading.Tasks;
using CRUDService.AspNetCore.Extensions;
using FNS.CRUDService.Interfaces;
using FNS.CRUDService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUDService.AspNetCore.Controllers
{
    public class CRUDController<T> : ControllerBase
    {
        private readonly IBaseDomainService<T> _service;

        public CRUDController(IBaseDomainService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PagingQuery query)
        {
            var response = await _service.List(query);

            if (response.Errors.Any())
            {
                return this.HandleError(response);
            }

            return Ok(response.Result);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await _service.Get(id);

            if (response.Errors.Any())
            {
                return this.HandleError(response);
            }

            if (response.Result == null)
            {
                return NotFound();
            }

            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(T client)
        {
            var response = await _service.Create(client);

            if (response.Errors.Any())
            {
                return this.HandleError(response);
            }

            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(T client)
        {
            var response = await _service.Update(client);

            if (response.Errors.Any())
            {
                return this.HandleError(response);
            }

            return Ok(response.Result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var response = await _service.Delete(id);

            if (response.Errors.Any())
            {
                return this.HandleError(response);
            }

            return Ok(response.Result);
        }
    }
}
