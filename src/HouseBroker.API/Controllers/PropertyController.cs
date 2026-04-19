using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HouseBroker.API.Controllers
{
    [ApiController]
    [Route("api/property-listings")]
    public class PropertyListingController : ControllerBase
    {
        private readonly IPropertyListingService _service;

        public PropertyListingController(IPropertyListingService service)
        {
            _service = service;
        }

        //Requirement: Public access for house seekers to view listings
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Broker")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePropertyListingDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(PropertyListingSearchDto dto)
        {
            return Ok(await _service.SearchAsync(dto));
        }
        [HttpPost("{id}/upload")]
        public async Task<IActionResult> Upload(Guid id, IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var path = Path.Combine("wwwroot/images", fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return Ok(new { Url = "/images/" + fileName });
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var result = await _service.GetByIdAsync(
                id,
                userId,
                role == "Broker"
            );

            return Ok(result);
        }
    }
}
