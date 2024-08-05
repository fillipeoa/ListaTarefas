using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListaTarefasApi.Data;
using ListaTarefasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("API/[controller]")]
[ApiController]
public class ListaTarefasController : ControllerBase
{
    private readonly AppDbContext _context;

    public ListaTarefasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
    {
        return await _context.Tarefas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> GetTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        return tarefa;
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
    {
        tarefa.created_at = DateTime.Now;
        tarefa.updated_at = DateTime.Now;
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTarefa", new { id = tarefa.id }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
    {
        if (id != tarefa.id)
        {
            return BadRequest();
        }

        _context.Entry(tarefa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TarefaExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TarefaExists(int id)
    {
        return _context.Tarefas.Any(e => e.id == id);
    }
}
