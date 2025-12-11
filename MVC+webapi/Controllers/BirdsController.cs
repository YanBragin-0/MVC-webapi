using Microsoft.AspNetCore.Mvc;
using MVC_webapi.Models.ServiceInterfaces;

namespace MVC_webapi.Controllers
{
    public class BirdsController : Controller
    {
        private readonly IBirdService _service;
        public BirdsController(IBirdService service)
        {
            _service = service;
        }
        [HttpGet("GetallBirds")]
        public async Task<IActionResult> Getall()
        {
            return View("Index",await _service.getAll());
        }
        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return View("GetInfo",await _service.getBuId(id));
        }
    }
}
