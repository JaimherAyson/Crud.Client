using Crud.Server.Models;
using Crud.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _itemService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
            => Ok(await _itemService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            await _itemService.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Item item)
        {
            await _itemService.UpdateAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _itemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
