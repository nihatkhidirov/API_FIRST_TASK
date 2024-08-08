using APIPB301.DLL.Data;
using APIPB301.DLL.Entities;
using APIPB301.Dtos.GroupDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIPB301.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopAppDbContext _context;

        public ShopController(ShopAppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult>  Get()
        {
            var groups = await _context.Groups
                .Include("Students")
                .ToListAsync();
            return Ok(await _context.Groups.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            var existGroup=await _context.Groups.FirstOrDefaultAsync(g=> g.Id == id); 
            if(existGroup == null)
            {
                return NotFound();
            }
            return Ok(existGroup);
        }
        [HttpPost("")]
        public async Task <IActionResult> Create(GroupCreateDto groupCreateDto)
        {
            if(await _context.Groups.AnyAsync(g => g.Name.ToLower() == groupCreateDto.Name.ToLower()))
            {
                return BadRequest("Dublicate Group Name");
            }
            Group group = new Group()
            {
                Name = groupCreateDto.Name,
                Limit = groupCreateDto.Limit,
            };
        
            
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Group group)
        {

            var existGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (existGroup == null)
            {
                return NotFound();
            }
            if (existGroup.Name!=group.Name &&await _context.Groups.AnyAsync(g => g.Name.ToLower() == group.Name.ToLower() && g.Id!=id))
            {
                return BadRequest("Dublicate Group Name");
            }

            existGroup.Name = group.Name;
            existGroup.Limit=group.Limit;
            await _context.SaveChangesAsync();
            return Ok(existGroup);
        }
        [HttpDelete("")]
        public async Task<IActionResult>Delete(int id)
        {
            var existGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if(existGroup == null)  return NotFound(); 
            _context.Groups.Remove(existGroup);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
