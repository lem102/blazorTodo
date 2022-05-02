using ItemApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ApiDbContext _context;

    public TodoController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _context.Items.ToListAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(ItemData data)
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult("Something went wrong.") { StatusCode = 500 };
        }

        await _context.Items.AddAsync(data);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { data.Id }, data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, ItemData data)
    {
        if (id != data.Id)
        {
            return BadRequest();
        }

        var existingItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

        if (existingItem is null)
        {
            return NotFound();
        }

        existingItem.Title = data.Title;
        existingItem.Description = data.Description;
        existingItem.IsDone = data.IsDone;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }
}
