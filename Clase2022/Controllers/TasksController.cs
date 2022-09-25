using Microsoft.AspNetCore.Mvc;
using Clase2022.Entities;
using Clase2022.Services;
using Newtonsoft.Json;


namespace Clase2022.Controllers;

[ApiController]
[Route ("api/[controller]")]

    public class TasksController : ControllerBase
    {
    private readonly TasksService _tasksService;
    public TasksController(TasksService tasksService) => _tasksService = tasksService;


    [HttpGet]
    public async Task<List<Tasks>> Get() =>
    await _tasksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Tasks>> Get(string id)
    {
        var task = await _tasksService.GetAsync(id);

        if (task is null)
        {
            return NotFound();
        }

        return task;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Tasks newTasks)
    {
        await _tasksService.CreateAsync(newTasks);

        return CreatedAtAction(nameof(Get), new { id = newTasks.Id }, newTasks);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Tasks updatedTasks)
    {
        var book = await _tasksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedTasks.Id = book.Id;

        await _tasksService.UpdateAsync(id, updatedTasks);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _tasksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _tasksService.RemoveAsync(id);

        return NoContent();
    }

}


